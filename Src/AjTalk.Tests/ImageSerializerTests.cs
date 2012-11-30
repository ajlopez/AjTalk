namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ImageSerializerTests
    {
        [TestMethod]
        public void SerializeDeserializeNil()
        {
            Assert.IsNull(this.Process(null, null));
        }

        [TestMethod]
        public void SerializeDeserializeInteger()
        {
            Assert.AreEqual(123, this.Process(123, null));
        }

        [TestMethod]
        public void SerializeDeserializeString()
        {
            Assert.AreEqual("text", this.Process("text", null));
        }

        [TestMethod]
        public void SerializeDeserializeEmptyObject()
        {
            IObject obj = new BaseObject();
            var result = this.Process(obj, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(0, iobj.NoVariables);
        }

        [TestMethod]
        public void SerializeDeserializeObjectWithNilVariables()
        {
            IObject obj = new BaseObject(null, new object[10]);
            var result = this.Process(obj, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(10, iobj.NoVariables);

            for (int k = 0; k < 10; k++)
                Assert.IsNull(iobj[k]);
        }

        [TestMethod]
        public void SerializeDeserializeObjectWithIntegerVariables()
        {
            IObject obj = new BaseObject(null, new object[4] { 0, 1, 2, 3 });
            var result = this.Process(obj, null);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(4, iobj.NoVariables);

            for (int k = 0; k < 4; k++)
                Assert.AreEqual(k, iobj[k]);
        }

        [TestMethod]
        public void SerializeDeserializeClass()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("MyClass");
            klass.DefineInstanceVariable("a");
            klass.DefineInstanceVariable("b");
            klass.DefineClassVariable("c");
            klass.DefineClassVariable("d");

            var result = this.Process(klass, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var bclass = (BaseClass)result;

            Assert.AreEqual("MyClass", bclass.Name);
            Assert.IsNotNull(bclass.Behavior);
            Assert.AreEqual(0, bclass.GetInstanceVariableOffset("a"));
            Assert.AreEqual(1, bclass.GetInstanceVariableOffset("b"));
            Assert.AreEqual(0, bclass.GetClassVariableOffset("c"));
            Assert.AreEqual(1, bclass.GetClassVariableOffset("d"));
        }

        [TestMethod]
        public void SerializeDeserializeNativeClass()
        {
            Machine machine = new Machine();
            IBehavior behavior = machine.CreateNativeBehavior(null, typeof(System.IO.File));

            var result = this.Process(behavior, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NativeBehavior));

            var nbehavior = (NativeBehavior)result;

            Assert.IsNotNull(nbehavior.Behavior);
        }

        [TestMethod]
        public void SerializeDeserializeMachineWithNativeBehavior()
        {
            Machine machine = new Machine();
            IBehavior behavior = machine.CreateNativeBehavior(null, typeof(System.IO.File));
            machine.RegisterNativeBehavior(typeof(System.IO.File), (NativeBehavior)behavior);
            machine.SetGlobalObject("File", behavior);

            var result = this.Process(machine, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Machine));

            var newmachine = (Machine)result;

            Assert.IsNotNull(newmachine.GetGlobalObject("File"));
            Assert.IsNotNull(newmachine.GetNativeBehavior(typeof(System.IO.File)));
        }

        [TestMethod]
        public void SerializeDeserializeMachinePreservingBuiltinMethods()
        {
            Machine machine = new Machine();
            machine.SetGlobalObject("Block", machine.GetNativeBehavior(typeof(Block)));

            var result = this.Process(machine, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Machine));

            var newmachine = (Machine)result;

            var blockbehavior = newmachine.GetNativeBehavior(typeof(Block));
            Assert.IsNotNull(blockbehavior);
            Assert.IsNotNull(blockbehavior.GetInstanceMethod("value"));
        }

        [TestMethod]
        public void SerializeDeserializeClassWithInstanceMethod()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("MyClass");
            Method method = (new VmCompiler()).CompileInstanceMethod("add: x to: y ^x + y", klass);
            klass.DefineInstanceMethod(method);

            machine = new Machine();
            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
            Assert.IsNull(machine.GetGlobalObject("MyClass"));

            var result = this.Process(klass, machine);
            var undefined = machine.GetGlobalObject("UndefinedObject");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var bclass = (BaseClass)result;

            Assert.AreEqual("MyClass", bclass.Name);
            var bmethod = bclass.GetInstanceMethod("add:to:");
            Assert.IsNotNull(bmethod);
        }

        [TestMethod]
        public void SerializeDeserializeClassWithClassMethod()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("MyClass");
            Method method = (new VmCompiler()).CompileClassMethod("add: x to: y ^x + y", klass);
            klass.DefineClassMethod(method);

            machine = new Machine();
            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
            Assert.IsNull(machine.GetGlobalObject("MyClass"));
            var undefined = machine.GetGlobalObject("UndefinedObject");

            var result = this.Process(klass, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var bclass = (BaseClass)result;

            Assert.AreEqual("MyClass", bclass.Name);
            var bmethod = bclass.GetClassMethod("add:to:");
            Assert.IsNotNull(bmethod);
        }

        [TestMethod]
        public void SerializeDeserializeObjectsWithCycle()
        {
            IObject obja = new BaseObject(null, 1);
            IObject objb = new BaseObject(null, 1);
            obja[0] = objb;
            objb[0] = obja;

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            ImageSerializer serializer = new ImageSerializer(writer);
            
            serializer.Serialize(obja);
            serializer.Serialize(objb);

            writer.Close();
            stream = new MemoryStream(stream.ToArray());
            BinaryReader reader = new BinaryReader(stream);
            
            ImageSerializer deserializer = new ImageSerializer(reader, null);
            
            var resulta = deserializer.Deserialize();
            var resultb = deserializer.Deserialize();

            Assert.IsNotNull(resulta);
            Assert.IsInstanceOfType(resulta, typeof(IObject));

            var iobja = (IObject)resulta;
            Assert.IsNull(iobja.Behavior);
            Assert.AreEqual(1, iobja.NoVariables);

            Assert.IsNotNull(resultb);
            Assert.IsInstanceOfType(resultb, typeof(IObject));

            var iobjb = (IObject)resultb;
            Assert.IsNull(iobjb.Behavior);
            Assert.AreEqual(1, iobjb.NoVariables);

            Assert.AreEqual(iobja, iobjb[0]);
            Assert.AreEqual(iobjb, iobja[0]);
        }

        [TestMethod]
        public void SerializeDeserializeEmptyMachine()
        {
            Machine machine = new Machine();

            var result = this.Process(machine, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Machine));

            var newmachine = (Machine)result;

            CompareMachines(machine, newmachine);
        }

        [TestMethod]
        public void SerializeDeserializeMachineWithClassObjectAndValues()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle", machine.UndefinedObjectClass, "x y", null);
            machine.SetGlobalObject(klass.Name, klass);
            machine.SetGlobalObject("One", 1);
            machine.SetGlobalObject("Name", "Adam");
            IObject rect = (IObject)klass.NewObject();
            machine.SetGlobalObject("MyRectangle", rect);
            rect[0] = 10;
            rect[1] = 20;
            var compiler = new VmCompiler();
            Method xmethod = compiler.CompileInstanceMethod("x ^x", klass);
            klass.DefineInstanceMethod(xmethod);
            Method ymethod = compiler.CompileInstanceMethod("y ^y", klass);
            klass.DefineInstanceMethod(ymethod);
            Method addmethod = compiler.CompileClassMethod("add: x to: y ^x + y", klass);
            klass.DefineClassMethod(addmethod);

            var result = this.Process(machine, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Machine));

            var newmachine = (Machine)result;

            CompareMachines(machine, newmachine);

            Assert.AreEqual(1, newmachine.GetGlobalObject("One"));
            Assert.AreEqual("Adam", newmachine.GetGlobalObject("Name"));

            var newvalue = newmachine.GetGlobalObject("MyRectangle");
            Assert.IsNotNull(newvalue);
            Assert.IsInstanceOfType(newvalue, typeof(IObject));

            var newrect = (IObject)newvalue;

            newvalue = newmachine.GetGlobalObject("Rectangle");
            Assert.IsNotNull(newvalue);
            Assert.IsInstanceOfType(newvalue, typeof(IBehavior));

            var newklass = (IBehavior)newvalue;

            Assert.IsNotNull(newrect.Behavior);
            Assert.AreEqual(newrect.Behavior, newklass);

            Assert.AreEqual(10, newrect[0]);
            Assert.AreEqual(20, newrect[1]);

            Assert.AreEqual(10, newrect.SendMessage("x", null));
            Assert.AreEqual(20, newrect.SendMessage("y", null));
            Assert.AreEqual(3, newklass.SendMessage("add:to:", new object[] { 1, 2 }));
        }

        [TestMethod]
        [DeploymentItem(@"Library\Object.st")]
        [DeploymentItem(@"Library\Behavior.st")]
        [DeploymentItem(@"Library\Class.st")]
        [DeploymentItem(@"Library\Test.st")]
        public void SerializeDeserializeMachineWithLibrary()
        {
            Machine machine = new Machine();
            LoadFile(machine, "Object.st");
            LoadFile(machine, "Behavior.st");
            LoadFile(machine, "Class.st");
            LoadFile(machine, "Test.st");

            var result = this.Process(machine, machine);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Machine));

            var newmachine = (Machine)result;

            CompareMachines(machine, newmachine);

            // Test class
            Assert.IsNotNull(newmachine.GetGlobalObject("Test"));
            IClass cls = (IClass)newmachine.GetGlobalObject("Object");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
            cls = (IClass)newmachine.GetGlobalObject("Class");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
            cls = (IClass)newmachine.GetGlobalObject("Test");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
        }

        private static void CompareMachines(Machine machine, Machine newmachine)
        {
            Assert.IsNotNull(newmachine.UndefinedObjectClass);
            Assert.IsNotNull(newmachine.GetGlobalObject("UndefinedObject"));
            Assert.AreNotEqual(machine.GetGlobalObject("UndefinedObject"), newmachine.GetGlobalObject("UndefinedObject"));

            var names = machine.GetGlobalNames();
            var newnames = machine.GetGlobalNames();

            Assert.IsNotNull(newnames);
            Assert.AreEqual(names.Count, newnames.Count);

            foreach (var newname in newnames)
                Assert.IsTrue(names.Contains(newname));
        }

        private object Process(object obj, Machine machine)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            ImageSerializer serializer = new ImageSerializer(writer);
            serializer.Serialize(obj);
            writer.Close();
            stream = new MemoryStream(stream.ToArray());
            BinaryReader reader = new BinaryReader(stream);

            ImageSerializer deserializer = new ImageSerializer(reader, machine);
            return deserializer.Deserialize();
        }

        private static void LoadFile(Machine machine, string filename)
        {
            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(machine);
        }
    }
}

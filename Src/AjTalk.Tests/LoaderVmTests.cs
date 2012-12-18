namespace AjTalk.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Hosting;
    using AjTalk.Language;
    using AjTalk.Tests.Language;
    using AjTalk.Tests.NativeObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoaderVmTests
    {
        [TestMethod]
        public void GetEmptyLine()
        {
            Loader loader = new Loader(new StringReader("\n"), new VmCompiler());

            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetSpaceLine()
        {
            Loader loader = new Loader(new StringReader(" \n"), new VmCompiler());

            Assert.AreEqual(" \r\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetTwoLinesBlock()
        {
            Loader loader = new Loader(new StringReader("line 1\r\nline 2\r\n!"), new VmCompiler());

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\r\nline 2\r\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ProcessDoubleBang()
        {
            Loader loader = new Loader(new StringReader("!!new! !!new"), new VmCompiler());

            Assert.AreEqual("!new", loader.GetBlockText());
            Assert.AreEqual(" !new", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("line 1\r\nline 2\r\n!\r\nline 3\r\nline 4\r\n!\r\n"), new VmCompiler());

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\r\nline 2\r\n", loader.GetBlockText());
            Assert.AreEqual("line 3\r\nline 4\r\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetBlockAndInmediate()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!inmediate!\n"), new VmCompiler());

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\r\nline 2\r\n", loader.GetBlockText());
            Assert.AreEqual("inmediate", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Loader loader = new Loader(new StringReader("One := 1\n!\n"), new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void ExecuteBlockWithTwoCommands()
        {
            Loader loader = new Loader(new StringReader("One := 1.\nTwo := 2\n!\n"), new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void ExecuteTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("One := 1.\n!\nTwo := 2\n!\n"), new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObject.st")]
        public void ExecuteSetObjectFile()
        {
            Loader loader = new Loader(@"SetObject.st", new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetDotNetObject.st")]
        public void ExecuteSetDotNetObjectFile()
        {
            Loader loader = new Loader(@"SetDotNetObject.st", new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("FileInfo");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.IO.FileInfo));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObjects.st")]
        public void ExecuteSetObjectsFile()
        {
            Loader loader = new Loader(@"SetObjects.st", new VmCompiler());
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclass.st")]
        public void ExecuteDefineSubclassFile()
        {
            Loader loader = new Loader(@"DefineSubclass.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Object"));

            loader.LoadAndExecute(machine);

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclassWithVariables.st")]
        public void ExecuteDefineSubclassWithVariablesFile()
        {
            Loader loader = new Loader(@"DefineSubclassWithVariables.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangle.st")]
        public void ExecuteDefineRectangleFile()
        {
            Loader loader = new Loader(@"DefineRectangle.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(2, cls.GetInstanceVariableOffset("width"));
            Assert.AreEqual(3, cls.GetInstanceVariableOffset("height"));

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
            Assert.IsNotNull(cls.GetInstanceMethod("y"));
            Assert.IsNotNull(cls.GetInstanceMethod("y:"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void ExecuteDefineRectangleWithNewAndInitializeFile()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("result");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));

            IObject iobj = (IObject)obj;

            Assert.AreEqual(10, iobj[0]);
            Assert.AreEqual(20, iobj[1]);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineClassSubclass.st")]
        public void ExecuteDefineClassSubclassFile()
        {
            Loader loader = new Loader(@"DefineClassSubclass.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(2, cls.GetInstanceVariableOffset("width"));
            Assert.AreEqual(3, cls.GetInstanceVariableOffset("height"));

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
            Assert.IsNotNull(cls.GetInstanceMethod("y"));
            Assert.IsNotNull(cls.GetInstanceMethod("y:"));
            Assert.IsNotNull(cls.GetInstanceMethod("width"));
            Assert.IsNotNull(cls.GetInstanceMethod("height"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library1.st")]
        public void LoadLibrary()
        {
            Loader loader = new Loader(@"Library1.st", new VmCompiler());

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Object"));
            Assert.IsNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNull(machine.GetGlobalObject("Class"));
            Assert.IsNull(machine.GetGlobalObject("Metaclass"));

            loader.LoadAndExecute(machine);

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
            Assert.IsNotNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNotNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNotNull(machine.GetGlobalObject("Class"));
            Assert.IsNotNull(machine.GetGlobalObject("Metaclass"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library1.st")]
        public void LoadLibraryWithBootstrap()
        {
            Loader loader = new Loader(@"Library1.st", new VmCompiler());
            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            IClass objclass = (IClass)machine.GetGlobalObject("Object");
            IClass behaviorclass = (IClass)machine.GetGlobalObject("Behavior");
            IClass classdescriptionclass = (IClass)machine.GetGlobalObject("ClassDescription");
            IClass classclass = (IClass)machine.GetGlobalObject("Class");
            IClass metaclassclass = (IClass)machine.GetGlobalObject("Metaclass");

            Assert.AreEqual(objclass, behaviorclass.SuperClass);
            Assert.AreEqual(behaviorclass, classdescriptionclass.SuperClass);
            Assert.AreEqual(classdescriptionclass, classclass.SuperClass);
            Assert.AreEqual(classdescriptionclass, metaclassclass.SuperClass);

            Assert.IsNotNull(objclass.MetaClass);
            Assert.IsNotNull(behaviorclass.MetaClass);
            Assert.IsNotNull(classdescriptionclass.MetaClass);
            Assert.IsNotNull(classclass.MetaClass);
            Assert.IsNotNull(metaclassclass.MetaClass);

            Assert.AreEqual(objclass.MetaClass, behaviorclass.MetaClass.SuperClass);
            Assert.AreEqual(behaviorclass.MetaClass, classdescriptionclass.MetaClass.SuperClass);
            Assert.AreEqual(classdescriptionclass.MetaClass, classclass.MetaClass.SuperClass);
            Assert.AreEqual(classdescriptionclass.MetaClass, metaclassclass.MetaClass.SuperClass);

            Assert.AreEqual(metaclassclass, objclass.MetaClass.Behavior);
            Assert.AreEqual(metaclassclass, behaviorclass.MetaClass.Behavior);
            Assert.AreEqual(metaclassclass, classdescriptionclass.MetaClass.Behavior);
            Assert.AreEqual(metaclassclass, classclass.MetaClass.Behavior);
            Assert.AreEqual(metaclassclass, metaclassclass.MetaClass.Behavior);

            // TODO objclass super should be nil == null, now is object nil
            // Assert.IsNull(objclass.SuperClass);
            Assert.IsNotNull(objclass.MetaClass.SuperClass);
            Assert.AreEqual(classclass, objclass.MetaClass.SuperClass);
        }

        [TestMethod]
        [DeploymentItem(@"Library\Object.st")]
        [DeploymentItem(@"CodeFiles\ObjectTest.st")]
        public void LoadObject()
        {
            Machine machine = CreateMachine();
            Loader loader = new Loader(@"Object.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"ObjectTest.st", new VmCompiler());
            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Object");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.IsNotNull(cls.GetClassMethod("new"));
            Assert.IsNotNull(cls.GetClassMethod("basicNew"));

            object result = machine.GetGlobalObject("result");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)result).Behavior);

            object rcls = machine.GetGlobalObject("resultclass");
            Assert.AreEqual(cls, rcls);

            Assert.AreEqual(true, machine.GetGlobalObject("aresame"));
            Assert.AreEqual(false, machine.GetGlobalObject("arenotsame"));
            Assert.AreEqual(true, machine.GetGlobalObject("areequal"));
            Assert.AreEqual(false, machine.GetGlobalObject("arenotequal"));

            Assert.AreEqual(false, machine.GetGlobalObject("notaresame"));
            Assert.AreEqual(true, machine.GetGlobalObject("notarenotsame"));
            Assert.AreEqual(false, machine.GetGlobalObject("notareequal"));
            Assert.AreEqual(true, machine.GetGlobalObject("notarenotequal"));
        }

        [TestMethod]
        [DeploymentItem(@"Library\Object.st")]
        [DeploymentItem(@"Library\Behavior.st")]
        [DeploymentItem(@"CodeFiles\BehaviorTest.st")]
        public void LoadBehavior()
        {
            Machine machine = CreateMachine();

            Loader loader = new Loader(@"Object.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"Behavior.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"BehaviorTest.st", new VmCompiler());
            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("NewBehavior");
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual("Behavior", ((IClass)cls.SuperClass).Name);

            Assert.IsNotNull(cls.Behavior.GetInstanceMethod("compile:"));
        }

        [TestMethod]
        [DeploymentItem(@"Library\Object.st")]
        [DeploymentItem(@"Library\Behavior.st")]
        [DeploymentItem(@"Library\Class.st")]
        [DeploymentItem(@"CodeFiles\ClassTest.st")]
        public void LoadClass()
        {
            Machine machine = CreateMachine();

            Loader loader = new Loader(@"Object.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"Behavior.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"Class.st", new VmCompiler());
            loader.LoadAndExecute(machine);
            loader = new Loader(@"ClassTest.st", new VmCompiler());
            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("MyClass");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual("MyClass", cls.Name);
            Assert.AreEqual("Object", ((IClass)cls.SuperClass).Name);

            object obj2 = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj2);
            Assert.IsInstanceOfType(obj2, typeof(IClass));

            IClass cls2 = (IClass)obj2;

            Assert.AreEqual("Rectangle", cls2.Name);
            Assert.AreEqual("Object", ((IClass)cls2.SuperClass).Name);
            Assert.AreEqual(2, cls2.NoInstanceVariables);
            Assert.AreEqual(0, cls2.Behavior.NoInstanceVariables);
            Assert.AreEqual(1, cls2.NoClassVariables);
            Assert.AreEqual("width height", cls2.GetInstanceVariableNamesAsString());
            Assert.AreEqual("Number", cls2.GetClassVariableNamesAsString());

            object obj3 = machine.GetGlobalObject("rect");

            Assert.IsNotNull(obj3);
            Assert.IsInstanceOfType(obj3, typeof(IObject));

            IObject rect = (IObject)obj3;

            Assert.AreEqual(cls2, rect.Behavior);
            Assert.AreEqual(100, rect[0]);
            Assert.AreEqual(50, rect[1]);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library1.st")]
        public void ReviewClassGraph()
        {
            Loader loader = new Loader(@"Library1.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            IBehavior objclass = (IBehavior)machine.GetGlobalObject("Object");
            Assert.IsNotNull(objclass);
            Assert.IsNotNull(objclass.Behavior);
            Assert.IsNotNull(objclass.MetaClass);
            Assert.IsNull(objclass.SuperClass);

            IBehavior behclass = (IBehavior)machine.GetGlobalObject("Behavior");
            Assert.IsNotNull(behclass);
            Assert.IsNotNull(behclass.Behavior);
            Assert.IsNotNull(behclass.MetaClass);
            Assert.IsNotNull(behclass.SuperClass);

            Assert.AreEqual(objclass, behclass.SuperClass);
            Assert.AreEqual(objclass.MetaClass, behclass.MetaClass.SuperClass);

            IClassDescription classdes = (IClassDescription)machine.GetGlobalObject("ClassDescription");
            Assert.IsNotNull(classdes);
            Assert.IsNotNull(classdes.Behavior);
            Assert.IsNotNull(classdes.MetaClass);
            Assert.IsNotNull(classdes.SuperClass);

            Assert.AreEqual(behclass, classdes.SuperClass);
            Assert.AreEqual(behclass.MetaClass, classdes.MetaClass.SuperClass);

            IClass clazz = (IClass)machine.GetGlobalObject("Class");
            Assert.IsNotNull(clazz);
            Assert.IsNotNull(clazz.Behavior);
            Assert.IsNotNull(clazz.MetaClass);
            Assert.IsNotNull(clazz.SuperClass);

            Assert.AreEqual(classdes, clazz.SuperClass);
            Assert.AreEqual(classdes.MetaClass, clazz.MetaClass.SuperClass);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\NativeBehavior.st")]
        public void LoadNativeBehavior()
        {
            Loader loader = new Loader(@"NativeBehavior.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("myList");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ArrayList));

            ArrayList list = (ArrayList)result;

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual("foo", list[1]);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\NativeRectangle.st")]
        public void LoadNativeRectangle()
        {
            Loader loader = new Loader(@"NativeRectangle.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            object result1 = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(result1);
            Assert.IsInstanceOfType(result1, typeof(NativeBehavior));

            object result2 = machine.GetGlobalObject("rect");

            Assert.IsNotNull(result2);
            Assert.IsInstanceOfType(result2, typeof(Rectangle));

            object result = machine.GetGlobalObject("result");

            Assert.AreEqual(200, result);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\NativeFileInfo.st")]
        public void LoadNativeFileInfo()
        {
            Loader loader = new Loader(@"NativeFileInfo.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("myFileInfo");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileInfo));

            Assert.IsFalse((bool)machine.GetGlobalObject("result"));
        }

        [TestMethod]
        public void ExecuteTwoCommands()
        {
            Loader loader = new Loader(new StringReader("a := 1. b := 2"), new VmCompiler());
            Machine machine = CreateMachine();
            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("a"));
            Assert.AreEqual(2, machine.GetGlobalObject("b"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void LoadFileOut01()
        {
            Loader loader = new Loader(@"FileOut01.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut02.st")]
        public void LoadFileOut02()
        {
            Loader loader = new Loader(@"FileOut02.st", new VmCompiler());

            Machine machine = CreateMachine();

            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        [DeploymentItem(@"CodeFiles\PharoCorePoint.st")]
        public void LoadPharoCorePoint()
        {
            Loader loaderlib = new Loader(@"Library2.st", new VmCompiler());
            Loader loader = new Loader(@"PharoCorePoint.st", new VmCompiler());

            Machine machine = CreateMachine();

            loaderlib.LoadAndExecute(machine);
            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Point");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        [DeploymentItem(@"CodeFiles\PharoCoreRectangle.st")]
        public void LoadPharoCoreRectangle()
        {
            Loader loaderlib = new Loader(@"Library2.st", new VmCompiler());
            Loader loader = new Loader(@"PharoCoreRectangle.st", new VmCompiler());

            Machine machine = CreateMachine();

            loaderlib.LoadAndExecute(machine);
            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        public void LoadPharoCoreKernelObjects()
        {
            Loader loaderlib = new Loader(@"Library2.st", new VmCompiler());
            Loader loader = new Loader(@"PharoCoreKernelObjects.st", new VmCompiler());

            Machine machine = CreateMachine();

            loaderlib.LoadAndExecute(machine);
            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("ProtoObject");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("Boolean");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("UndefinedObject");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        [DeploymentItem(@"CodeFiles\PharoKernelNumbers.st")]
        public void LoadPharoKernelNumbers2()
        {
            Loader loaderlib = new Loader(@"Library2.st", new VmCompiler());
            Loader loaderobj = new Loader(@"PharoCoreKernelObjects.st", new VmCompiler());
            Loader loader = new Loader(@"PharoKernelNumbers.st", new VmCompiler());

            Machine machine = CreateMachine();

            loaderlib.LoadAndExecute(machine);
            loaderobj.LoadAndExecute(machine);
            loader.LoadAndExecute(machine);

            object result = machine.GetGlobalObject("Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("ProtoObject");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("Boolean");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            result = machine.GetGlobalObject("UndefinedObject");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
        }

        internal static Machine CreateMachine()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            return machine;
        }
    }
}


namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HostMachineTests
    {
        [TestMethod]
        public void GetClassByClassName()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = machine.GetClass(klass.Name);

            Assert.IsNotNull(result);
            Assert.AreSame(klass, result);
        }

        [TestMethod]
        public void GetMetaClassByClassName()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = machine.GetMetaClass(klass.Name);

            Assert.IsNotNull(result);
            Assert.AreSame(klass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedClassSameName()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass, result);
        }

        [TestMethod]
        public void GetAssociatedBehaviorUsingClass()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedBehavior(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass, result);
        }

        [TestMethod]
        public void GetAssociatedMetaClassSameName()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedBehaviorUsingMetaClass()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedBehavior(klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedSuperClass()
        {
            Machine hostmachine = new Machine();
            IClass hostsuperclass = hostmachine.CreateClass("Figure");
            hostmachine.SetGlobalObject(hostsuperclass.Name, hostsuperclass);

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostsuperclass, result);
        }

        [TestMethod]
        public void NotAssociatedSuperClass()
        {
            Machine hostmachine = new Machine();

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostmachine.UndefinedObjectClass, result);
        }

        [TestMethod]
        public void GetAssociatedSuperMetaClass()
        {
            Machine hostmachine = new Machine();
            IClass hostsuperclass = hostmachine.CreateClass("Figure");
            hostmachine.SetGlobalObject(hostsuperclass.Name, hostsuperclass);

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostsuperclass.Behavior, result);
        }

        [TestMethod]
        public void NoAssociatedSuperMetaClass()
        {
            Machine hostmachine = new Machine();

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostmachine.UndefinedObjectClass.Behavior, result);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\HostMachine.st")]
        [DeploymentItem(@"CodeFiles\HostedMachine.st")]
        public void CreateAndEvaluatedHostedObject()
        {
            Machine host = this.LoadMachine("HostMachine.st");
            Machine hosted = this.LoadMachine("HostedMachine.st");

            hosted.HostMachine = host;

            this.Evaluate(hosted, "rect := Rectangle new");
            var result = hosted.GetGlobalObject("rect");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;

            this.Evaluate(hosted, "rect x: 10");
            Assert.AreEqual(10, iobj[0]);
            this.Evaluate(hosted, "rect y: 20");
            Assert.AreEqual(20, iobj[1]);

            this.Evaluate(hosted, "rect width: 10");
            Assert.AreEqual(10, iobj[2]);
            this.Evaluate(hosted, "rect height: 30");
            Assert.AreEqual(30, iobj[3]);
            Assert.AreEqual(300, this.Evaluate(hosted, "rect area"));
        }

        [TestMethod]
        public void GetGlobalObjectFromHostMachine()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            machine.HostMachine = hostmachine;

            var result = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass, result);
        }

        private object Evaluate(Machine machine, string code)
        {
            SimpleCompiler compiler = new SimpleCompiler();
            Block block = compiler.CompileBlock(code);
            return block.Execute(machine, null);
        }

        private Machine LoadMachine(string filename)
        {
            Machine machine = new Machine();
            Loader loader = new Loader(filename, new SimpleCompiler());
            loader.LoadAndExecute(machine);
            return machine;
        }
    }
}

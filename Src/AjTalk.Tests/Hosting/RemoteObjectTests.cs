﻿namespace AjTalk.Tests.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Hosting;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoteObjectTests
    {
        [TestMethod]
        public void AccessVariables()
        {
            BaseObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            RemoteObject ro = new RemoteObject(obj, null);

            Assert.AreEqual(1, ro[0]);
            Assert.AreEqual(2, ro[1]);
            Assert.AreEqual(3, ro[2]);
        }

        [TestMethod]
        public void GetBehavior()
        {
            Machine machine = new Machine();
            BaseClass cls = new BaseClass("MyClass", machine);
            BaseObject obj = new BaseObject(cls, new object[] { 1, 2, 3 });
            RemoteObject ro = new RemoteObject(obj, null);

            Assert.AreEqual(1, ro[0]);
            Assert.AreEqual(2, ro[1]);
            Assert.AreEqual(3, ro[2]);

            Assert.AreEqual(cls, ro.Behavior);
        }

        [TestMethod]
        public void SendMessage()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("MyClass", null, "x", string.Empty);
            VmCompiler compiler = new VmCompiler();
            var method = compiler.CompileInstanceMethod("x: value x := value", cls);
            cls.DefineInstanceMethod(method);
            BaseObject obj = new BaseObject(cls, new object[1]);
            RemoteObject ro = new RemoteObject(obj, null);

            machine.SendMessage(ro, "x:", new object[] { 10 }, null);

            Assert.AreEqual(10, obj[0]);
        }
    }
}

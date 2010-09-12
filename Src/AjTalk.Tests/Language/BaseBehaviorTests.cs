using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Language;

namespace AjTalk.Tests.Language
{
    [TestClass]
    public class BaseBehaviorTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = LoaderTests.CreateMachine();
        }

        [TestMethod]
        public void CreateBaseBehaviorWithoutSuperclass()
        {
            BaseBehavior behavior = new BaseBehavior(null, this.machine);

            Assert.IsNull(behavior.SuperClass);
            Assert.IsNotNull(behavior.MetaClass);
        }

        [TestMethod]
        public void DefineInstanceMethod()
        {
            BaseBehavior behavior = new BaseBehavior(null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineInstanceMethod(new Method("method"));

            IMethod result = behavior.GetInstanceMethod("method");
            Assert.IsNotNull(result);
            Assert.AreEqual("method", result.Name);
        }

        [TestMethod]
        public void DefineClassMethod()
        {
            BaseBehavior behavior = new BaseBehavior(null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineClassMethod(new Method("method"));

            IMethod result = behavior.GetClassMethod("method");
            Assert.IsNotNull(result);
            Assert.AreEqual("method", result.Name);

            IMethod result2 = behavior.MetaClass.GetInstanceMethod("method");

            Assert.AreEqual(result, result2);
        }
    }
}

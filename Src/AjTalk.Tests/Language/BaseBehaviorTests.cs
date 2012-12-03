namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            BaseBehavior behavior = new BaseBehavior(null, null, this.machine);

            Assert.IsNull(behavior.SuperClass);
            Assert.IsNull(behavior.MetaClass);
        }

        [TestMethod]
        public void DefineInstanceMethod()
        {
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, this.machine);
            BaseBehavior behavior = new BaseBehavior(meta, null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineInstanceMethod(new Method("method"));

            IMethod result = behavior.GetInstanceMethod("method");
            Assert.IsNotNull(result);
            Assert.AreEqual("method", result.Name);
        }

        [TestMethod]
        public void AddBehaviorAsTrait()
        {
            BaseBehavior behavior = new BaseBehavior(null, null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineInstanceMethod(method);

            BaseBehavior trait = new BaseBehavior(null, null, this.machine);
            IMethod method2 = new Method("method2");

            trait.DefineInstanceMethod(method2);

            behavior.AddTrait(trait);

            IMethod result = behavior.GetInstanceMethod("method");
            Assert.IsNotNull(result);
            Assert.AreSame(method, result);
            result = behavior.GetInstanceMethod("method2");
            Assert.IsNotNull(result);
            Assert.AreSame(method2, result);
        }

        [TestMethod]
        public void GetInstanceMethods()
        {
            BaseBehavior behavior = new BaseBehavior(null, null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineInstanceMethod(new Method("method1"));
            behavior.DefineInstanceMethod(new Method("method2"));

            ICollection<IMethod> methods = behavior.GetInstanceMethods();

            Assert.IsNotNull(methods);
            Assert.AreEqual(2, methods.Count);
        }

        [TestMethod]
        public void DefineClassMethod()
        {
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, this.machine);
            BaseBehavior behavior = new BaseBehavior(meta, null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineClassMethod(new Method("method"));

            IMethod result = behavior.GetClassMethod("method");
            Assert.IsNotNull(result);
            Assert.AreEqual("method", result.Name);

            IMethod result2 = behavior.MetaClass.GetInstanceMethod("method");

            Assert.AreEqual(result, result2);
        }

        [TestMethod]
        public void GetClassMethods()
        {
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, this.machine);
            BaseBehavior behavior = new BaseBehavior(meta, null, this.machine);
            IMethod method = new Method("method");

            behavior.DefineClassMethod(new Method("method1"));
            behavior.DefineClassMethod(new Method("method2"));

            ICollection<IMethod> methods = behavior.GetClassMethods();

            Assert.IsNotNull(methods);
            Assert.AreEqual(2, methods.Count);
        }
    }
}

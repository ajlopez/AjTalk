namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Compiler;

    [TestClass]
    public class NativeBehaviorTests
    {
        [TestMethod]
        public void CreateObjectWithParameters()
        {
            Machine machine = new Machine();
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, machine);
            NativeBehavior behavior = new NativeBehavior(meta, null, machine, typeof(FileInfo));

            object result = behavior.CreateObject(new object[] { "File.txt" });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("File.txt", fileinfo.Name);
        }

        [TestMethod]
        public void DefineStringTypeWithMethodAndEvaluateIt()
        {
            Machine machine = new Machine();
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, machine);
            NativeBehavior behavior = new NativeBehavior(meta, null, machine, typeof(string));
            machine.RegisterNativeBehavior(typeof(string), behavior);

            behavior.DefineInstanceMethod(new FunctionalMethod("size", behavior, (object self, object[] args) => ((string)self).Length));
            Assert.AreEqual(3, this.Evaluate("'foo' size", machine));
            Assert.AreEqual(0, this.Evaluate("'' size", machine));
        }

        private object Evaluate(string text, Machine machine)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(machine, null);
        }
    }
}

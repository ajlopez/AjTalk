namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;
    using AjTalk.Tests.Compiler;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectTests
    {
        private IClass rectangleClass;

        [TestMethod]
        public void BeCreated() 
        {
            IObject obj = (IObject)this.GetRectangleClass().NewObject();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj[0]);
            Assert.IsNull(obj[1]);
            Assert.IsNull(obj[2]);
            Assert.IsNull(obj[3]);
        }

        [TestMethod]
        public void RunMethod()
        {
            IObject obj = (IObject)this.GetRectangleClass().NewObject();

            obj.SendMessage(null, "side:", new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
            Assert.AreEqual(100, obj.SendMessage(obj.Behavior.Machine, "area", null));
        }

        private IClass GetRectangleClass()
        {
            var variables = new string[] { "x", "y", "width", "height" };
            var methods = new string[] 
                    {
                        "x ^x",
                        "y ^y",
                        "x: newX x := newX",
                        "y: newY y := newY",
                        "area ^x*y",
                        "width ^width",
                        "height ^height",
                        "width: newWidth width := newWidth",
                        "height: newHeight height := newHeight",
                        "side: newSide x := newSide. y := newSide"
                    };

            if (this.rectangleClass == null)
            {
                this.rectangleClass = ParserTests.CompileClass(
                    "Rectangle",
                    variables,
                    methods);
            }

            return this.rectangleClass;
        }
    }
}

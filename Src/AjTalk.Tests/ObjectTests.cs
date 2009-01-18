namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectTests
    {
        private IClass rectangleClass;

        [TestMethod]
        public void ShouldBeCreated() 
        {
            IObject obj = this.GetRectangleClass().NewObject();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj[0]);
            Assert.IsNull(obj[1]);
            Assert.IsNull(obj[2]);
            Assert.IsNull(obj[3]);
        }

        [TestMethod]
        public void ShouldRunMethod()
        {
            IObject obj = this.GetRectangleClass().NewObject();

            obj.SendMessage("side:", new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
            Assert.AreEqual(100, obj.SendMessage("area", null));
        }

        private IClass GetRectangleClass()
        {
            if (this.rectangleClass == null)
            {
                this.rectangleClass = CompilerTests.CompileClass(
                    "Rectangle",
                    new string[] { "x", "y", "width", "height" },
                    new string[] 
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
                    });
            }

            return this.rectangleClass;
        }
    }
}

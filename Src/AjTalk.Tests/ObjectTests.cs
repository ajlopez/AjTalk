using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void ShouldBeCreated() 
        {
            IObject obj = GetRectangleClass().NewObject();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj[0]);
            Assert.IsNull(obj[1]);
            Assert.IsNull(obj[2]);
            Assert.IsNull(obj[3]);
        }

        [Test]
        public void ShouldRunMethod()
        {
            IObject obj = GetRectangleClass().NewObject();

            obj.SendMessage("side:", new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
            Assert.AreEqual(100, obj.SendMessage("area", null));
        }

        IClass rectangleClass;

        private IClass GetRectangleClass()
        {
            if (rectangleClass == null)
                rectangleClass = CompilerTests.CompileClass(
                    "Rectangle",
                    new string[] { "x", "y", "width", "height" },
                    new string[] {
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
                    }
                    );

            return rectangleClass;
        }
    }
}

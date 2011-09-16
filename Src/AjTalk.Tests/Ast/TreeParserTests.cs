namespace AjTalk.Tests.Ast
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Ast;

    [TestClass]
    public class TreeParserTests
    {
        [TestMethod]
        public void ParseSelf()
        {
            TreeParser parser = new TreeParser("self");
            INode node = parser.ParseNode();

            Assert.IsNotNull(node);
            Assert.IsInstanceOfType(node, typeof(SelfNode));
        }

        [TestMethod]
        public void ParseInstanceVariable()
        {
            TreeParser parser = new TreeParser("foo");
            INode node = parser.ParseNode();

            Assert.IsNotNull(node);
            Assert.IsInstanceOfType(node, typeof(InstanceVariableNode));

            InstanceVariableNode ivnode = (InstanceVariableNode)node;
            Assert.AreEqual("foo", ivnode.Name);
        }
    }
}

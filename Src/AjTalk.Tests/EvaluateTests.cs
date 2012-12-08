namespace AjTalk.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AjTalk.Compiler;
    using AjTalk.Exceptions;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EvaluateTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            // TODO refactor machine factory
            this.machine = LoaderTests.CreateMachine();
        }

        [TestMethod]
        public void EvaluateInteger()
        {
            Assert.AreEqual(1, this.Evaluate("1"));
        }

        [TestMethod]
        public void EvaluateNilAsNull()
        {
            Assert.IsNull(this.Evaluate("nil"));
        }

        [TestMethod]
        public void EvaluateNullAsNull()
        {
            Assert.IsNull(this.Evaluate("null"));
        }

        [TestMethod]
        public void EvaluateString()
        {
            Assert.AreEqual("foo", this.Evaluate("'foo'"));
        }

        [TestMethod]
        public void EvaluateBlockWithInteger()
        {
            Assert.AreEqual(1, this.Evaluate("[1] value"));
        }

        [TestMethod]
        public void EvaluateBlockWithIntegerInMethod()
        {
            var cls = this.machine.CreateClass("MyClass");
            this.machine.SetCurrentEnvironmentObject(cls.Name, cls);
            Parser parser = new Parser("mymethod ^[1] value");
            cls.DefineClassMethod(parser.CompileClassMethod(cls));
            Assert.AreEqual(1, this.Evaluate("MyClass mymethod"));
        }

        [TestMethod]
        public void EvaluateSelfAsReturnInMethodWithoutReturn()
        {
            var cls = this.machine.CreateClass("MyClass");
            this.machine.SetCurrentEnvironmentObject(cls.Name, cls);
            Parser parser = new Parser("mymethod [1] value");
            cls.DefineClassMethod(parser.CompileClassMethod(cls));
            Assert.AreEqual(cls, this.Evaluate("MyClass mymethod"));
        }

        [TestMethod]
        public void EvaluateLocalInstanceInInnerBlock()
        {
            var cls = this.machine.CreateClass("MyClass", this.machine.UndefinedObjectClass, "x", string.Empty);
            this.machine.SetCurrentEnvironmentObject(cls.Name, cls);
            var result = this.Evaluate("myobj := MyClass new");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));
            var iobj = (IObject)result;
            iobj[0] = 10;
            Parser parser = new Parser("x ^[x] value");
            cls.DefineInstanceMethod(parser.CompileInstanceMethod(cls));
            Assert.AreEqual(10, this.Evaluate("myobj x"));
        }

        [TestMethod]
        public void EvaluateBlockWithArgument()
        {
            Assert.AreEqual(1, this.Evaluate("[:a | a] value: 1"));
        }

        [TestMethod]
        public void EvaluateBlockWithArguments()
        {
            Assert.AreEqual(3, this.Evaluate("[:a :b | a+b] value: 1 value: 2"));
        }

        [TestMethod]
        public void EvaluateIntegerAdd()
        {
            Assert.AreEqual(4, this.Evaluate("1+3"));
        }

        [TestMethod]
        public void EvaluateIntegerAddAndEquals()
        {
            Assert.AreEqual(true, this.Evaluate("1+3==4"));
        }

        [TestMethod]
        public void EvaluateIntegerLess()
        {
            Assert.AreEqual(true, this.Evaluate("1<3"));
        }

        [TestMethod]
        public void EvaluateIntegerOperators()
        {
            Assert.AreEqual(3.0, this.Evaluate("6/2"));
            Assert.AreEqual(6, this.Evaluate("2*3"));
            Assert.AreEqual(false, this.Evaluate("2>3"));
            Assert.AreEqual(false, this.Evaluate("2>=3"));
            Assert.AreEqual(true, this.Evaluate("3<=3"));
            Assert.AreEqual(true, this.Evaluate("2<3"));
        }

        [TestMethod]
        public void EvaluateIntegerToString()
        {
            Assert.AreEqual("1", this.Evaluate("1 toString"));
        }

        [TestMethod]
        public void EvaluateIntegerSubstring()
        {
            Assert.AreEqual("23", this.Evaluate("1234 toString substring: 1 with: 2"));
        }

        [TestMethod]
        public void EvaluateBlockWithIntegerParameter()
        {
            Assert.AreEqual(2, this.Evaluate("[:x | x] value: 2"));
        }

        [TestMethod]
        public void EvaluateBlockWithTwoIntegerParameters()
        {
            Assert.AreEqual(5, this.Evaluate("[:x :y | x + y] value: 2 value: 3"));
        }

        [TestMethod]
        public void EvaluateGlobalVariable()
        {
            this.machine.SetGlobalObject("One", 1);
            Assert.AreEqual(1, this.Evaluate("One"));
        }

        [TestMethod]
        public void EvaluateAssignment()
        {
            this.Evaluate("One := 1");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateAssignmentAndGlobal()
        {
            Assert.AreEqual(1, this.Evaluate("One := 1. One"));
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateTwoAssignments()
        {
            this.Evaluate("One := 1. Two := 2");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
            Assert.AreEqual(2, this.machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void CreateDotNetFileInfo()
        {
            object result = this.Evaluate("@System.IO.FileInfo !new: 'afile.txt'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.IO.FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("afile.txt", fileinfo.Name);
        }

        [TestMethod]
        public void CreateDotNetObject()
        {
            object result = this.Evaluate("@System.Object new");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(object));
        }

        [TestMethod]
        public void GetDotNetObjectType()
        {
            object result = this.Evaluate("@System.Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Type));
            Assert.AreSame(result, typeof(object));
        }

        [TestMethod]
        public void MakeDotNetObjectArrayType()
        {
            object result = this.Evaluate("@System.Object !GetType !MakeArrayType");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Type));
        }

        [TestMethod]
        public void MakeDotNetObjectArray()
        {
            object result = this.Evaluate("@System.Object !GetType !MakeArrayType new: 10");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(object[]));
            Assert.AreEqual(10, ((object[])result).Length);
        }

        [TestMethod]
        public void MakeByteArray()
        {
            object result = this.Evaluate("@System.Array !CreateInstance: @System.Byte with: 1024");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(byte[]));
        }

        [TestMethod]
        public void CreateDotNetObjectUsingNew()
        {
            object result = this.Evaluate("@System.IO.FileInfo new: 'afile.txt'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.IO.FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("afile.txt", fileinfo.Name);
        }

        [TestMethod]
        public void InvokeDotNetMethod()
        {
            object result = this.Evaluate("2 !toString");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void InvokeDotNetMethodWithParameters()
        {
            object result = this.Evaluate("'foobar' !substring: 1 with: 2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("oo", result);
        }

        [TestMethod]
        public void InvokeStaticDotNetMethod()
        {
            object result = this.Evaluate("@System.IO.File !exists: 'foobar'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void InvokeStaticDotNetMethodUsingMessage()
        {
            object result = this.Evaluate("@System.IO.File exists: 'foobar'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void DefineClass()
        {
            object result = this.Evaluate("nil subclass: #Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Object", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
        }

        [TestMethod]
        public void DefineClassWithInstanceClassVariablesAndCategory()
        {
            object result = this.Evaluate("nil subclass: #MyClass instanceVariableNames: 'x y' classVariableNames: 'z' poolDictionaries: '' category:'MyCategory'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("MyClass", clss.Name);
            Assert.AreEqual(2, clss.NoInstanceVariables);
            Assert.AreEqual(1, clss.MetaClass.NoInstanceVariables);
            Assert.AreEqual("MyCategory", clss.Category);
        }

        [TestMethod]
        public void DefineVariableClassWithInstanceClassVariablesAndCategory()
        {
            object result = this.Evaluate("nil variableSubclass: #MyClass instanceVariableNames: 'x y' classVariableNames: 'z' poolDictionaries: '' category:'MyCategory'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            BaseClass clss = (BaseClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.IsTrue(clss.IsIndexed);
            Assert.AreEqual("MyClass", clss.Name);
            Assert.AreEqual(2, clss.NoInstanceVariables);
            Assert.AreEqual(1, clss.MetaClass.NoInstanceVariables);
            Assert.AreEqual("MyCategory", clss.Category);
        }

        [TestMethod]
        public void DefineClassesUsingSemicolon()
        {
            Assert.IsNull(this.machine.GetGlobalObject("Class1"));
            Assert.IsNull(this.machine.GetGlobalObject("Class2"));

            object result = this.Evaluate("nil subclass: #Class1; subclass: #Class2");

            Assert.IsNotNull(this.machine.GetGlobalObject("Class1"));
            Assert.IsNotNull(this.machine.GetGlobalObject("Class2"));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Class2", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
        }

        [TestMethod]
        public void BasicNewObject()
        {
            IClass clss = (IClass)this.Evaluate("nil subclass: #Object");
            object result = this.Evaluate("Object new");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            IObject obj = (IObject)result;
            Assert.AreEqual(clss, obj.Behavior);
        }

        [TestMethod]
        public void DefineNativeBehavior()
        {
            var originalbehavior = this.machine.GetNativeBehavior(typeof(bool));
            object result = this.Evaluate("nil subclass: #MyBoolean nativeType: @System.Boolean");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NativeBehavior));

            NativeBehavior behavior = (NativeBehavior)result;

            Assert.AreEqual(typeof(bool), behavior.NativeType);

            object newobj = behavior.CreateObject();

            Assert.IsNotNull(newobj);
            Assert.IsInstanceOfType(newobj, typeof(bool));
            Assert.AreSame(originalbehavior, result);
        }

        [TestMethod]
        public void DefineAgent()
        {
            object result = this.Evaluate("nil agent: #Agent");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Agent", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
            Assert.IsInstanceOfType(clss, typeof(BaseClass));

            BaseClass baseclass = (BaseClass)clss;

            Assert.IsTrue(baseclass.IsAgentClass);
        }

        [TestMethod]
        public void CreateAgent()
        {
            object result = this.Evaluate("nil agent: #Agent. Agent new");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AgentObject));

            AgentObject agent = (AgentObject)result;

            Assert.IsInstanceOfType(agent.Behavior, typeof(IClass));

            IClass clss = (IClass)agent.Behavior;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Agent", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
            Assert.IsInstanceOfType(clss, typeof(BaseClass));

            BaseClass baseclass = (BaseClass)clss;

            Assert.IsTrue(baseclass.IsAgentClass);
        }

        [TestMethod]
        public void CreateAndInvokeAgent()
        {
            ManualResetEvent handle = new ManualResetEvent(false);
            Thread thread = null;

            object aclass = this.Evaluate("nil agent: #Agent");

            Assert.IsNotNull(aclass);
            Assert.IsInstanceOfType(aclass, typeof(IBehavior));

            IBehavior behavior = (IBehavior)aclass;

            behavior.DefineInstanceMethod(new FunctionalMethod("sethandle", null, (self, receiver, args) => { thread = Thread.CurrentThread;  return handle.Set(); }));

            object result = this.Evaluate("Agent new sethandle");

            handle.WaitOne();
            Assert.IsNull(result);
            Assert.IsNotNull(thread);
            Assert.AreNotSame(Thread.CurrentThread, thread);
        }

        [TestMethod]
        public void EvaluateFalseAsFalse()
        {
            object result = this.Evaluate("false");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void EvaluateTrueAsTrue()
        {
            object result = this.Evaluate("true");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void GetSystemConsole()
        {
            object result = this.Evaluate("@System.Console");
            Assert.AreEqual(result, typeof(System.Console));
        }

        [TestMethod]
        public void GetSystemDataDataSet()
        {
            object result = this.Evaluate("@System.Data.DataSet");
            Assert.IsInstanceOfType(result, typeof(Type));
            Assert.AreEqual("System.Data.DataSet", ((Type)result).FullName);
        }

        [TestMethod]
        public void EvaluateCollection()
        {
            object result = this.Evaluate("#(1 2 3)");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable));
            
            int k = 0;

            foreach (object v in (IEnumerable)result)
            {
                k++;
                Assert.AreEqual(k, v);
            }

            Assert.AreEqual(3, k);
        }

        [TestMethod]
        public void EvaluateHeterogeneousCollection()
        {
            object result = this.Evaluate("#(1 Symbol 'string')");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable));

            int k = 0;
            object[]values = new object[] { 1, "Symbol", "string" };

            foreach (object v in (IEnumerable)result)
            {
                Assert.AreEqual(values[k], v);
                k++;
            }

            Assert.AreEqual(3, k);
        }

        [TestMethod]
        public void EvaluateCompositeCollection()
        {
            object result = this.Evaluate("#(1 (1 2 3) 'string')");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable));

            int k = 0;
            object[] values = new object[] { 1, new object[] { 1, 2, 3 }, "string" };

            foreach (object v in (IEnumerable)result)
            {
                if (v is object[] && values[k] is object[])
                {
                    object[] a1 = (object[])v;
                    object[] a2 = (object[])values[k];

                    Assert.AreEqual(a1.Length, a2.Length);
                    for (int j = 0; j < a1.Length; j++)
                        Assert.AreEqual(a1[j], a2[j]);
                }
                else
                    Assert.AreEqual(values[k], v);

                k++;
            }

            Assert.AreEqual(3, k);
        }

        [TestMethod]
        public void EvaluateSimpleDo()
        {
            object result = this.Evaluate("sum := 0. #(1 2 3) do: [ :x | sum := x + sum ]. sum");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void EvaluateSimpleAssign()
        {
            object result = this.Evaluate("sum := 1");
            Assert.AreEqual(1, this.machine.GetGlobalObject("sum"));
        }

        [TestMethod]
        public void EvaluateSimpleSelect()
        {
            object result = this.Evaluate("#(1 2 3) select: [ :x | x > 1 ]");
            Assert.IsInstanceOfType(result, typeof(IEnumerable));
            IEnumerable elements = (IEnumerable)result;

            int k = 0;

            foreach (object element in elements)
            {
                Assert.AreEqual(k + 2, element);
                k++;
            }

            Assert.AreEqual(2, k);
        }

        [TestMethod]
        public void EvaluateSimpleAt()
        {
            object result = this.Evaluate("#(1 2 3) at: 2");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EvaluateAddTwoStrings()
        {
            object result = this.Evaluate("'foo' + 'bar'");
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("foobar", result);
        }

        [TestMethod]
        public void EvaluateAddStringToInteger()
        {
            object result = this.Evaluate("'foo' + 1");
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("foo1", result);
        }

        [TestMethod]
        public void EvaluateNilIfNil()
        {
            object result = this.Evaluate("nil ifNil: [^1]");
            Assert.IsInstanceOfType(result, typeof(int));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvaluateBlockValue()
        {
            object result = this.Evaluate("[1] value");
            Assert.IsInstanceOfType(result, typeof(int));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvaluateArraySelect()
        {
            object result = this.Evaluate("#(1 2 3) select: [ :x | x > 1]");
            Assert.IsInstanceOfType(result, typeof(IList));

            var list = (IList)result;

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void EvaluateArrayIncludes()
        {
            var result = this.Evaluate("#(1 2 3) includes: 1");
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
            result = this.Evaluate("#(1 2 3) includes: 5");
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void EvaluateIfTrue()
        {
            var result = this.Evaluate("true ifTrue: [1]");
            Assert.IsInstanceOfType(result, typeof(int));
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvaluateFalseIfTrue()
        {
            var result = this.Evaluate("false ifTrue: [1]");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EvaluateIfFalse()
        {
            var result = this.Evaluate("false ifFalse: [2]");
            Assert.IsInstanceOfType(result, typeof(int));
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EvaluateTrueIfFalse()
        {
            var result = this.Evaluate("true ifFalse: [2]");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void EvaluateTrueIfFalseIfTrue()
        {
            var result = this.Evaluate("true ifFalse: [2] ifTrue: [3]");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void EvaluateAssertWhenTrue()
        {
            var result = this.Evaluate("[1==1] assert");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertError))]
        public void RaiseWhenEvaluateAssertFails()
        {
            this.Evaluate("[1==2] assert");
        }

        [TestMethod]
        public void EvaluateStringConcatenation()
        {
            var result = this.Evaluate("'f' , 'oo'");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertError))]
        public void RaiseWhenEvaluateRaise()
        {
            this.Evaluate("@AjTalk.Exceptions.AssertError new raise");
        }

        [TestMethod]
        public void EvaluateStringConcatenationWithNil()
        {
            var result = this.Evaluate("'f' , nil");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("fnil", result);
        }

        [TestMethod]
        public void EvaluateStringConcatenationWithInteger()
        {
            var result = this.Evaluate("'f' , 4");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("f4", result);
        }

        [TestMethod]
        public void NilIsNil()
        {
            Assert.AreEqual(true, this.Evaluate("nil isNil"));
        }

        [TestMethod]
        public void IntegerToString()
        {
            Assert.AreEqual("1", this.Evaluate("a := 1. a toString"));
        }

        [TestMethod]
        public void EvaluateWhileTrue()
        {
            Assert.AreEqual(6, this.Evaluate("| sum k | sum := 0. k := 1. [k <= 3] whileTrue: [ sum := sum + k. k := k + 1]. sum"));
        }

        [TestMethod]
        public void EvaluateWhileFalse()
        {
            Assert.AreEqual(6, this.Evaluate("| sum k | sum := 0. k := 1. [k > 3] whileFalse: [ sum := sum + k. k := k + 1]. sum"));
        }

        [TestMethod]
        public void EvaluateMethodWithInternalReturn()
        {
            IClass testclass = this.machine.CreateClass("Test");
            this.machine.SetCurrentEnvironmentObject("Test", testclass);
            Parser parser = new Parser("test true ifTrue: [^1]. ^2");
            Method method = parser.CompileClassMethod(testclass);
            testclass.DefineClassMethod(method);
            Assert.AreEqual(1, this.Evaluate("Test test"));
        }

        [TestMethod]
        public void EvaluateSuperNew()
        {
            IClass testclass = this.machine.CreateClass("Test1", null, "x", string.Empty);
            this.machine.SetCurrentEnvironmentObject("Test1", testclass);
            IClass testclass2 = this.machine.CreateClass("Test2", testclass, "y", string.Empty);
            this.machine.SetCurrentEnvironmentObject("Test2", testclass2);
            VmCompiler compiler = new VmCompiler();
            testclass.DefineInstanceMethod(compiler.CompileInstanceMethod("x: value x := value", testclass));
            testclass2.DefineInstanceMethod(compiler.CompileInstanceMethod("y: value y := value", testclass2));
            testclass.DefineClassMethod(compiler.CompileClassMethod("new ^self basicNew x: 10", testclass));
            testclass2.DefineClassMethod(compiler.CompileClassMethod("new ^super new y: 20", testclass2));
            var result = this.Evaluate("Test2 new");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));
            var iobj = (IObject)result;
            Assert.AreEqual(10, iobj[0]);
            Assert.AreEqual(20, iobj[1]);
        }

        private object Evaluate(string text)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(this.machine, null);
        }

        private object Evaluate(string text, Machine machine)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(machine, null);
        }
    }
}

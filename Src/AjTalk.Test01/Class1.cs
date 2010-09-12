namespace AjTalk.Test01
{
    using System;

    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Language;

	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
			Machine machine = new Machine();
			IClass cls = machine.CreateClass("Point");
			cls.DefineInstanceVariable("x");
			cls.DefineInstanceVariable("y");
			IObject obj = (IObject) cls.NewObject();
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			obj[0]=0;
			obj[1]=1;
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();
			Method mth = new Method(cls,"set:");
			mth.CompileArgument("newValue");
			mth.CompileGet("newValue");
			mth.CompileSet("x");
			mth.CompileGet("newValue");
			mth.CompileSet("y");
			mth.Execute(obj.Behavior,obj,new object[] {10});
			cls.DefineInstanceMethod(mth);
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();
			mth = new Method(cls,"x:y:");
			mth.CompileArgument("newX");
			mth.CompileArgument("newY");
			mth.CompileGet("newX");
			mth.CompileSet("x");
			mth.CompileGet("newY");
			mth.CompileSet("y");
			mth.Execute(obj.Behavior,obj,new object[] {10,20});
			cls.DefineInstanceMethod(mth);
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();

			mth = new Method(cls,"x:");
			mth.CompileArgument("newX");
			mth.CompileGet("newX");
			mth.CompileSet("x");
			mth.Execute(obj.Behavior,obj,new object[] {10,20});
			cls.DefineInstanceMethod(mth);

			mth = new Method(cls,"y:");
			mth.CompileArgument("newY");
			mth.CompileGet("newY");
			mth.CompileSet("y");
			mth.Execute(obj.Behavior,obj,new object[] {10,20});
			cls.DefineInstanceMethod(mth);

			Parser compiler = new Parser("set2: newValue self x: newValue self y: newValue.");
			compiler.CompileInstanceMethod(cls);

			compiler = new Parser("x ^x.");
			compiler.CompileInstanceMethod(cls);

			compiler = new Parser("y ^y.");
			compiler.CompileInstanceMethod(cls);

			compiler = new Parser("x1 ^x+1.");
			compiler.CompileInstanceMethod(cls);

			compiler = new Parser("y1 ^y+1.");
			compiler.CompileInstanceMethod(cls);

			obj.SendMessage("set2:", new object[] { 10 });
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();

			obj.SendMessage("x:", new object[] { 30 });
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();

			obj.SendMessage("y:", new object[] { 20 });
			Console.WriteLine(obj[0]);
			Console.WriteLine(obj[1]);
			Console.ReadLine();

			Console.WriteLine(obj.SendMessage("x", null));
			Console.WriteLine(obj.SendMessage("y", null));
			Console.ReadLine();
		}
	}
}

namespace AjTalk.Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Remoting.Lifetime;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Compilers.Vm;
    using AjTalk.Language;

    public class Program
    {
        public static void Main(string[] args)
        {
            //// According http://msdn.microsoft.com/en-us/magazine/cc300474.aspx
            LifetimeServices.LeaseTime = TimeSpan.FromMinutes(10);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromMinutes(15);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromMinutes(1);

            Machine machine = null;

            string imageloadname = GetImageFileName(args);

            if (imageloadname != null)
            {
                var stream = File.Open(imageloadname, FileMode.Open);
                var reader = new BinaryReader(stream);
                ImageSerializer serializer = new ImageSerializer(reader, null);
                machine = (Machine)serializer.Deserialize();
                Machine.SetCurrent(machine);
                reader.Close();

                object pgm = machine.GetGlobalObject("Program");

                if (pgm != null)
                {
                    IBehavior program = (IBehavior)pgm;
                    machine.SendMessage(program, "main", null);
                    return;
                }
            }
            else
                machine = new Machine();

            foreach (string arg in GetFileNames(args))
            {
                Loader ldr = new Loader(arg, new VmCompiler());
                try
                {
                    ldr.LoadAndExecute(machine);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex.Message);
                    System.Console.Error.WriteLine(ex.StackTrace);
                }
            }

            string imagesavename = GetOption("save", "s", args);

            if (imagesavename != null)
            {
                var stream = File.Open(imagesavename, FileMode.Create);
                var writer = new BinaryWriter(stream);
                ImageSerializer serializer = new ImageSerializer(writer);
                serializer.Serialize(machine);
                writer.Close();
                return;
            }

            Loader loader = new Loader(System.Console.In, new VmCompiler());

            while (true)
            {
                try
                {
                    loader.LoadAndExecute(machine);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex.Message);
                    System.Console.Error.WriteLine(ex.StackTrace);
                }
            }
        }

        private static string GetOption(string optionname, string shortname, string[] args)
        {
            string argument = "--" + optionname;
            string shortargument = "-" + shortname;

            for (int k = 0; k < args.Length; k++)
                if (args[k] == argument || args[k] == shortargument)
                    return args[k + 1];

            return null;
        }

        private static IEnumerable<string> GetFileNames(string[] args)
        {
            for (int k = 0; k < args.Length; k++)
            {
                string arg = args[k];

                if (arg[0] == '-')
                {
                    k++;
                    continue;
                }

                if (!arg.EndsWith(".st"))
                    continue;

                yield return arg;
            }
        }

        private static string GetImageFileName(string[] args)
        {
            for (int k = 0; k < args.Length; k++)
            {
                string arg = args[k];

                if (arg[0] == '-')
                {
                    k++;
                    continue;
                }

                if (!arg.EndsWith(".im"))
                    continue;

                return arg;
            }

            return null;
        }
    }
}

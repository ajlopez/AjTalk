namespace AjTalk.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Lifetime;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Compilers.Vm;

    public class Program
    {
        public static void Main(string[] args)
        {
            //// According http://msdn.microsoft.com/en-us/magazine/cc300474.aspx
            LifetimeServices.LeaseTime = TimeSpan.FromMinutes(10);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromMinutes(15);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromMinutes(1);

            Machine machine = new Machine();

            foreach (string arg in args)
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
    }
}

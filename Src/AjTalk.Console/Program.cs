using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Lifetime;

namespace AjTalk.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // According http://msdn.microsoft.com/en-us/magazine/cc300474.aspx
            LifetimeServices.LeaseTime = TimeSpan.FromMinutes(10);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromMinutes(15);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromMinutes(1);

            Machine machine = new Machine();

            foreach (string arg in args)
            {
                Loader ldr = new Loader(arg);
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

            Loader loader = new Loader(System.Console.In);

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

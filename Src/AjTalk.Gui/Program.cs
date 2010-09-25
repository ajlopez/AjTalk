using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AjTalk.Gui
{
    static class Program
    {
        private const string BootFile = "Boot.st";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Machine machine = new Machine();

            if (File.Exists(BootFile))
            {
                Loader loader = new Loader(BootFile);
                loader.LoadAndExecute(machine);
            }

            Application.Run(new Browser(machine));
        }
    }
}

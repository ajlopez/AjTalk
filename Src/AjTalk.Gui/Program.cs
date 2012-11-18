namespace AjTalk.Gui
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public static class Program
    {
        private const string BootFile = "Boot.st";

        [STAThread]
        public static void Main()
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

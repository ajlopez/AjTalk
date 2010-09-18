using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AjTalk.Gui
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Machine machine = new Machine();
            Application.Run(new Transcript(machine));
        }
    }
}

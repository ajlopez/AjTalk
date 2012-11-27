namespace AjTalk.Gui
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using AjTalk.Compiler;
    using AjTalk.Language;

    public partial class Browser : Form
    {
        private Machine machine;
        private IClass currentClass;

        public Browser(Machine machine)
        {
            this.InitializeComponent();

            this.SetMachine(machine);
        }

        private void SetMachine(Machine machine)
        {
            this.machine = machine;
            this.lstClasses.Items.Clear();
            this.lstMethods.Items.Clear();

            foreach (IClass cls in machine.GetClasses())
                this.lstClasses.Items.Add(cls.Name);
        }

        private void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtText.Text = string.Empty;
            this.lstMethods.Items.Clear();

            if (this.lstClasses.SelectedItem == null)
                return;

            string clsname = (string)this.lstClasses.SelectedItem;
            this.currentClass = (IClass)this.machine.GetGlobalObject(clsname);

            foreach (IMethod method in this.currentClass.GetInstanceMethods())
                this.lstMethods.Items.Add(method.Name);

            if (this.currentClass is BaseClass)
                this.txtText.Text = ((BaseClass)this.currentClass).ToDefineString();
        }

        private void lstMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMethods.SelectedItem == null)
            {
                this.txtText.Text = string.Empty;
                return;
            }

            string mthname = (string)this.lstMethods.SelectedItem;
            IMethod method = this.currentClass.GetInstanceMethod(mthname);

            this.txtText.Text = this.GetMethodSource(method);
        }

        private string GetMethodSource(IMethod method)
        {
            if (method == null || method.SourceCode == null)
                return string.Empty;

            if (method.SourceCode.Contains("\r\n"))
                return method.SourceCode;

            return method.SourceCode.Replace("\n", "\r\n");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFileOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openDialog.ShowDialog() != DialogResult.OK)
                return;

            string filename = this.openDialog.FileName;

            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(this.machine);
            this.SetMachine(this.machine);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AjTalk.Language;

namespace AjTalk.Gui
{
    public partial class Browser : Form
    {
        private Machine machine;
        private IClass currentClass;

        public Browser(Machine machine)
        {
            InitializeComponent();

            this.machine = machine;
            //panel1.Dock = DockStyle.Fill;

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
            this.currentClass = (IClass) this.machine.GetGlobalObject(clsname);

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

            this.txtText.Text = method.SourceCode ?? string.Empty;
        }
    }
}

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

namespace AjTalk.Gui
{
    public partial class Transcript : Form
    {
        private Machine machine;

        public Transcript(Machine machine)
        {
            InitializeComponent();
            this.machine = machine;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                this.DoIt();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DoIt()
        {
            if (String.IsNullOrEmpty(txtInput.SelectedText))
                return;

            string text = txtInput.SelectedText;
            Parser parser = new Parser(text);

            try
            {
                Block block = parser.CompileBlock();
                object result = block.Execute(machine, null);
                if (result != null)
                    MessageBox.Show(result.ToString(), "Result");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

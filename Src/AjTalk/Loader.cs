namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using AjTalk.Compiler;

    public class Loader
    {
        private TextReader reader;
        private IClass currentClass;
        private string inmediateLine;

        public Loader(TextReader reader)
        {
            this.reader = reader;
        }

        public Loader(string filename)
        {
            this.reader = new StreamReader(filename);
        }

        public bool IsInmediate()
        {
            return this.inmediateLine != null;
        }

        public bool IsMethod()
        {
            return this.currentClass != null;
        }

        public void ExecuteInmediate(Machine machine)
        {
            this.inmediateLine = this.inmediateLine.Trim();

            if (this.inmediateLine.Length == 0)
            {
                this.currentClass = null;
                return;
            }

            if (!this.inmediateLine.EndsWith(" methods"))
            {
                throw new InvalidOperationException(string.Format("Unknown inmediate line '{0}'", this.inmediateLine));
            }

            this.inmediateLine = "^" + this.inmediateLine.Substring(0, this.inmediateLine.Length - 8);

            Parser compiler = new Parser(this.inmediateLine);
            Block block = compiler.CompileBlock();
            object value = block.Execute(machine, null);

            this.currentClass = (IClass)value;
        }

        public string GetInmediateText()
        {
            return this.inmediateLine;
        }

        public string GetBlockText()
        {
            this.inmediateLine = null;

            StringBuilder sb = new StringBuilder();

            string line = this.reader.ReadLine();

            while (line != null)
            {
                if (line.Length > 0 && line[0] == '!')
                {
                    break;
                }

                sb.Append(line);
                sb.Append("\n");

                line = this.reader.ReadLine();
            }

            if (line != null && line.Length > 1 && line.EndsWith("!"))
            {
                this.inmediateLine = line.Substring(1, line.Length - 2);
            }

            if (sb.Length == 0)
            {
                return null;
            }

            return sb.ToString();
        }

        public void LoadAndExecute(Machine machine)
        {
            string blocktext;

            blocktext = this.GetBlockText();

            while (blocktext != null)
            {
                Parser compiler = new Parser(blocktext);

                if (this.IsMethod())
                {
                    compiler.CompileInstanceMethod(this.currentClass);
                }
                else
                {
                    Block block = compiler.CompileBlock();
                    block.Execute(machine, null);
                }

                if (this.IsInmediate())
                {
                    this.ExecuteInmediate(machine);
                }

                blocktext = this.GetBlockText();
            }

            this.reader.Close();
            this.reader = null;
        }
    }
}

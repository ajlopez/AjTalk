using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AjTalk
{
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
            return inmediateLine != null;
        }

        public bool IsMethod()
        {
            return currentClass != null;
        }

        public void ExecuteInmediate(Machine machine)
        {
            inmediateLine = inmediateLine.Trim();

            if (inmediateLine.Length == 0)
            {
                currentClass = null;
                return;
            }

            if (!inmediateLine.EndsWith(" methods"))
            {
                throw new InvalidOperationException(string.Format("Unknown inmediate line '{0}'", inmediateLine));
            }

            inmediateLine = "^" + inmediateLine.Substring(0, inmediateLine.Length - 8);

            Compiler compiler = new Compiler(inmediateLine);
            Block block = compiler.CompileBlock();
            object value = block.Execute(machine, null);

            currentClass = (IClass)value;
        }

        public string GetInmediateText()
        {
            return this.inmediateLine;
        }

        public string GetBlockText()
        {
            inmediateLine = null;

            StringBuilder sb = new StringBuilder();

            string line = reader.ReadLine();

            while (line != null)
            {
                if (line.Length>0 && line[0] == '!')
                    break;

                sb.Append(line);
                sb.Append("\n");

                line = reader.ReadLine();
            }

            if (line != null && line.Length > 1 && line.EndsWith("!"))
            {
                inmediateLine = line.Substring(1, line.Length - 2);
            }

            if (sb.Length == 0)
                return null;

            return sb.ToString();
        }

        public void LoadAndExecute(Machine machine)
        {
            string blocktext;

            blocktext = GetBlockText();

            while (blocktext != null)
            {
                Compiler compiler = new Compiler(blocktext);

                if (IsMethod())
                {
                    compiler.CompileInstanceMethod(currentClass);
                }
                else
                {
                    Block block = compiler.CompileBlock();
                    block.Execute(machine, null);
                }

                if (IsInmediate())
                    ExecuteInmediate(machine);

                blocktext = GetBlockText();
            }

            reader.Close();
            reader = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AjTalk
{
    public class Loader
    {
        private TextReader reader;

        public Loader(TextReader reader)
        {
            this.reader = reader;
        }

        public Loader(string filename)
        {
            this.reader = new StreamReader(filename);
        }

        public string GetBlockText()
        {
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
                Block block = compiler.CompileBlock();
                block.Execute(machine, null);

                blocktext = GetBlockText();
            }

            reader.Close();
            reader = null;
        }
    }
}

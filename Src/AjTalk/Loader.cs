namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using AjTalk.Compiler;
    using AjTalk.Language;

    public class Loader
    {
        private ChunkReader reader;
        private IBehavior currentClass;

        public Loader(TextReader reader)
        {
            this.reader = new ChunkReader(reader);
        }

        public Loader(string filename)
        {
            this.reader = new ChunkReader(filename);
        }

        public bool IsMethod()
        {
            return this.currentClass != null;
        }

        public string GetBlockText()
        {
            return this.reader.GetChunk();
        }

        public void LoadAndExecute(Machine machine)
        {
            string blocktext;

            blocktext = this.GetBlockText();

            while (blocktext != null)
            {
                string trimmed = blocktext.Trim();

                if (trimmed.StartsWith("!"))
                    trimmed = trimmed.Substring(1);

                if (String.IsNullOrEmpty(trimmed))
                {
                    this.currentClass = null;
                    blocktext = this.GetBlockText();
                    continue;
                }

                if (trimmed.EndsWith(" methods"))
                {
                    blocktext = "^" + trimmed.Substring(0, trimmed.Length - 8);
                    Parser compiler = new Parser(blocktext);
                    Block block = compiler.CompileBlock();
                    object value = block.Execute(machine, null);

                    this.currentClass = (IBehavior)value;

                    blocktext = this.GetBlockText();
                    continue;
                }

                Parser parser = new Parser(blocktext);

                if (this.IsMethod())
                {
                    parser.CompileInstanceMethod(this.currentClass);
                }
                else
                {
                    Block block = parser.CompileBlock();
                    block.Execute(machine, null);
                }

                blocktext = this.GetBlockText();
            }

            this.reader.Close();
            this.reader = null;
        }
    }
}

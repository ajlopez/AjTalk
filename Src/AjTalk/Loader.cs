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
        private bool isclassmethod;
        private ICompiler compiler;

        public Loader(TextReader reader, ICompiler compiler)
        {
            this.reader = new ChunkReader(reader);
            this.compiler = compiler;
        }

        public Loader(string filename, ICompiler compiler)
        {
            this.reader = new ChunkReader(filename);
            this.compiler = compiler;
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
                    if (trimmed.EndsWith(" class methods"))
                    {
                        this.isclassmethod = true;
                        blocktext = "^" + trimmed.Substring(0, trimmed.Length - 14);
                    }
                    else
                    {
                        this.isclassmethod = false;
                        blocktext = "^" + trimmed.Substring(0, trimmed.Length - 8);
                    }

                    Block block = this.compiler.CompileBlock(blocktext);
                    object value = block.Execute(machine, null);

                    this.currentClass = (IBehavior)value;

                    blocktext = this.GetBlockText();
                    continue;
                }

                if (this.IsMethod())
                {
                    if (this.isclassmethod)
                        this.currentClass.DefineClassMethod(this.compiler.CompileClassMethod(blocktext, this.currentClass));
                    else
                        this.currentClass.DefineInstanceMethod(this.compiler.CompileInstanceMethod(blocktext, this.currentClass));
                }
                else
                {
                    Block block = this.compiler.CompileBlock(blocktext);
                    block.Execute(machine, null);
                }

                blocktext = this.GetBlockText();
            }

            this.reader.Close();
            this.reader = null;
        }
    }
}

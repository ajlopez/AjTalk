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
                bool isprocessor = false;

                string trimmed = blocktext.Trim();

                if (trimmed.StartsWith("!"))
                {
                    trimmed = trimmed.Substring(1);
                    isprocessor = true;
                }

                if (String.IsNullOrEmpty(trimmed))
                {
                    blocktext = this.GetBlockText();
                    continue;
                }

                Block block = this.compiler.CompileBlock(trimmed);
                var value = block.FullExecute(machine, null);

                if (isprocessor)
                    ((ChunkReaderProcessor)value).Process(this.reader, machine, this.compiler);

                blocktext = this.GetBlockText();
            }

            this.reader.Close();
            this.reader = null;
        }
    }
}

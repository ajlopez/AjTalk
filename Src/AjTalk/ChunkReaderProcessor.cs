namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class ChunkReaderProcessor
    {
        private Action<Machine, ICompiler, string> process;
        private int count;

        public ChunkReaderProcessor(Action<Machine, ICompiler, string> process)
            : this(process, 0)
        {
        }

        public ChunkReaderProcessor(Action<Machine, ICompiler, string> process, int count)
        {
            this.process = process;
            this.count = count;
        }

        public void Process(ChunkReader reader, Machine machine, ICompiler compiler)
        {
            if (this.count > 0) 
                for (int k = 0; k < this.count; k++)
                    this.process(machine, compiler, reader.GetChunk());
            else
                for (string text = reader.GetChunk(); text != null; text = reader.GetChunk())
                    if (string.IsNullOrEmpty(text.Trim()))
                        return;
                    else
                        this.process(machine, compiler, text);
        }
    }
}

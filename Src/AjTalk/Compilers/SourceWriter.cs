namespace AjTalk.Compilers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SourceWriter
    {
        private TextWriter writer;
        private int indent;
        private bool isNewLine;

        public SourceWriter(TextWriter writer)
        {
            this.writer = writer;
            this.indent = 0;
            this.isNewLine = true;
        }

        public void Write(string text)
        {
            this.WriteIndent();
            this.writer.Write(text);
            this.isNewLine = false;
        }

        public void WriteLine()
        {
            this.WriteIndent();
            this.writer.WriteLine();
            this.isNewLine = true;
        }

        public void WriteLine(string text)
        {
            this.WriteIndent();
            this.writer.WriteLine(text);
            this.isNewLine = true;
        }

        public void WriteLineStart(string text)
        {
            this.WriteLine(text);
            this.indent++;
        }

        public void WriteLineEnd(string text)
        {
            if (!this.isNewLine)
                this.WriteLine();
            this.indent--;
            this.WriteLine(text);
        }

        private void WriteIndent()
        {
            if (!this.isNewLine)
                return;
            this.isNewLine = false;
            for (int k = 0; k < this.indent * 4; k++)
                this.writer.Write(" ");
        }
    }
}


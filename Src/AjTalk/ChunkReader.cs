namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ChunkReader
    {
        private TextReader reader;

        public ChunkReader(TextReader reader)
        {
            this.reader = reader;
        }

        public ChunkReader(string filename)
        {
            this.reader = new StreamReader(filename);
        }

        public string GetChunk()
        {
            TextWriter writer = new StringWriter();

            char lastch = (char)0;
            int ch = this.reader.Read();

            if (ch == -1)
            {
                this.reader.Close();
                return null;
            }

            while (ch != -1)
            {
                if (ch == '!')
                {
                    if (this.reader.Peek() != '!')
                    {
                        if (lastch != 0)
                            break;
                    }
                    else
                        this.reader.Read();

                    writer.Write('!');
                    lastch = (char)ch;
                    ch = this.reader.Read();
                    continue;
                }

                if (ch == '\n' && lastch != '\r')
                    writer.Write('\r');

                writer.Write((char)ch);
                lastch = (char)ch;
                ch = this.reader.Read();
            }

            if (ch != -1)
                while (this.reader.Peek() == '\r' || this.reader.Peek() == '\n')
                    this.reader.Read();

            writer.Close();
            return writer.ToString();
        }

        public void Close()
        {
            this.reader.Close();
        }
    }
}

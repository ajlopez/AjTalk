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
        private TextReader reader;
        private IClassDescription currentClass;

        public Loader(TextReader reader)
        {
            this.reader = reader;
        }

        public Loader(string filename)
        {
            this.reader = new StreamReader(filename);
        }

        public bool IsMethod()
        {
            return this.currentClass != null;
        }

        public string GetBlockText()
        {
            TextWriter writer = new StringWriter();

            char lastch = (char) 0;
            int ch = this.reader.Read();

            if (ch == -1)
                return null;

            while (ch != -1)
            {
                if (ch == '!')
                {
                    if (this.reader.Peek() != '!')
                        break;
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
                if (this.reader.Peek() == '\r')
                {
                    this.reader.Read();
                    if (this.reader.Peek() == '\n')
                        this.reader.Read();
                }
                else if (this.reader.Peek() == '\n')
                    this.reader.Read();

            writer.Close();
            return writer.ToString();
        }

        public void LoadAndExecute(Machine machine)
        {
            string blocktext;

            blocktext = this.GetBlockText();

            while (blocktext != null)
            {
                string trimmed = blocktext.Trim();

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

                    this.currentClass = (IClassDescription)value;

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

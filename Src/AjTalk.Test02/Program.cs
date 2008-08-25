using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AjTalk.Test02
{
    class Program
    {
        static Machine machine;

        static IClass cls;
        static Dictionary<string, IObject> objects = new Dictionary<string, IObject>();

        static void Main(string[] args)
        {
            machine = new Machine();

            foreach (string filename in args)
                ProcessFile(filename);

            Console.ReadLine();
        }

        private static void ProcessFile(string filename)
        {
            StreamReader reader = File.OpenText(filename);
            ProcessStream(reader);
            reader.Close();
        }

        private static void ProcessStream(StreamReader reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                string [] words = line.Split(' ');

                if (words.Length>0)
                    ProcessLine(words,reader);

                line = reader.ReadLine();
            }
        }

        private static void ProcessLine(string [] words, StreamReader reader)
        {
            if (words[0].Length == 0)
                return;

            Console.WriteLine(words[0]);

            if (words[0] == "class")
            {
                if (words.Length > 2)
                    cls = new BaseClass(words[1], (IClass) objects[words[2]], machine);
                else
                    cls = new BaseClass(words[1], machine);

                objects[words[1]]=cls;
            }
            else if (words[0] == "variables")
            {
                for (int k = 1; k < words.Length; k++)
                    cls.DefineInstanceVariable(words[k]);
            }
            else if (words[0] == "method")
            {
                string line;
                string body = "";

                line = reader.ReadLine();

                while (line != null && line != "")
                {
                    body += line;
                    body += " ";
                    line = reader.ReadLine();
                }

                Compiler compiler = new Compiler(body);
                compiler.CompileMethod(cls);
            }
            else
                Console.WriteLine("Unknown {0}", words[0]);
        }
    }
}

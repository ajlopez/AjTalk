using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AjTalk.Compilers;
using AjTalk.Compilers.Javascript;
using AjTalk.Model;

namespace AjTalk.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter swriter = new StreamWriter(GetOutputFileName(args));
            SourceWriter writer = new SourceWriter(swriter);
            CodeModel model = new CodeModel();
            Compilers.Javascript.Compiler compiler = null;

            string target = GetTarget(args);

            if (target == "node")
                compiler = new NodeCompiler(writer);
            else if (target == "browser")
                compiler = new BrowserCompiler(writer);
            else if (target == "vm")
                compiler = new VirtualMachineCompiler(writer);
            else
                throw new ArgumentException("Invalid target");

            foreach (string filename in GetFileNames(args))
            {
                ChunkReader chunkReader = new ChunkReader(filename);
                CodeReader reader = new CodeReader(chunkReader);

                reader.Process(model);
            }

            compiler.Visit(model);

            swriter.Close();
        }

        static string GetOutputFileName(string[] args)
        {
            string filename = null;

            foreach (string arg in args)
                if (arg.EndsWith(".js"))
                {
                    if (filename != null)
                    {
                        throw new ArgumentException("Only one .js file should be specified as parameter");
                    }

                    filename = arg;
                }

            if (filename == null)
                return "Program.js";

            return filename;
        }

        static string GetTarget(string[] args)
        {
            string target = GetOption("target", args);

            if (target == null)
                return "node";

            return target;
        }

        static string GetOption(string optionname, string[] args)
        {
            string argument = "-" + optionname;

            for (int k = 0; k < args.Length; k++)
                if (args[k] == argument)
                    return args[k + 1];

            return null;
        }

        static IEnumerable<string> GetFileNames(string[] args)
        {
            for (int k = 0; k < args.Length; k++)
            {
                string arg = args[k];

                if (arg[0] == '-')
                {
                    k++;
                    continue;
                }

                if (arg.EndsWith(".js"))
                    continue;

                yield return arg;
            }
        }
    }
}

﻿using System;
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
            StreamWriter swriter = new StreamWriter("Program.js");
            SourceWriter writer = new SourceWriter(swriter);
            writer.WriteLineStart("AjTalk = function() {");
            CodeModel model = new CodeModel();
            AjTalk.Compilers.Javascript.Compiler compiler = new AjTalk.Compilers.Javascript.Compiler(writer);

            foreach (string filename in args)
            {
                ChunkReader chunkReader = new ChunkReader(filename);
                CodeReader reader = new CodeReader(chunkReader);

                reader.Process(model);
            }

            compiler.Visit(model);

            writer.WriteLineEnd("}");
            swriter.Close();
        }
    }
}
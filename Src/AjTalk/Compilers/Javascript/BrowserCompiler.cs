namespace AjTalk.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public class BrowserCompiler : Compiler
    {
        public BrowserCompiler(SourceWriter writer)
            : base(writer)
        {
        }

        public override void Visit(CodeModel model)
        {
            // TODO Review browser dependent preface code
            this.WriteLine("AjTalk = function() {");
            this.WriteLine("var send = base.send;");
            this.WriteLine("var sendSuper = base.sendSuper;");

            base.Visit(model);

            this.WriteLine();

            int n = 0;

            this.WriteLineStart("return {");

            foreach (var element in model.Elements)
            {
                if (!(element is ClassModel))
                    continue;

                if (n > 0)
                    this.WriteLine(",");

                this.Write(string.Format("{0} : {0}", ((ClassModel)element).Name));
                n++;
            }

            this.WriteLine("");
            this.WriteLineEnd("}");

            this.WriteLine("}();");
        }
    }
}

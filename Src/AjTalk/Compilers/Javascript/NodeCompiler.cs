namespace AjTalk.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public class NodeCompiler : Compiler
    {
        public NodeCompiler(SourceWriter writer)
            : base(writer)
        {
        }

        public override void Visit(CodeModel model)
        {
            // TODO Review Node.js dependent preface code
            this.WriteLine("var base = require('./js/ajtalk-base.js');");
            this.WriteLine("var send = base.send;");
            this.WriteLine("var sendSuper = base.sendSuper;");
            this.WriteLine("var primitives = require('./js/ajtalk-primitives.js');");

            base.Visit(model);
        }
    }
}

namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockDecompiler
    {
        private Block block;

        public BlockDecompiler(Block block)
        {
            this.block = block;
        }

        public IList<string> Decompile()
        {
            IList<string> codes = new List<string>();
            int nbytes = this.block.ByteCodes.Length;
            int ip = 0;

            while (ip < nbytes)
            {
                switch((ByteCode)this.block.ByteCodes[ip]) 
                {
                    case ByteCode.GetConstant:
                        ip++;
                        int nconstant = this.block.ByteCodes[ip];
                        object constant = this.block.GetConstant(nconstant);
                        if (constant is string)
                            codes.Add(string.Format("{0} \"{1}\"", ByteCode.GetConstant, constant));
                        else
                            codes.Add(string.Format("{0} {1}", ByteCode.GetConstant, constant));
                        break;

                    case ByteCode.GetLocal:
                        ip++;
                        int nlocal = this.block.ByteCodes[ip];
                        string localname = this.block.GetLocalName(nlocal);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetLocal, localname));
                        break;

                    case ByteCode.SetLocal:
                        ip++;
                        nlocal = this.block.ByteCodes[ip];
                        localname = this.block.GetLocalName(nlocal);
                        codes.Add(string.Format("{0} {1}", ByteCode.SetLocal, localname));
                        break;

                    case ByteCode.GetArgument:
                        ip++;
                        int nargument = this.block.ByteCodes[ip];
                        string argname = this.block.GetArgumentName(nargument);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetArgument, argname));
                        break;

                    case ByteCode.GetGlobalVariable:
                        ip++;
                        int nglobal = this.block.ByteCodes[ip];
                        string globalname = this.block.GetGlobalName(nglobal);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetGlobalVariable, globalname));
                        break;

                    case ByteCode.SetGlobalVariable:
                        ip++;
                        nglobal = this.block.ByteCodes[ip];
                        globalname = this.block.GetGlobalName(nglobal);
                        codes.Add(string.Format("{0} {1}", ByteCode.SetGlobalVariable, globalname));
                        break;

                    case ByteCode.Send:
                        ip++;
                        nconstant = this.block.ByteCodes[ip];
                        string selector = (string)this.block.GetConstant(nconstant);
                        ip++;
                        int arity = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1} {2}", ByteCode.Send, selector, arity));
                        break;

                    case ByteCode.ReturnPop:
                        codes.Add(string.Format("{0}", ByteCode.ReturnPop));
                        break;
                }

                ip++;
            }

            return codes;
        }
    }
}

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
                }

                ip++;
            }

            return codes;
        }
    }
}

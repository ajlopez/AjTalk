﻿namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class BlockDecompiler
    {
        private Block block;

        public BlockDecompiler(Block block)
        {
            this.block = block;
        }

        public string DecompileAsString()
        {
            StringBuilder builder = new StringBuilder("{ ");
            int nlines = 0;
            var lines = this.Decompile();

            foreach (var line in lines)
            {
                if (nlines > 0)
                    builder.Append("; ");

                builder.Append(line);
                nlines++;
            }

            builder.Append(" }");

            return builder.ToString();
        }

        public IList<string> Decompile()
        {
            IList<string> codes = new List<string>();
            int nbytes = this.block.ByteCodes.Length;
            int ip = 0;

            while (ip < nbytes)
            {
                ByteCode bc = (ByteCode)this.block.ByteCodes[ip];

                switch (bc)
                {
                    case ByteCode.GetConstant:
                        ip++;
                        int nconstant = this.block.ByteCodes[ip];
                        object constant = this.block.GetConstant(nconstant);
                        if (constant is string)
                            codes.Add(string.Format("{0} \"{1}\"", ByteCode.GetConstant, constant));
                        else
                            codes.Add(string.Format("{0} {1}", ByteCode.GetConstant, Convert.ToString(constant, CultureInfo.InvariantCulture)));
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

                    case ByteCode.SetArgument:
                        ip++;
                        nargument = this.block.ByteCodes[ip];
                        argname = this.block.GetArgumentName(nargument);
                        codes.Add(string.Format("{0} {1}", ByteCode.SetArgument, argname));
                        break;

                    case ByteCode.GetGlobalVariable:
                        ip++;
                        int nglobal = this.block.ByteCodes[ip];
                        string globalname = this.block.GetGlobalName(nglobal);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetGlobalVariable, globalname));
                        break;

                    case ByteCode.GetDotNetType:
                        ip++;
                        nglobal = this.block.ByteCodes[ip];
                        globalname = this.block.GetGlobalName(nglobal);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetDotNetType, globalname));
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

                    case ByteCode.MultiValue:
                        ip++;
                        arity = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1}", ByteCode.MultiValue, arity));
                        break;

                    case ByteCode.GetBlock:
                        ip++;
                        nconstant = this.block.ByteCodes[ip];
                        Block newblock = (Block)this.block.GetConstant(nconstant);
                        BlockDecompiler newdecompiler = new BlockDecompiler(newblock);
                        codes.Add(string.Format("{0} {1}", ByteCode.GetBlock, newdecompiler.DecompileAsString()));
                        break;

                    case ByteCode.ReturnPop:
                    case ByteCode.ChainedSend:
                    case ByteCode.GetSelf:
                    case ByteCode.GetSuper:
                    case ByteCode.Value:
                    case ByteCode.Pop:
                    case ByteCode.GetNil:
                        codes.Add(string.Format("{0}", bc));
                        break;

                    case ByteCode.Jump:
                    case ByteCode.JumpIfFalse:
                    case ByteCode.JumpIfTrue:
                        ip++;
                        int jump = this.block.ByteCodes[ip];
                        ip++;
                        jump = (jump * 256) + this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1}", bc, jump));
                        break;

                    case ByteCode.MakeCollection:
                        ip++;
                        int nelements = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1}", ByteCode.MakeCollection, nelements));
                        break;

                    case ByteCode.GetInstanceVariable:
                    case ByteCode.SetInstanceVariable:
                        int nvariable = this.block.ByteCodes[ip + 1];
                        codes.Add(string.Format("{0} {1}", (ByteCode)this.block.ByteCodes[ip], this.block.GetInstanceVariableName(nvariable)));
                        ip++;
                        break;

                    case ByteCode.GetClassVariable:
                    case ByteCode.SetClassVariable:
                        nvariable = this.block.ByteCodes[ip + 1];
                        codes.Add(string.Format("{0} {1}", (ByteCode)this.block.ByteCodes[ip], this.block.GetClassVariableName(nvariable)));
                        ip++;
                        break;

                    case ByteCode.Primitive:
                        ip++;
                        int nprimitive = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1}", ByteCode.Primitive, nprimitive));
                        break;

                    case ByteCode.NamedPrimitive:
                        ip++;
                        nconstant = this.block.ByteCodes[ip];
                        ip++;
                        int nconstant2 = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} \"{1}\" \"{2}\"", ByteCode.NamedPrimitive, this.block.GetConstant(nconstant), this.block.GetConstant(nconstant2)));
                        break;

                    case ByteCode.PrimitiveError:
                        ip++;
                        nprimitive = this.block.ByteCodes[ip];
                        ip++;
                        nconstant = this.block.ByteCodes[ip];
                        codes.Add(string.Format("{0} {1} {2}", ByteCode.PrimitiveError, nprimitive, this.block.GetConstant(nconstant)));
                        break;
                }

                ip++;
            }

            return codes;
        }
    }
}

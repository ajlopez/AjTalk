using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Language
{
    public class LocalBlock : IBlock
    {
        private Block block;
        private IBlock parent;
        private IObject self;
        private object nativeself;

        public LocalBlock(Block block, IBlock parent, IObject self)
        {
            this.block = block;
            this.parent = parent;
            this.self = self;
        }

        public LocalBlock(Block block, IBlock parent, object nativeself)
        {
            this.block = block;
            this.parent = parent;
            this.nativeself = nativeself;
        }

        public string SourceCode { get { return this.block.SourceCode; } }

        public Block Block { get { return this.block; } }

        public object Execute(Machine machine, object[] args)
        {
            if (this.self != null)
                return (new ExecutionBlock(machine, this.self, this.block, args)).Execute();
            else
                return (new ExecutionBlock(machine, this.nativeself, this.block, args)).Execute();
        }
    }
}

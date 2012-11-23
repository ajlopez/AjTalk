﻿namespace AjTalk.Compilers.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using AjTalk.Model;

    public class BytecodeCompiler : AbstractCompiler
    {
        private Block block;

        public BytecodeCompiler(Block block)
        {
            this.block = block;
        }

        public override void Visit(ClassModel @class)
        {
            string selector = @class.IsVariable ? "variableSubclass:" : "subclass:";
            selector += "instanceVariableNames:classVariableNames:poolDictionaries:category:";

            this.block.CompileGet(@class.SuperClassName);
            this.block.CompileConstant(@class.Name);
            this.block.CompileGetConstant(@class.InstanceVariableNamesAsString);
            this.block.CompileGetConstant(@class.ClassVariableNamesAsString);
            this.block.CompileGetConstant(@class.PoolDictionariesAsString);
            this.block.CompileGetConstant(@class.Category);
            this.block.CompileSend(selector);
        }

        public override void Visit(MethodModel method)
        {
            if (method.ParameterNames != null)
                foreach (var parname in method.ParameterNames)
                    this.block.CompileArgument(parname);

            if (method.LocalVariables != null)
                foreach (var locname in method.LocalVariables)
                    this.block.CompileLocal(locname);

            this.Visit(method.Body);
        }

        public override void Visit(FreeBlockExpression block)
        {
            if (block.ParameterNames != null)
                foreach (var parname in block.ParameterNames)
                    this.block.CompileArgument(parname);

            if (block.LocalVariables != null)
                foreach (var locname in block.LocalVariables)
                    this.block.CompileLocal(locname);

            this.Visit(block.Body);
        }

        public override void Visit(IEnumerable<IExpression> expressions)
        {
            if (expressions == null)
                return;

            foreach (var expr in expressions)
                expr.Visit(this);
        }

        public override void Visit(ArrayExpression expression)
        {
            foreach (var expr in expression.Expressions)
                expr.Visit(this);

            this.block.CompileByteCode(ByteCode.MakeCollection, (byte)expression.Expressions.Count());
        }

        public override void Visit(DynamicArrayExpression expression)
        {
            foreach (var expr in expression.Expressions)
                expr.Visit(this);

            this.block.CompileByteCode(ByteCode.MakeCollection, (byte)expression.Expressions.Count());
        }

        public override void Visit(ConstantExpression expression)
        {
            if (expression.Value == null)
                this.block.CompileByteCode(ByteCode.GetNil);
            else
                this.block.CompileGetConstant(expression.Value);
        }

        public override void Visit(MessageExpression expression)
        {
            expression.Target.Visit(this);
            
            foreach (var arg in expression.Arguments)
                arg.Visit(this);

            if (expression.IsBinaryMessage)
                this.block.CompileBinarySend(expression.Selector);
            else
                this.block.CompileSend(expression.Selector);
        }

        public override void Visit(FluentMessageExpression expression)
        {
            expression.Target.Visit(this);
            this.block.CompileByteCode(ByteCode.ChainedSend);
        }

        public override void Visit(ReturnExpression expression)
        {
            expression.Expression.Visit(this);
            this.block.CompileByteCode(ByteCode.ReturnPop);
        }

        public override void Visit(SelfExpression expression)
        {
            this.block.CompileByteCode(ByteCode.GetSelf);
        }

        public override void Visit(SetExpression expression)
        {
            expression.Expression.Visit(this);
            this.block.CompileSet(expression.LeftValue.Name);
        }

        public override void Visit(VariableExpression expression)
        {
            this.block.CompileGet(expression.Name);
        }

        public override void Visit(SymbolExpression expression)
        {
            this.block.CompileGetConstant(expression.Symbol);
        }

        public override void Visit(InstanceVariableExpression expression)
        {
            // TODO check if is a get or set, if is an instance variable
            this.block.CompileGet(expression.Name);
        }

        public override void Visit(ClassVariableExpression expression)
        {
            // TODO check if is a get or set, if is an class variable
            this.block.CompileGet(expression.Name);
        }

        public override void Visit(BlockExpression expression)
        {
            Block newblock = new Block();

            if (expression.ParameterNames != null)
                foreach (var parname in expression.ParameterNames)
                    newblock.CompileArgument(parname);

            if (expression.LocalVariables != null)
                foreach (var locname in expression.LocalVariables)
                    newblock.CompileLocal(locname);

            var compiler = new BytecodeCompiler(newblock);
            compiler.Visit(expression.Body);
            this.block.CompileGetBlock(newblock);
        }

        public override void Visit(PrimitiveExpression expression)
        {
            if (!string.IsNullOrEmpty(expression.Module))
                throw new NotImplementedException();

            this.block.CompileByteCode(ByteCode.Primitive, (byte)expression.Number);
        }

        public override void Visit(CodeModel model)
        {
            foreach (var element in model.Elements)
                element.Visit(this);
        }
    }
}

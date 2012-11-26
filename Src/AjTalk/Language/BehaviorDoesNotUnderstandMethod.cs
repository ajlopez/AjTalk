namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Language;

    public class BehaviorDoesNotUnderstandMethod : DoesNotUnderstandMethod
    {
        public BehaviorDoesNotUnderstandMethod(Machine machine, IBehavior behavior)
            : base(machine, behavior)
        {
        }

        protected override object DoesNotUnderstand(IObject self, IObject receiver, string msgname, object[] args)
        {
            if (!(self is IBehavior))
                return base.DoesNotUnderstand(self, receiver, msgname, args);

            if (msgname.Equals("new"))
                return ((IBehavior)self).NewObject();

            if (msgname.StartsWith("commentStamp:"))
                return new ChunkReaderProcessor((Machine machine, ICompiler compiler, string text) => { }, 1);

            if (msgname == "methods" || msgname.StartsWith("methodsFor:"))
            {
                IBehavior behavior = (IBehavior)self;
                return new ChunkReaderProcessor((Machine machine, ICompiler compiler, string text) => {
                    behavior.DefineInstanceMethod(compiler.CompileInstanceMethod(text, behavior));
                });
            }

            if (msgname.StartsWith("new:") && self is NativeBehavior)
                return ((NativeBehavior)self).CreateObject(args);

            if (msgname.Equals("subclass:") || msgname.Equals("agent:"))
            {
                IClass newclass = this.Machine.CreateClass((string)args[0], (IClass)self);
                this.Machine.SetGlobalObject(newclass.Name, newclass);

                if (msgname.Equals("agent:"))
                    ((BaseClass)newclass).IsAgentClass = true;

                return newclass;
            }

            if (msgname.Equals("subclass:instanceVariableNames:") ||
                msgname.Equals("subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:") ||
                msgname.Equals("variableSubclass:instanceVariableNames:classVariableNames:poolDictionaries:category:") ||
                // TODO weakSubclass because Pharo Kernel Objects defines one, WeakMessageSend
                msgname.Equals("weakSubclass:instanceVariableNames:classVariableNames:poolDictionaries:category:") ||
                msgname.Equals("agent:instanceVariableNames:") ||
                msgname.Equals("agent:instanceVariableNames:classVariableNames:poolDictionaries:category:"))
            {
                string clsname = (string)args[0];
                string instancevarnames = (string)args[1];
                string classvarnames = args.Length > 2 ? (string)args[2] : string.Empty;

                IClass newclass = this.Machine.CreateClass((string)args[0], (IClass)self, instancevarnames, classvarnames);

                if (msgname.StartsWith("agent:"))
                    ((BaseClass)newclass).IsAgentClass = true;
                if (msgname.StartsWith("variableSubclass:"))
                    ((BaseClass)newclass).IsIndexed = true;
                if (args.Length >= 5)
                    ((BaseClass)newclass).Category = (string)args[4];

                this.Machine.SetGlobalObject(newclass.Name, newclass);

                return newclass;
            }

            if (msgname.Equals("subclass:nativeType:"))
            {
                Type type = (Type)args[1];
                NativeBehavior newbehavior = this.Machine.GetNativeBehavior(type);

                if (newbehavior == null)
                {
                    newbehavior = (NativeBehavior)this.Machine.CreateNativeBehavior((IClassDescription)self, type);
                    this.Machine.RegisterNativeBehavior(newbehavior.NativeType, newbehavior);
                }

                this.Machine.SetGlobalObject((string)args[0], newbehavior);
                return newbehavior;
            }

            if (msgname.Equals("instanceVariableNames:"))
            {
                string names = (string)args[0];

                if (!string.IsNullOrEmpty(names))
                    throw new NotSupportedException();

                return self;
            }

            return base.DoesNotUnderstand(self, receiver, msgname, args);
        }
    }
}

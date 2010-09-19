namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    public class BehaviorDoesNotUnderstandMethod : DoesNotUnderstandMethod
    {
        public BehaviorDoesNotUnderstandMethod(Machine machine)
            : base(machine)
        {
        }

        protected override object DoesNotUnderstand(IObject self, IObject receiver, string msgname, object[] args)
        {
            if (!(self is IBehavior))
                return base.DoesNotUnderstand(self, receiver, msgname, args);

            if (msgname.Equals("new"))
                return ((IBehavior)self).NewObject();

            if (msgname.StartsWith("new:") && self is NativeBehavior)
                return ((NativeBehavior)self).CreateObject(args);

            if (msgname.Equals("subclass:") || msgname.Equals("agent:"))
            {
                IClass newclass = this.Machine.CreateClass((string)args[0], (IClassDescription)self);
                this.Machine.SetGlobalObject(newclass.Name, newclass);

                if (msgname.Equals("agent:"))
                    ((BaseClass)newclass).IsAgentClass = true;

                return newclass;
            }

            if (msgname.Equals("subclass:instanceVariableNames:") ||
                msgname.Equals("subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:") ||
                msgname.Equals("agent:instanceVariableNames:") ||
                msgname.Equals("agent:instanceVariableNames:classVariableNames:poolDictionaries:category:"))
            {
                IClass newclass = this.Machine.CreateClass((string)args[0], (IClassDescription)self);

                if (msgname.StartsWith("agent:"))
                    ((BaseClass)newclass).IsAgentClass = true;

                string[] varnames = ((string)args[1]).Split(' ');

                foreach (string varname in varnames)
                    if (!string.IsNullOrEmpty(varname))
                        newclass.DefineInstanceVariable(varname);

                this.Machine.SetGlobalObject(newclass.Name, newclass);

                return newclass;
            }

            if (msgname.Equals("subclass:nativeType:"))
            {
                IBehavior newbehavior = this.Machine.CreateNativeBehavior((IClassDescription)self, (Type)args[1]);

                this.Machine.SetGlobalObject((string)args[0], newbehavior);
                return newbehavior;
            }

            return base.DoesNotUnderstand(self, receiver, msgname, args);
        }
    }
}

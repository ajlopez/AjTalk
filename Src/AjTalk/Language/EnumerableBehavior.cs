namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class EnumerableBehavior : NativeBehavior
    {
        public EnumerableBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(IEnumerable))
        {
            string dosource = @"
do: aBlock
    | enumerator |
    
    enumerator := self !GetEnumerator.
    
    [enumerator !MoveNext] whileTrue:
		[ aBlock value: enumerator !Current ]
            ";
            string selectsource = @"
select: aBlock
    | enumerator list |
    
    enumerator := self !GetEnumerator.
    list := @System.Collections.ArrayList !new.
    
    [enumerator !MoveNext] whileTrue:
		[ | item |
          item := enumerator !Current.
            (aBlock value: item) ifTrue:  [ list add: item ]
        ].
    ^list
            ";

            Parser parser = new Parser(dosource);
            this.DefineInstanceMethod(parser.CompileInstanceMethod(this));
            parser = new Parser(selectsource);
            this.DefineInstanceMethod(parser.CompileInstanceMethod(this));
            this.DefineInstanceMethod(new FunctionalMethod("includes:", this, this.IncludesMethod));
        }

        private object IncludesMethod(Machine machine, object obj, object[] arguments)
        {
            var list = obj as IList;
            var argument = arguments[0];

            if (list != null)
                return list.Contains(argument);

            foreach (var element in (IEnumerable)obj)
            {
                if (element == null && argument == null)
                    return true;
                if (element != null && element.Equals(argument))
                    return true;
            }

            return false;
        }
    }
}

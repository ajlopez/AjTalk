namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Language;

    public class ImageSerializer
    {
        private BinaryReader reader;
        private ICompiler compiler;
        private BinaryWriter writer;
        private List<IObject> objects = new List<IObject>();
        private Machine machine;

        public ImageSerializer(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public ImageSerializer(BinaryReader reader)
        {
            this.reader = reader;
            this.compiler = new VmCompiler();
            this.machine = Machine.Current;
        }

        private enum ImageCodes
        {
            Nil = 0,
            Integer = 1,
            String = 2,
            Object = 3,
            Reference = 4,
            Class = 5,
            Machine = 6
        }

        public void Serialize(object obj)
        {
            if (obj == null) 
            {
                this.writer.Write((byte)ImageCodes.Nil);
                return;
            }

            if (obj is int)
            {
                this.writer.Write((byte)ImageCodes.Integer);
                this.writer.Write((int)obj);
                return;
            }

            if (obj is string)
            {
                this.writer.Write((byte)ImageCodes.String);
                this.writer.Write((string)obj);
                return;
            }

            if (obj is IClass)
            {
                var klass = (IClass)obj;

                int position = this.objects.IndexOf(klass);

                if (position >= 0)
                {
                    this.writer.Write((byte)ImageCodes.Reference);
                    this.writer.Write(position);
                    return;
                }

                this.objects.Add(klass);

                this.writer.Write((byte)ImageCodes.Class);
                this.Serialize(klass.Name);
                this.Serialize(klass.Category);
                this.Serialize(klass.GetInstanceVariableNamesAsString());
                this.Serialize(klass.GetClassVariableNamesAsString());
                this.Serialize(klass.SuperClass);
                if (klass.MetaClass.SuperClass is IClass)
                    this.Serialize(klass.MetaClass.SuperClass);
                else
                    this.Serialize(null);
                var methods = klass.GetInstanceMethods();
                this.Serialize(methods.Count(mth => mth.SourceCode != null));

                foreach (var method in methods)
                    if (method.SourceCode != null)
                    {
                        this.Serialize(method.Name);
                        this.Serialize(method.SourceCode);
                    }

                var classmethods = klass.GetClassMethods();
                this.Serialize(classmethods.Count(mth => mth.SourceCode != null));

                foreach (var method in classmethods)
                    if (method.SourceCode != null)
                    {
                        this.Serialize(method.Name);
                        this.Serialize(method.SourceCode);
                    }

                return;
            }

            if (obj is IObject)
            {
                var iobj = (IObject)obj;

                int position = this.objects.IndexOf(iobj);

                if (position >= 0)
                {
                    this.writer.Write((byte)ImageCodes.Reference);
                    this.writer.Write(position);
                    return;
                }

                this.objects.Add(iobj);

                this.writer.Write((byte)ImageCodes.Object);
                this.Serialize(iobj.Behavior);
                int nvars = iobj.NoVariables;
                this.Serialize(nvars);
                for (int k = 0; k < nvars; k++)
                    this.Serialize(iobj[k]);
                return;
            }

            if (obj is Machine)
            {
                var mach = (Machine)obj;
                this.writer.Write((byte)ImageCodes.Machine);
                var names = mach.GetGlobalNames();
                int nnames = names.Count;
                this.writer.Write(nnames);

                foreach (var name in names)
                {
                    this.writer.Write(name);
                    this.Serialize(mach.GetGlobalObject(name));
                }

                return;
            }

            throw new InvalidDataException();
        }

        public object Deserialize()
        {
            byte bt = this.reader.ReadByte();

            switch ((ImageCodes)bt)
            {
                case ImageCodes.Nil:
                    return null;
                case ImageCodes.Integer:
                    return this.reader.ReadInt32();
                case ImageCodes.String:
                    return this.reader.ReadString();
                case ImageCodes.Reference:
                    return this.objects[this.reader.ReadInt32()];
                case ImageCodes.Class:
                    string name = (string)this.Deserialize();
                    string category = (string)this.Deserialize();
                    string instvarnames = (string)this.Deserialize();
                    string classvarnames = (string)this.Deserialize();
                    var klass = this.machine.CreateClass(name, null, instvarnames, classvarnames);
                    this.objects.Add(klass);
                    IClass superclass = (IClass)this.Deserialize();
                    IBehavior metaclasssuperclass = (IBehavior)this.Deserialize();
                    ((BaseClass)klass).SetSuperClass(superclass);
                    
                    // TODO Review this weird chain (See SerializeDeserializeMachineWithLibrary test)
                    if (metaclasssuperclass != null)
                        ((BaseMetaClass)klass.MetaClass).SetSuperClass(metaclasssuperclass);
                    else if (superclass != null)
                        ((BaseMetaClass)klass.MetaClass).SetSuperClass(superclass.MetaClass);

                    klass.Category = category;
                    
                    var global = this.machine.GetGlobalObject(name);

                    if (global != null)
                        klass = (IClass)global;

                    int nmethods = (int)this.Deserialize();

                    for (int k = 0; k < nmethods; k++)
                    {
                        string mthname = (string)this.Deserialize();
                        string mthsource = (string)this.Deserialize();
                        var method = this.compiler.CompileInstanceMethod(mthsource, klass);
                        klass.DefineInstanceMethod(method);
                    }

                    int nclassmethods = (int)this.Deserialize();

                    for (int k = 0; k < nclassmethods; k++)
                    {
                        string mthname = (string)this.Deserialize();
                        string mthsource = (string)this.Deserialize();
                        var method = this.compiler.CompileClassMethod(mthsource, klass);
                        klass.DefineClassMethod(method);
                    }

                    return klass;
                case ImageCodes.Object:
                    BaseObject bobj = new BaseObject();
                    this.objects.Add(bobj);
                    IBehavior behavior = (IBehavior)this.Deserialize();
                    bobj.SetBehavior(behavior);
                    int nvariables = (int)this.Deserialize();
                    if (nvariables == 0)
                        return bobj;
                    object[] variables = new object[nvariables];

                    for (int k = 0; k < nvariables; k++)
                        variables[k] = this.Deserialize();

                    bobj.SetVariables(variables);
                    return bobj;
                case ImageCodes.Machine:
                    this.machine = new Machine(false);
                    int nnames = this.reader.ReadInt32();

                    for (int k = 0; k < nnames; k++)
                    {
                        name = this.reader.ReadString();
                        object obj = this.Deserialize();
                        this.machine.SetGlobalObject(name, obj);
                    }

                    return this.machine;
            }

            throw new InvalidDataException();
        }
    }
}

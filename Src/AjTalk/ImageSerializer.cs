﻿namespace AjTalk
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
        private List<object> objects = new List<object>();
        private Machine machine;

        public ImageSerializer(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public ImageSerializer(BinaryReader reader, Machine machine)
        {
            this.reader = reader;
            this.compiler = new VmCompiler();
            this.machine = machine;
        }

        private enum ImageCode
        {
            Nil = 0,
            Integer = 1,
            String = 2,
            Object = 3,
            Reference = 4,
            Class = 5,
            Machine = 6,
            NativeBehavior = 7,
            Context = 8
        }

        public void Serialize(object obj)
        {
            if (obj == null) 
            {
                this.writer.Write((byte)ImageCode.Nil);
                return;
            }

            if (obj is int)
            {
                this.writer.Write((byte)ImageCode.Integer);
                this.writer.Write((int)obj);
                return;
            }

            int position = this.objects.IndexOf(obj);

            if (position >= 0)
            {
                this.writer.Write((byte)ImageCode.Reference);
                this.writer.Write(position);
                return;
            }

            if (obj is string)
            {
                this.writer.Write((byte)ImageCode.String);
                this.writer.Write((string)obj);
                return;
            }

            if (obj is Context)
            {
                var ctx = (Context)obj;
                this.objects.Add(ctx);
                this.writer.Write((byte)ImageCode.Context);
                var names = ctx.GetNames();
                int nnames = names.Count;

                this.writer.Write(nnames);

                foreach (var name in names)
                {
                    this.writer.Write(name);
                    this.Serialize(ctx.GetValue(name));
                }

                return;
            }

            if (obj is NativeBehavior)
            {
                var nbehavior = (NativeBehavior)obj;

                this.objects.Add(nbehavior);

                this.writer.Write((byte)ImageCode.NativeBehavior);
                this.Serialize(nbehavior.NativeType.FullName);
                this.Serialize(nbehavior.SuperClass);
                if (nbehavior.MetaClass.SuperClass is IClass)
                    this.Serialize(nbehavior.MetaClass.SuperClass);
                else
                    this.Serialize(null);
                var methods = nbehavior.GetInstanceMethods();
                this.Serialize(methods.Count(mth => mth.SourceCode != null));

                foreach (var method in methods)
                    if (method.SourceCode != null)
                    {
                        this.Serialize(method.Name);
                        this.Serialize(method.SourceCode);
                    }

                var classmethods = nbehavior.GetClassMethods();
                this.Serialize(classmethods.Count(mth => mth.SourceCode != null));

                foreach (var method in classmethods)
                    if (method.SourceCode != null)
                    {
                        this.Serialize(method.Name);
                        this.Serialize(method.SourceCode);
                    }

                return;
            }

            if (obj is IClass)
            {
                var klass = (IClass)obj;

                this.objects.Add(klass);

                this.writer.Write((byte)ImageCode.Class);
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

                this.objects.Add(iobj);

                this.writer.Write((byte)ImageCode.Object);
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
                this.objects.Add(mach);
                this.objects.Add(mach.Environment);
                this.writer.Write((byte)ImageCode.Machine);
                var names = mach.GetGlobalNames().ToList();
                
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

            switch ((ImageCode)bt)
            {
                case ImageCode.Nil:
                    return null;
                case ImageCode.Integer:
                    return this.reader.ReadInt32();
                case ImageCode.String:
                    return this.reader.ReadString();
                case ImageCode.Reference:
                    return this.objects[this.reader.ReadInt32()];
                case ImageCode.Context:
                    Context ctx = new Context();
                    this.objects.Add(ctx);
                    int nnames = this.reader.ReadInt32();

                    for (int k = 0; k < nnames; k++)
                    {
                        string valuename = this.reader.ReadString();
                        object value = this.Deserialize();
                        ctx.SetValue(valuename, value);
                    }

                    return ctx;
                case ImageCode.NativeBehavior:
                    string typename = (string)this.Deserialize();
                    Type type = TypeUtilities.GetType(typename);
                    var nbehavior = this.machine.GetNativeBehavior(type);
                    
                    if (nbehavior == null)
                    {
                        nbehavior = (NativeBehavior)this.machine.CreateNativeBehavior(null, type);
                        this.machine.RegisterNativeBehavior(type, (NativeBehavior)nbehavior);
                    }

                    this.objects.Add(nbehavior);
                    IClass superclass = (IClass)this.Deserialize();
                    IBehavior metaclasssuperclass = (IBehavior)this.Deserialize();
                    ((NativeBehavior)nbehavior).SetSuperClass(superclass);

                    // TODO Review this weird chain (See SerializeDeserializeMachineWithLibrary test)
                    if (metaclasssuperclass != null)
                        ((BaseMetaClass)nbehavior.MetaClass).SetSuperClass(metaclasssuperclass);
                    else if (superclass != null)
                        ((BaseMetaClass)nbehavior.MetaClass).SetSuperClass(superclass.MetaClass);

                    this.DeserializeMethods(nbehavior);

                    return nbehavior;
                case ImageCode.Class:
                    string name = (string)this.Deserialize();
                    string category = (string)this.Deserialize();
                    string instvarnames = (string)this.Deserialize();
                    string classvarnames = (string)this.Deserialize();
                    var klass = this.machine.CreateClass(name, null, instvarnames, classvarnames);
                    this.objects.Add(klass);
                    superclass = (IClass)this.Deserialize();
                    metaclasssuperclass = (IBehavior)this.Deserialize();
                    ((BaseClass)klass).SetSuperClass(superclass);
                    
                    // TODO Review this weird chain (See SerializeDeserializeMachineWithLibrary test)
                    if (metaclasssuperclass != null)
                        ((BaseMetaClass)klass.MetaClass).SetSuperClass(metaclasssuperclass);
                    else if (superclass != null)
                        ((BaseMetaClass)klass.MetaClass).SetSuperClass(superclass.MetaClass);

                    klass.Category = category;
                    
                    var global = this.machine.GetGlobalObject(name);

                    this.DeserializeMethods(klass);

                    return klass;
                case ImageCode.Object:
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
                case ImageCode.Machine:
                    this.machine = new Machine(false);
                    this.objects.Add(this.machine);
                    this.objects.Add(this.machine.Environment);
                    nnames = this.reader.ReadInt32();

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

        private void DeserializeMethods(IBehavior behavior)
        {
            int nmethods = (int)this.Deserialize();

            for (int k = 0; k < nmethods; k++)
            {
                string mthname = (string)this.Deserialize();
                string mthsource = (string)this.Deserialize();
                var method = this.compiler.CompileInstanceMethod(mthsource, behavior);
                behavior.DefineInstanceMethod(method);
            }

            int nclassmethods = (int)this.Deserialize();

            for (int k = 0; k < nclassmethods; k++)
            {
                string mthname = (string)this.Deserialize();
                string mthsource = (string)this.Deserialize();
                var method = this.compiler.CompileClassMethod(mthsource, behavior);
                behavior.DefineClassMethod(method);
            }
        }
    }
}

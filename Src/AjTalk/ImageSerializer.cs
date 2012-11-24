﻿namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using AjTalk.Language;
    using AjTalk.Compiler;

    public class ImageSerializer
    {
        BinaryReader reader;
        ICompiler compiler;
        BinaryWriter writer;
        List<IObject> objects = new List<IObject>();

        public ImageSerializer(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public ImageSerializer(BinaryReader reader)
        {
            this.reader = reader;
            this.compiler = new VmCompiler();
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
                this.Serialize(klass.GetInstanceVariableNames());
                this.Serialize(klass.GetClassVariableNames());
                this.Serialize(klass.SuperClass);
                var methods = klass.GetInstanceMethods();
                this.Serialize(methods.Count(mth => mth.SourceCode != null));

                foreach (var method in methods)
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
                    IClass superclass = (IClass)this.Deserialize();
                    var klass = Machine.Current.CreateClass(name, superclass, instvarnames, classvarnames);
                    this.objects.Add(klass);
                    klass.Category = category;
                    
                    var global = Machine.Current.GetGlobalObject(name);

                    if (global != null)
                        klass = (IClass)global;
                    else
                        Machine.Current.SetGlobalObject(name, klass);

                    int nmethods = (int)this.Deserialize();

                    for (int k = 0; k < nmethods; k++)
                    {
                        string mthname = (string)this.Deserialize();
                        string mthsource = (string)this.Deserialize();
                        var method = this.compiler.CompileInstanceMethod(mthsource, klass);
                        klass.DefineInstanceMethod(method);
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
            }

            throw new InvalidDataException();
        }

        private enum ImageCodes
        {
            Nil = 0,
            Integer = 1,
            String = 2,
            Object = 3,
            Reference = 4,
            Class = 5
        }
    }
}
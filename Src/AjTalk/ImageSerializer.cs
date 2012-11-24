namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using AjTalk.Language;

    public class ImageSerializer
    {
        BinaryReader reader;
        BinaryWriter writer;

        public ImageSerializer(BinaryWriter writer)
        {
            this.writer = writer;
        }

        public ImageSerializer(BinaryReader reader)
        {
            this.reader = reader;
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

            if (obj is IObject)
            {
                var iobj = (IObject)obj;
                this.writer.Write((byte)ImageCodes.Object);
                this.Serialize(iobj.Behavior);
                this.Serialize(iobj.NoVariables);
                return;
            }

            throw new InvalidOperationException();
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
                case ImageCodes.Object:
                    IBehavior behavior = (IBehavior)this.Deserialize();
                    int nvariables = (int)this.Deserialize();
                    return new BaseObject(behavior, nvariables);
            }

            throw new InvalidDataException();
        }

        private enum ImageCodes
        {
            Nil = 0,
            Integer = 1,
            String = 2,
            Object = 3
        }
    }
}

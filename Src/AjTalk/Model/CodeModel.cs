namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CodeModel : IVisitable
    {
        private IDictionary<string, ClassModel> classes = new Dictionary<string, ClassModel>();
        private IList<IVisitable> codeElements = new List<IVisitable>();

        public CodeModel()
        {
        }

        public IEnumerable<IVisitable> Elements { get { return this.codeElements; } }

        public void AddElement(IVisitable element)
        {
            this.codeElements.Add(element);
            if (element is ClassModel)
            {
                ClassModel @class = (ClassModel)element;
                classes[@class.Name] = @class;
                classes[@class.MetaClass.Name] = @class.MetaClass;
            }
        }

        public ClassModel GetClass(string name)
        {
            return this.classes[name];
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}


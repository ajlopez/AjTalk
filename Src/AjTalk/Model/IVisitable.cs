namespace AjTalk.Model
{
    public interface IVisitable
    {
        void Visit(IVisitor visitor);
    }
}

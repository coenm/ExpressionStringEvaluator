namespace Core.Methods
{
    public interface IMethod
    {
        bool CanHandle(string method);

        CombinedTypeContainer Handle(string method, params CombinedTypeContainer[] arg);
    }
}

namespace BTE.Core
{
    public interface IException
    {
        string Code { get; }
        string Message{get; }
    }
}

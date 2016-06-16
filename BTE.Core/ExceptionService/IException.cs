namespace BTE.Core
{
    public interface IException
    {
        int Code { get; }
        string Message{get; }
    }
}

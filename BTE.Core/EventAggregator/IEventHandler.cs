namespace BTE.Core
{
	public interface IEventHandler<T>
	{
		void Handle(T eventData);
	}
}
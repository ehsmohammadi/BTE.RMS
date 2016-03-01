using System;

namespace BTE.Core
{
    public class DelegateHandler<T> : IEventHandler<T>
    {
        private Action<T> handleAction;
        
        public DelegateHandler(Action<T> handleAction)
        {
            this.handleAction = handleAction;
        }

        public void Handle(T eventData)
        {
            handleAction(eventData);
        }
    }
}

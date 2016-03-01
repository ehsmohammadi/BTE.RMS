using System;
using System.Collections.Generic;

namespace BTE.Core
{
	internal class EventHandlers
	{
		private Action<Exception> ErrorHandler { get; set; }
		private IDictionary<Type, IList<EventHandlerOptions>> Handlers { get; set; }
        private object lockObj = new object();

		internal EventHandlers()
		{
			Handlers = new Dictionary<Type, IList<EventHandlerOptions>>();
		}

		internal void Add<T>(EventHandlerOptions handler)
		{
            lock (lockObj)
            {
                Type handleType = typeof(T);
                Add(handleType, handler);
            }
		}

		internal void Add(Type eventType, EventHandlerOptions handler)
		{
            lock (lockObj)
            {
                if (!Handlers.ContainsKey(eventType))
                    Handlers[eventType] = new List<EventHandlerOptions>();

                Handlers[eventType].Add(handler);
            }
		}

		internal void Remove<T>(IEventHandler<T> handler)
		{
            lock (lockObj)
            {
                Type handleType = typeof(T);
                Remove(handleType, handler);
            }
		}

		internal void Remove(Type eventType, object handler)
		{
            lock (lockObj)
            {
                foreach (var e in Handlers[eventType])
                {
                    if (e.EventHandler.Target == handler)
                    {
                        Handlers[eventType].Remove(e);
                        break;
                    }
                }
            }
		}

		internal void Handle<T>(T eventData)
		{
            IList<EventHandlerOptions> nullHandlers = new List<EventHandlerOptions>();
            IList<EventHandlerOptions> handlers = GetEventHandlers<T>();
            for (var i = handlers.Count - 1; i >= 0; i--)
            {
                EventHandlerOptions handlerOptions = handlers[i];
                try
                {
                    IEventHandler<T> eventHandler = handlerOptions.EventHandler.Target as IEventHandler<T>;
                    if (eventHandler != null)
                        eventHandler.Handle(eventData);
                    else
                    {
                        nullHandlers.Add(handlerOptions);
                    }
                }
                catch (Exception ex)
                {
                    HandleError(handlerOptions, ex);
                }
            }
            lock (lockObj)
            {
                foreach (var h in nullHandlers)
                {
                    Handlers[typeof(T)].Remove(h);
                }
            }
		}

		internal void OnHandlerError(Action<Exception> errorHandler)
		{
			ErrorHandler = errorHandler;
		}

		private void HandleError(EventHandlerOptions eventhandlerOptions, Exception ex)
		{
			if (ErrorHandler != null)
				ErrorHandler(ex);

			if (eventhandlerOptions.ErrorHandler != null)
				eventhandlerOptions.ErrorHandler(ex);
		}

		private IList<EventHandlerOptions> GetEventHandlers<T>()
		{
			Type handleType = typeof(T);
			IList<EventHandlerOptions> handlers = new List<EventHandlerOptions>();
            lock (lockObj)
            {
                if (Handlers.ContainsKey(handleType))
                {
                    foreach (EventHandlerOptions handler in Handlers[handleType])
                    {
                        if (handler != null)
                            handlers.Add(handler);
                    }
                }
            }

			return handlers;
		}

	}
}

using System;
using System.Collections.Generic;

namespace BTE.Core
{
    public class LatchManager<T>
    {
        private IList<T> CurrentLocks { get; set; }
        private object lockobj = new object();

        public LatchManager()
        {
            CurrentLocks = new List<T>();
        }

        public void RunWithLock(T lockType, Action action)
        {
            lock (lockobj)
            {
                if (CurrentLocks.Contains(lockType))
                    return;

                CurrentLocks.Add(lockType);
            }
            action();
            lock (lockobj)
            {
                CurrentLocks.Remove(lockType);
            }
        }
    }
}
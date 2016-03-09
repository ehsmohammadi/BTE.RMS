using System;
using System.Collections.Generic;
using System.Reflection;
using BTE.RMS.Common;
using BTE.RMS.Model.Synchronize;

namespace BTE.RMS.Model.Tasks
{
    public class TaskCategory//:Syncable<TaskCategory>
    {
        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }

        public ICollection<Task> Tasks { get; set; }


        #endregion

        #region Constructors

        public TaskCategory()
        {
            
        }

        public TaskCategory(string title,Guid syncId, bool isSyncedWithAndriodApp, bool isSyncedWithDesktopApp, AppType actionTypeOwner)
            //: base(syncId, isSyncedWithAndriodApp, isSyncedWithDesktopApp, actionTypeOwner)
        {
            Title = title;
            Tasks=new List<Task>();
        }

        #endregion


    }
}

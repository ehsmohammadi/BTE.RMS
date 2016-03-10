using System;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Model.Synchronization;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Model.TaskCategories
{
    public class TaskCategory:Synchronizable
    {
        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public ICollection<Task> Tasks { get; set; }


        #endregion

        #region Constructors

        protected TaskCategory()
        {
            
        }

        public TaskCategory(string title,Guid syncId,AppType appType):base(syncId,appType)
        {
            Title = title;
            Tasks=new List<Task>();
        }

        #endregion


    }
}

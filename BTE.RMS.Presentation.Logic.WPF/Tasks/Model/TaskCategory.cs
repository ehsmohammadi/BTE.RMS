using System.Collections.Generic;

namespace BTE.RMS.Presentation.Logic.Tasks.Model
{
    public class TaskCategory
    {
        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }

        public ICollection<Tasks.Model.Task> Tasks { get; set; }


        #endregion

        #region Constructors

        public TaskCategory()
        {
            Tasks=new List<Tasks.Model.Task>();
        }
 
        #endregion
    }
}

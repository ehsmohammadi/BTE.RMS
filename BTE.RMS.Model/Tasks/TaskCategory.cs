using System.Collections.Generic;

namespace BTE.RMS.Model.Tasks
{
    public class TaskCategory
    {
        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }

        public ICollection<Task> Tasks { get; set; }


        #endregion

        #region Constructors

        public TaskCategory()
        {
            Tasks=new List<Task>();
        }
 
        #endregion
    }
}

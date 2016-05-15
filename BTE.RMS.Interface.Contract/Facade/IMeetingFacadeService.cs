using BTE.Core;
using BTE.RMS.Interface.Contract.Model.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Facade
{
    class IMeetingFacadeService :IFacadeService
    {
        //List<SummeryTaskItem> GetAll();
        //CrudTaskItem Get(long id);

        //List<SummeryTaskItem> GetTaskByStartDate(DateTime selectedDate);

        MeetingModel Create(MeetingModel meetingModel);
        //CrudTaskItem Update(CrudTaskItem task);
        //void Delete(long id);
        

    }
}

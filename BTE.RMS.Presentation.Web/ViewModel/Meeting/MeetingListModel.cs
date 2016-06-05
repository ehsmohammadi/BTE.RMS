using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Interface.Contract.Model.Meetings;


namespace BTE.RMS.Presentation.Web.ViewModel.Meeting
{
    public class MeetingListModel
    {
        public List<MeetingDto> MeetingList { get; set; }
    }
}
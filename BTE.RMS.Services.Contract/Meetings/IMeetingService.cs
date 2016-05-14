using System;
using BTE.Core;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract.Tasks;

namespace BTE.RMS.Services.Contract
{
    public interface IMeetingService:IService
    {
        void Create(string subject, DateTime startDate, int duration, string location, string attendees, string description);
    }
}

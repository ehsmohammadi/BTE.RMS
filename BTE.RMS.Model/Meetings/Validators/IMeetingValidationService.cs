using System;
using BTE.Core;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public interface IMeetingValidationService:IDomainService
    {
        void ValidateStartDateAndDuration(Meeting meeting, DateTime startDate, int duration);
    }
}

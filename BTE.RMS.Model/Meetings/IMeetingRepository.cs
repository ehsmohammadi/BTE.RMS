﻿using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public interface IMeetingRepository : IRepository<Meeting>, IRepository
    {
        Meeting GetByUserName(string userName, long id);

        Meeting GetBy(Guid syncId);
        IEnumerable<Meeting> GetAllUnsyncForAndroidApp();
        IEnumerable<Meeting> GetAllUnsyncForAndroidAppByCreator(string userName);
        IEnumerable<Meeting> GetAllUnsyncForDesktopApp();
        IEnumerable<Meeting> GetAllUnsyncForDesktopAppByCreator(string userName);
        IEnumerable<Meeting> GetAllByUserName(string userName);


        IEnumerable<Meeting> GetAllByUserNameAndStartDate(string userName, DateTime startDate);
        IEnumerable<Meeting> GetMeetinginDuration(DateTime startDate, int duration, User creatorUser);
    }
}

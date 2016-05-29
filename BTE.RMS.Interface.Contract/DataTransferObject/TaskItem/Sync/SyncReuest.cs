﻿using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Model.Meetings;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract
{
    public class SyncReuest
    {
        public int AppType { get; set; }
       
    }

    public class SyncItem
    {
        public Guid SyncId { get; set; }

        public int ActionType { get; set; }
    }

    public class MeetingSyncItem : SyncItem
    {
        public MeetingDto Meeting { get; set; }
    }

    public class MeetingSyncRequest : SyncReuest
    {
        public List<MeetingSyncItem> Items { get; set; }
    }










    public class TaskSyncRequest : SyncReuest
    {
        public List<CrudTaskItem> TaskItems { get; set; }
    }
    public class TaskCategorySyncRequest : SyncReuest
    {
        public List<CrudTaskCategory> TaskCategoryItems { get; set; }
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class BaseTaskItem:ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private int workProgressPercent;

        public int WorkProgressPercent
        {
            get { return workProgressPercent; }
            set { this.SetField(p => p.WorkProgressPercent, ref workProgressPercent, value); }
        }

        private string startDate;

        public string StartDate
        {
            get { return startDate; }
            set { this.SetField(p => p.StartDate, ref startDate, value); }
        }

        private string startTime;

        public string StartTime
        {
            get { return startTime; }
            set { this.SetField(p => p.StartTime, ref startTime, value); }
        }

        private string endTime;

        public string EndTime
        {
            get { return endTime; }
            set { this.SetField(p => p.EndTime, ref endTime, value); }
        }
    }
}
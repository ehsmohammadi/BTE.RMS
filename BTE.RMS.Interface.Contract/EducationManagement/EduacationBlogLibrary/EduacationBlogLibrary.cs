using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class EduacationBlogLibrary : ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p => p.Date, ref date, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                this.SetField(p => p.Title, ref title, value);
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { this.SetField(p => p.Text, ref text, value); }
        }
    }
}

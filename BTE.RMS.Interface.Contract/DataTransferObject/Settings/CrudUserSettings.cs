using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudUserSettings:ViewModelBase
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
            set { this.SetField(p=>p.Title,ref title,value);}
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { this.SetField(p=>p.UserName,ref userName,value);}
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { this.SetField(p=>p.PassWord,ref passWord,value);}
        }
    }
}

using System;
using System.Security.Policy;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.ManagementContacts
{
    public class GeneralContact:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { this.SetField(p=>p.Name,ref  name,value);}
        }
    }
}

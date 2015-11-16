using System;
using System.Security.Policy;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.ManagementContacts
{
    public class NecessaryContactCategory:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string parrentCategory;

        public string ParrentCategory
        {
            get { return parrentCategory; }
            set { this.SetField(p=>p.ParrentCategory,ref parrentCategory,value);}
        }

        private string childCategory;

        public string ChildCategory
        {
            get { return childCategory; }
            set { this.SetField(p=>p.ChildCategory,ref childCategory,value);}
        }
    }
}

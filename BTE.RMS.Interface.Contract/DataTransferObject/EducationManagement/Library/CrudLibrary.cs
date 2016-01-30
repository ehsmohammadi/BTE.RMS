using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudLibrary:ViewModelBase
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
            set { this.SetField(p => p.Name, ref name, value); }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                this.SetField(p => p.Description, ref description, value);
            }
        }

        private LibraryType libraryType;

        public LibraryType LibraryType
        {
            get { return libraryType; }
            set { this.SetField(p=>p.LibraryType,ref libraryType,value);}
        }
    }
}

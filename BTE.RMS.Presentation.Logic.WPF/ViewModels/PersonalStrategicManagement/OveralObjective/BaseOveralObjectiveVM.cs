using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class BaseOveralObjectiveVM : WorkspaceViewModel
    {
        private SummeryOveralObjective selectedOveralObjectiveList;

        public SummeryOveralObjective SelectedOveralObjectiveList
        {
            get { return selectedOveralObjectiveList; }
            set { this.SetField(p => p.SelectedOveralObjectiveList, ref  selectedOveralObjectiveList, value); }
        }
        private PeriorityType selectedPeriorityType;

        public PeriorityType SelectedPeriorityType
        {
            get { return selectedPeriorityType; }
            set { this.SetField(p => p.SelectedPeriorityType, ref selectedPeriorityType, value); }
        }

        private CrudOveralObjective selectedOveralObjective;

        public CrudOveralObjective SelectedOveralObjective
        {
            get { return selectedOveralObjective; }
            set { this.SetField(p => p.SelectedOveralObjective, ref selectedOveralObjective, value); }
        }

    }
}

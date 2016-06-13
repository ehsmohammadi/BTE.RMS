using BTE.Presentation;
using System;
using System.Collections.ObjectModel;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic.ViewModels.Appointment
{
    public class AppointmentVM : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        #endregion

        #region Properties

        private ObservableCollection<string> date_types;
        public ObservableCollection<string> Date_Types
        {
            get
            {
                return date_types;
            }
            set
            {
                this.SetField(p => p.date_types, ref date_types, value); 
            }
        }
        public CommandViewModel SelectType
        {
            get
            {
                return new CommandViewModel("", new DelegateCommand(Selecttype));
            }
        }
        public CommandViewModel ChangeType
        {
            get
            {
                return new CommandViewModel("", new DelegateCommand(Changetype));
            }
        }

        #endregion

        #region Constructors
        public AppointmentVM()
        {
            init();
        }

        public AppointmentVM(IRMSController rms)
        {
            init();
            this.controller = rms;
        }

        
        #endregion

        #region Private Methods
        private void init()
        {
            Date_Types = new ObservableCollection<string>();
            Fill_Combo();
        }
        private void Changetype()
        {

        }

        private void Selecttype()
        {
            this.Date_Types.Add("کاری");
            this.Date_Types.Add("غیر کاری");
        }

        private void Fill_Combo()
        {
            this.Date_Types.Add("کاری");
            this.Date_Types.Add("غیر کاری");
        }
        #endregion
    }
}

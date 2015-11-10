using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class NotesAndAppointmentsListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryNotesAndAppointments> notesAndAppointments;

        public ObservableCollection<SummeryNotesAndAppointments> NotesAndAppointments
        {
            get { return notesAndAppointments; }
            set
            {
                this.SetField(p => p.NotesAndAppointments, ref notesAndAppointments, value);
            }
        }

        private SummeryNotesAndAppointments selectedNotesAndAppointments;

        public SummeryNotesAndAppointments SelectedNotesAndAppointments
        {
            get { return selectedNotesAndAppointments; }
            set
            {
                this.SetField(p => p.SelectedNotesAndAppointments, ref selectedNotesAndAppointments, value);
                if (selectedNotesAndAppointments == null) return;
            }
        }

        #endregion

        #region Constructors

        public NotesAndAppointmentsListVM()
        {
            init();
        }

        public NotesAndAppointmentsListVM(IRMSController controller)
        {
            this.controller = controller;
            init();
        }
        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها/قرار ملاقات";
            NotesAndAppointments = new ObservableCollection<SummeryNotesAndAppointments>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        #endregion

        #region Public Methods
        public void Load() { }
        #endregion
    }
}

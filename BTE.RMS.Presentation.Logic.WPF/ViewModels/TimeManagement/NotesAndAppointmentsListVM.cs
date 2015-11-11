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
        private readonly INotesAndAppointmentsServiceWrapper notesAndAppointmentsService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryNoteAndAppointment> notesAndAppointments;

        public ObservableCollection<SummeryNoteAndAppointment> NotesAndAppointments
        {
            get { return notesAndAppointments; }
            set
            {
                this.SetField(p => p.NotesAndAppointments, ref notesAndAppointments, value);
            }
        }

        private SummeryNoteAndAppointment selectedNotesAndAppointments;

        public SummeryNoteAndAppointment SelectedNotesAndAppointments
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

        public NotesAndAppointmentsListVM(IRMSController controller,INotesAndAppointmentsServiceWrapper notesAndAppointmentsService)
        {
            this.controller = controller;
            this.notesAndAppointmentsService = notesAndAppointmentsService;
            init();
        }
        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها/قرار ملاقات";
            NotesAndAppointments = new ObservableCollection<SummeryNoteAndAppointment>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        #endregion

        #region Public Methods
        public void Load()
        {
            notesAndAppointmentsService.GetAllOveralObjectives(
                (res, exp) => 
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        NotesAndAppointments = new ObservableCollection<SummeryNoteAndAppointment>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

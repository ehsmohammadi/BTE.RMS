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
            }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("هدف جدید", new DelegateCommand(create));
                }
                return createCmd;
            }
        }

        private CommandViewModel modifyCmd;
        public CommandViewModel ModifyCmd
        {
            get
            {
                if (modifyCmd == null)
                {
                    modifyCmd = new CommandViewModel("ویرایش", new DelegateCommand(modify));
                }
                return modifyCmd;
            }
        }

        private CommandViewModel deleteCmd;
        public CommandViewModel DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new CommandViewModel("حذف", new DelegateCommand(delete));
                }
                return deleteCmd;
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

        private void create()
        {
            controller.ShowNotesAndAppointmentsView();
        }

        public void modify()
        {
            controller.ShowNotesAndAppointmentsView();
        }
        public void delete()
        {
            controller.ShowNotesAndAppointmentsView();
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

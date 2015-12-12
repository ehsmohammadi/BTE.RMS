using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class NotesAndAppointmentsVM:WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly INotesAndAppointmentsServiceWrapper notesAndAppointmentsService;

        #endregion

        #region Properties & BackFields
        private CommandViewModel registerCmd;
        public CommandViewModel RegisterCmd
        {
            get
            {
                if (registerCmd == null)
                {
                    registerCmd = new CommandViewModel("ثبت", new DelegateCommand(register));
                }
                return registerCmd;
            }
        }
        #endregion

        #region Constructors

        public NotesAndAppointmentsVM(IRMSController controller,INotesAndAppointmentsServiceWrapper notesAndAppointmentsService)
        {
            this.controller = controller;
            this.notesAndAppointmentsService = notesAndAppointmentsService;
            init();
        }

        public NotesAndAppointmentsVM()
        {
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "ثبت یادداشت ها/قرار ملاقات";
        
        }
        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            controller.ShowNotesAndAppointmentsListView();
        }
        #endregion

        #region Public Methods
        #endregion
    }
}

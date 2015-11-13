using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.ManagementContacts;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.ManagementContacts;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class GeneralContactsVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IGeneralContactsServiceWrapper generalContactsService;

        #endregion
        #region Properties & BackFields

        private ObservableCollection<GeneralContact> generalContacts;

        public ObservableCollection<GeneralContact> GeneralContacts
        {
            get { return generalContacts; }
            set { this.SetField(p=>p.GeneralContacts,ref generalContacts,value);}
        }

        private GeneralContact selectedGeneralContact;

        public GeneralContact SelectedGeneralContact
        {
            get { return selectedGeneralContact; }
            set { this.SetField(p=>p.SelectedGeneralContact,ref selectedGeneralContact,value);}
        }

        #endregion

        #region Constructors

        public GeneralContactsVM()
        {
           init();
        }

        public GeneralContactsVM(IRMSController controller,IGeneralContactsServiceWrapper generalContactsService)
        {
            this.controller = controller;
            this.generalContactsService = generalContactsService;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "اطلاعات تماس عمومی";
            GeneralContacts=new ObservableCollection<GeneralContact>();
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
            generalContactsService.GetAllGeneralContactList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        GeneralContacts = new ObservableCollection<GeneralContact>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class GeneralContactsVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IGeneralContactsServiceWrapper generalContactsService;

        #endregion
        #region Properties & BackFields

        private ObservableCollection<NecessaryContactCategory> necessaryContactCategories;

        public ObservableCollection<NecessaryContactCategory> NecessaryContactCategories
        {
            get { return necessaryContactCategories; }
            set { this.SetField(p => p.NecessaryContactCategories, ref necessaryContactCategories, value); }
        }

        private NecessaryContactCategory selectedNecessaryContactCategory;

        public NecessaryContactCategory SelectedNecessaryContactCategory
        {
            get { return selectedNecessaryContactCategory; }
            set { this.SetField(p=>p.SelectedNecessaryContactCategory,ref selectedNecessaryContactCategory,value);}
        }

        private ObservableCollection<SummeryNecessaryPhoneNumber> necessaryPhoneNumbers;

        public ObservableCollection<SummeryNecessaryPhoneNumber> NecessaryPhoneNumbers
        {
            get { return necessaryPhoneNumbers; }
            set { this.SetField(p=>p.NecessaryPhoneNumbers,ref necessaryPhoneNumbers,value);}
        }

        private SummeryNecessaryPhoneNumber selectedNecessaryPhoneNumber;

        public SummeryNecessaryPhoneNumber SelectedNecessaryPhoneNumber
        {
            get { return selectedNecessaryPhoneNumber; }
            set { this.SetField(p=>p.SelectedNecessaryPhoneNumber,ref selectedNecessaryPhoneNumber,value);}
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
            NecessaryContactCategories=new ObservableCollection<NecessaryContactCategory>();
            NecessaryPhoneNumbers=new ObservableCollection<SummeryNecessaryPhoneNumber>();
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
            generalContactsService.GetAllNecessaryContactCategoryList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        NecessaryContactCategories = new ObservableCollection<NecessaryContactCategory>(res);
                    }
                    else controller.HandleException(exp);
                });
            generalContactsService.GetAllNecessaryPhoneNumberList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        NecessaryPhoneNumbers=new ObservableCollection<SummeryNecessaryPhoneNumber>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

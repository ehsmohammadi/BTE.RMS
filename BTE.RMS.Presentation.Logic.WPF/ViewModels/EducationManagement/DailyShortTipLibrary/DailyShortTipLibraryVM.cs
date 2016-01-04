using System.Collections.Generic;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipLibraryVM : WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ILibraryServiceWrapper libraryService;
        #endregion

        #region Properties & BackFields

        private List<SummeryDailyShortTip> dailyShortTipList;

        public List<SummeryDailyShortTip> DailyShortTipList
        {
            get { return dailyShortTipList; }
            set { this.SetField(p=>p.DailyShortTipList,ref dailyShortTipList,value);}
        }

        private SummeryDailyShortTip dailyShortTip;

        public SummeryDailyShortTip DailyShortTip
        {
            get { return dailyShortTip; }
            set { this.SetField(p=>p.DailyShortTip,ref dailyShortTip,value);}
        }
        private CrudLibrary crudLibrary;

        public CrudLibrary CrudLibrary
        {
            get { return crudLibrary; }
            set { this.SetField(p => p.CrudLibrary, ref crudLibrary, value); }
        }
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
        private CommandViewModel backCmd;
        public CommandViewModel BackCmd
        {
            get
            {
                if (backCmd == null)
                {
                    backCmd = new CommandViewModel("بازگشت", new DelegateCommand(back));
                }
                return backCmd;
            }
        }
        #endregion

        #region Constructors

        public DailyShortTipLibraryVM()
        {
            init();
        }
        public DailyShortTipLibraryVM(IRMSController controller,ILibraryServiceWrapper libraryService)
        {
            this.controller = controller;
            this.libraryService = libraryService;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه نکات کوتاه روز";
            DailyShortTipList=new List<SummeryDailyShortTip>();
            CrudLibrary=new CrudLibrary();
            DailyShortTip = new SummeryDailyShortTip();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            libraryService.CreateCrudDailyShortTip((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    CrudLibrary = new CrudLibrary();
                }
                else
                {
                    controller.HandleException(exp);
                }
            }, CrudLibrary);
            libraryService.CreateSummeryDailyShortTip((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    DailyShortTip = new SummeryDailyShortTip();
                }
                else
                {
                    controller.HandleException(exp);
                }
            },DailyShortTipList);
            controller.ShowDailyShortTipsLibraryListView();
        }
        private void back()
        {
            controller.ShowDailyShortTipsLibraryListView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
        }
        #endregion
    }
}

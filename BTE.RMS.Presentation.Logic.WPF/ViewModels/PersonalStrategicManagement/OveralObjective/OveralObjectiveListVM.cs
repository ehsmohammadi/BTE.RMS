using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class OveralObjectiveListVM : BaseOveralObjectiveVM
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IOveralObjectiveServiceWrapper overalObjectiveService;
        #endregion
        #region Properties & BackFields

        private ObservableCollection<SummeryOveralObjective> overalObjectiveList;

        public ObservableCollection<SummeryOveralObjective> OveralObjectiveList
        {
            get { return overalObjectiveList; }
            set { this.SetField(p => p.OveralObjectiveList, ref overalObjectiveList, value); }
        }

        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("هدف کلی جدید", new DelegateCommand(create));
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
        public OveralObjectiveListVM()
        {
            init();
        }

        public OveralObjectiveListVM(IRMSController controller, IOveralObjectiveServiceWrapper overalObjectiveService)
        {
            this.controller = controller;
            this.overalObjectiveService = overalObjectiveService;
            init();
        }

        #endregion
        #region Private Methods

        private void init()
        {
            DisplayName = "اهداف کلی";
            OveralObjectiveList = new ObservableCollection<SummeryOveralObjective>();
            SelectedOveralObjectiveList = new SummeryOveralObjective();
            SelectedOveralObjective=new CrudOveralObjective();
            
            SelectedPeriorityType=new PeriorityType();
        }

        private void create()
        {
            controller.ShowOveralObjectiveView();
        }

        private void modify()
        {
            if (SelectedOveralObjectiveList.Id == 0)
            {
                controller.ShowOveralObjectiveListView();
                MessageBox.Show("سطری برای ویرایش وجود ندارد");
            }
            else
            {
                //controller.ShowOveralObjectiveView(SelectedOveralObjectiveList);
                overalObjectiveService.UpdateSelectedOveralObjective(
                    (res, exp) =>
                    {
                        HideBusyIndicator();
                        if (exp==null)
                        {
                            SelectedOveralObjectiveList=new SummeryOveralObjective();
                        }
                        else controller.HandleException(exp);
                    },SelectedOveralObjectiveList,SelectedPeriorityType);
            }
        }
        private void delete()
        {
            overalObjectiveService.RemoveOveralObjective(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SelectedOveralObjectiveList = new SummeryOveralObjective();
                    }
                }, SelectedOveralObjectiveList);
            controller.ShowOveralObjectiveListView();
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
            overalObjectiveService.GetAllOveralObjectiveList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        overalObjectiveList = new ObservableCollection<SummeryOveralObjective>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedOveralObjectiveList);
        }
        #endregion
    }
}

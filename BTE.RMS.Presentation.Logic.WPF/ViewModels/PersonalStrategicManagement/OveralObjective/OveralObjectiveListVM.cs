using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class OveralObjectiveListVM:WorkspaceViewModel
    {
        #region Fields

        private readonly IOveralObjectiveServiceWrapper overalObjectiveService;
        private readonly IRMSController controller;

        #endregion

        #region Properties & Back fields

        private ObservableCollection<SummeryOveralObjective> overalObjectives;
        public ObservableCollection<SummeryOveralObjective> OveralObjectives
        {
            get { return overalObjectives; }
            set { this.SetField(p => p.OveralObjectives, ref overalObjectives, value); }
        }

        private SummeryOveralObjective selectedOveralObjective;
        public SummeryOveralObjective SelectedOveralObjective
        {
            get { return selectedOveralObjective; }
            set
            {
                this.SetField(p => p.SelectedOveralObjective, ref selectedOveralObjective, value);

            }

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
        /// <summary>
        /// Design Mode Constructor
        /// </summary>
        public OveralObjectiveListVM()
        {
            init();
            OveralObjectives.Add(new SummeryOveralObjective{Title = "قهرمانی دنیا",Periority = "اول"});
        }

        public OveralObjectiveListVM(IOveralObjectiveServiceWrapper overalObjectiveService, IRMSController controller)
        {
            this.overalObjectiveService = overalObjectiveService;
            this.controller = controller;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "اهداف کلی";
            OveralObjectives = new ObservableCollection<SummeryOveralObjective>();
        }


        private void create()
        {
            controller.ShowOveralObjectiveView();
        }

        public void modify()
        {
            controller.ShowOveralObjectiveView();
        }
        public void delete()
        {
            controller.ShowOveralObjectiveView();
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
            overalObjectiveService.GetAllOveralObjectives(
                (res,exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OveralObjectives = new ObservableCollection<SummeryOveralObjective>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        
        #endregion
    }
}

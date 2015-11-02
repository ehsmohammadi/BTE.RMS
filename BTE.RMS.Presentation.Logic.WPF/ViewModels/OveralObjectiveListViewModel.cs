using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class OveralObjectiveListViewModel:WorkspaceViewModel
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
                if (selectedOveralObjective == null) return;
                //JobCommands = createCommands();
                //if (View != null)
                //    ((IJobListView)View).CreateContextMenu(new ReadOnlyCollection<DataGridCommandViewModel>(JobCommands));
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Design Mode Constructor
        /// </summary>
        public OveralObjectiveListViewModel()
        {
            init();
            OveralObjectives.Add(new SummeryOveralObjective{Title = "قهرمانی دنیا",Periority = "اول"});
        }

        public OveralObjectiveListViewModel(IOveralObjectiveServiceWrapper overalObjectiveService,IRMSController controller)
        {
            this.overalObjectiveService = overalObjectiveService;
            this.controller = controller;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "آهداف کلی";
            OveralObjectives = new ObservableCollection<SummeryOveralObjective>();
            //OveralObjectives.OnRefresh += (s, args) => Load();
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
                (res, exp) => controller.BeginInvokeOnDispatcher(() =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OveralObjectives = new ObservableCollection<SummeryOveralObjective>(res);
                    }
                    else controller.HandleException(exp);
                }));
        }
        
        #endregion
        
    }
}

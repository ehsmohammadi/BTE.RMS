using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.WPF.ViewModels
{
    public class OveralObjectiveListViewModel:WorkspaceViewModel
    {
        #region Fields

        //private readonly IBasicInfoController basicInfoController;
        //private readonly IPMSController appController;
        private readonly IOveralObjectiveServiceWrapper overalObjectiveService;

        #endregion

        //#region Properties & Back fields

        //private ObservableCollection<JobDTOWithActions> jobs;
        //public ObservableCollection<JobDTOWithActions> Jobs
        //{
        //    get { return jobs; }
        //    set { this.SetField(p => p.Jobs, ref jobs, value); }
        //}

        //private JobDTOWithActions selectedJob;
        //public JobDTOWithActions SelectedJob
        //{
        //    get { return selectedJob; }
        //    set
        //    {
        //        this.SetField(p => p.SelectedJob, ref selectedJob, value);
        //        if (selectedJob == null) return;
        //        JobCommands = createCommands();
        //        if (View != null)
        //            ((IJobListView)View).CreateContextMenu(new ReadOnlyCollection<DataGridCommandViewModel>(JobCommands));
        //    }
        //}

        //#endregion

        //#region Constructors

        //public JobListVM()
        //{
        //    BasicInfoAppLocalizedResources=new BasicInfoAppLocalizedResources();
        //    init();
        //    Jobs.Add(new JobDTOWithActions { Id = 4, Name = "Test" });
        //}

        //public JobListVM(IBasicInfoController basicInfoController, IPMSController appController,
        //    IJobServiceWrapper jobService, IBasicInfoAppLocalizedResources basicInfoAppLocalizedResources)
        //{
            
        //    this.appController = appController;
        //    this.jobService = jobService;
        //    BasicInfoAppLocalizedResources = basicInfoAppLocalizedResources;
        //    this.basicInfoController = basicInfoController;
        //    init();
            

        //}

        //#endregion

        //#region Methods

        //void init()
        //{
        //    DisplayName = BasicInfoAppLocalizedResources.JobListViewTitle;
        //    Jobs = new PagedSortableCollectionView<JobDTOWithActions>();
        //    Jobs.OnRefresh += (s, args) => Load();
        //    JobCommands = new List<DataGridCommandViewModel>
        //    {
        //           CommandHelper.GetControlCommands(this, appController, new List<int>{ (int) ActionType.AddJob}).FirstOrDefault()
        //    };
        //}

        //private List<DataGridCommandViewModel> createCommands()
        //{
        //    return CommandHelper.GetControlCommands(this, appController, SelectedJob.ActionCodes);
        //}

        //public void Load()
        //{
        //    var sortBy = jobs.SortDescriptions.ToDictionary(sortParam => sortParam.PropertyName,
        //                                                    sortDirect =>
        //                                                    (sortDirect.Direction == ListSortDirection.Ascending)
        //                                                        ? "ASC" : "DESC");
        //    jobService.GetAllJobs(
        //          (res, exp) => appController.BeginInvokeOnDispatcher(() =>
        //         {
        //             HideBusyIndicator();
        //             if (exp == null)
        //             {
        //                 Jobs.SourceCollection = res.Result;
        //                 Jobs.TotalItemCount = res.TotalCount;
        //                 Jobs.PageIndex = Math.Max(0, res.CurrentPage - 1);
        //             }
        //             else appController.HandleException(exp);
        //         }), jobs.PageSize, jobs.PageIndex + 1,sortBy);
        //}


        //protected override void OnRequestClose()
        //{
        //    base.OnRequestClose();
        //    appController.Close(this);
        //}

        //public void Handle(UpdateJobListArgs eventData)
        //{
        //    Load();
        //}

        //#endregion
        
    }
}

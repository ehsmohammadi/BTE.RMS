using System;
using BTE.Core;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.ViewModels;
using BTE.RMS.Presentation.Logic.WPF.Views;

namespace BTE.RMS.Presentation.Logic.WPF.Controller
{
    public class RMSController : IRMSController
    {
        #region Fields
        private readonly IViewManager viewManager;
        #endregion

        #region Constructors

        public RMSController(IViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        #endregion

        #region Today Methods

        public void ShowTodayCalendarAndEventsView()
        {
            var vm = ServiceLocator.Current.GetInstance<TodayCalendarAndEventsVM>();
            var view = ServiceLocator.Current.GetInstance<ITodayCalendarAndEventsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }
        public void ShowTodayEducationalTipView()
        {
            var vm = ServiceLocator.Current.GetInstance<TodayEducationalTipVM>();
            var view = ServiceLocator.Current.GetInstance<ITodayEducationalTipView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowSummeryPlanningView()
        {
            var vm = ServiceLocator.Current.GetInstance<TodaySummaryPlanningVM>();
            var view = ServiceLocator.Current.GetInstance<ITodaySummaryPlanningView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion


        #region TimeManagement Methods
        public void ShowNotesAndAppointmentsListView()
        {
            var vm = ServiceLocator.Current.GetInstance<NotesAndAppointmentsListVM>();
            var view = ServiceLocator.Current.GetInstance<INotesAndAppointmentsListView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowReviewView()
        {
            var vm = ServiceLocator.Current.GetInstance<ReviewVm>();
            var view = ServiceLocator.Current.GetInstance<IReviewView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowCalendarCalculationsView()
        {
            var vm = ServiceLocator.Current.GetInstance<CalendarCalculationsVM>();
            var view = ServiceLocator.Current.GetInstance<ICalendarCalculationsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowMyHorizonVisionView()
        {
            var vm = ServiceLocator.Current.GetInstance<MyHorizonVisionVM>();
            var view = ServiceLocator.Current.GetInstance<IMyHorizonVisionView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowOveralObjectiveListView()
        {
            var vm = ServiceLocator.Current.GetInstance<OveralObjectiveListVM>();
            var view = ServiceLocator.Current.GetInstance<IOveralObjectiveListView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

        #region Personal Strategic Management Methods

       public void ShowLifePlaningView()
        {
            var vm = ServiceLocator.Current.GetInstance<LifePlaningVM>();
            var view = ServiceLocator.Current.GetInstance<ILifePlaningView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowSecondaryObjectivesListView()
        {
            var vm = ServiceLocator.Current.GetInstance<SecondaryObjectivesListVM>();
            var view = ServiceLocator.Current.GetInstance<ISecondaryObjectivesListView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

       #region Management Contacts
       public void ShowSendingOccasionEmailsView()
       {
           var vm = ServiceLocator.Current.GetInstance<SendingOccasionEmailsVM>();
           var view = ServiceLocator.Current.GetInstance<ISendingOccasionEmailsView>();
           view.ViewModel = vm;
           viewManager.ShowInMainWindow(view);
       }

        public void ShowGeneralContactsView()
        {
            var vm = ServiceLocator.Current.GetInstance<GeneralContactsVM>();
            var view = ServiceLocator.Current.GetInstance<IGeneralContactsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

       #region EducationManagement
       public void ShowConversionMeasuresView()
       {
           var vm = ServiceLocator.Current.GetInstance<ConversionMeasuresVM>();
           var view = ServiceLocator.Current.GetInstance<IConversionMeasuresView>();
           view.ViewModel = vm;
           viewManager.ShowInMainWindow(view);
       }

        public void ShowCitiesDistanceView()
        {
            var vm = ServiceLocator.Current.GetInstance<CitiesDistanceVM>();
            var view = ServiceLocator.Current.GetInstance<ICitiesDistanceView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowEduacationBlogLibraryView()
        {
            var vm = ServiceLocator.Current.GetInstance<EduacationBlogLibraryVM>();
            var view = ServiceLocator.Current.GetInstance<IEduacationBlogLibraryView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowDailyShortTipsLibraryView()
        {
            var vm = ServiceLocator.Current.GetInstance<DailyShortTipsLibraryVM>();
            var view = ServiceLocator.Current.GetInstance<IDailyShortTipsLibraryView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowLibraryImportExportFileView()
        {
            var vm = ServiceLocator.Current.GetInstance<LibraryImportExportFileVM>();
            var view = ServiceLocator.Current.GetInstance<ILibraryImportExportFileView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

       #region PersonalFinancialManagement
       public void ShowFinancialAccountsListView()
       {
           var vm = ServiceLocator.Current.GetInstance<FinancialAccountsListVm>();
           var view = ServiceLocator.Current.GetInstance<IFinancialAccountsListView>();
           vm.Load();
           view.ViewModel = vm;
           viewManager.ShowInMainWindow(view);
       }

        public void ShowPersonalBudgetingView()
        {
            var vm = ServiceLocator.Current.GetInstance<PersonalBudgetingVM>();
            var view = ServiceLocator.Current.GetInstance<IPersonalBudgetingView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowRegisterDownloadsAndPaysView()
        {
            var vm = ServiceLocator.Current.GetInstance<RegisterDownloadsAndPaysVM>();
            var view = ServiceLocator.Current.GetInstance<IRegisterDownloadsAndPaysView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowMaturityAndCzechsView()
        {
            var vm = ServiceLocator.Current.GetInstance<MaturityAndCzechsVM>();
            var view = ServiceLocator.Current.GetInstance<IMaturityAndCzechsView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion


       #region QuranAndPrayer
       public void ShowPrayerTimesView()
       {
           var vm = ServiceLocator.Current.GetInstance<PrayerTimesVM>();
           var view = ServiceLocator.Current.GetInstance<IPrayerTimesView>();
           view.ViewModel = vm;
           viewManager.ShowInMainWindow(view);
       }

        public void ShowAzanAndPrayerPlayingView()
        {
            var vm = ServiceLocator.Current.GetInstance<AzanAndPrayerPlayingVM>();
            var view = ServiceLocator.Current.GetInstance<IAzanAndPrayerPlayingView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

       #region Public
       public void BeginInvokeOnDispatcher(Action action)
        {
            throw new NotImplementedException();
        }

        public void HandleException(Exception exp)
        {
            throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {

        }

        public void Close(WorkspaceViewModel workspaceViewModel)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}

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



        #endregion

        #region Personal Strategic Management Methods
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
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }
        public void ShowLifePlaningView()
        {
            var vm = ServiceLocator.Current.GetInstance<LifePlaningVM>();
            var view = ServiceLocator.Current.GetInstance<ILifePlaningView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowSecondaryObjectivesListView()
        {
            var vm = ServiceLocator.Current.GetInstance<SecondaryObjectiveListVM>();
            var view = ServiceLocator.Current.GetInstance<ISecondaryObjectiveListView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }



        #endregion

        #region Management Contacts Methods

        public void ShowGeneralContactsView()
        {
            var vm = ServiceLocator.Current.GetInstance<GeneralContactsVM>();
            var view = ServiceLocator.Current.GetInstance<IGeneralContactsView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }
        public void ShowSendingRelationEmailsView()
        {
            var vm = ServiceLocator.Current.GetInstance<SendingOccasionEmailsVM>();
            var view = ServiceLocator.Current.GetInstance<ISendingRelationEmailsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion

        #region Education Management Methods
        public void ShowConversionMeasuresView()
        {
            var vm = ServiceLocator.Current.GetInstance<ConversionMeasuresVM>();
            var view = ServiceLocator.Current.GetInstance<IConversionMeasuresView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowCityDistanceView()
        {
            var vm = ServiceLocator.Current.GetInstance<CityDistanceVM>();
            var view = ServiceLocator.Current.GetInstance<ICityDistanceView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }


        public void ShowEduacationBlogLibraryView()
        {
            var vm = ServiceLocator.Current.GetInstance<EduacationBlogLibraryVM>();
            var view = ServiceLocator.Current.GetInstance<IEduacationBlogLibraryView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowDailyShortTipsLibraryView()
        {
            var vm = ServiceLocator.Current.GetInstance<DailyShortTipLibraryVM>();
            var view = ServiceLocator.Current.GetInstance<IDailyShortTipsLibraryView>();
            vm.Load();
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

        #region Personal Financial Management Methods
        public void ShowFinancialAccountsListView()
        {
            var vm = ServiceLocator.Current.GetInstance<FinancialAccountListVm>();
            var view = ServiceLocator.Current.GetInstance<IFinancialAccountListView>();
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

        public void ShowRegisterReceiptAndPaymentView()
        {
            var vm = ServiceLocator.Current.GetInstance<RegisterReceiptAndPaymentVM>();
            var view = ServiceLocator.Current.GetInstance<IRegisterReceiptAndPaymentView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowMaturityAndChequeView()
        {
            var vm = ServiceLocator.Current.GetInstance<MaturityAndChequeVM>();
            var view = ServiceLocator.Current.GetInstance<IMaturityAndChequeView>();
            vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion


        #region Quran And Prayer Methods
        public void ShowPrayerTimesView()
        {
            var vm = ServiceLocator.Current.GetInstance<PrayerTimesVM>();
            var view = ServiceLocator.Current.GetInstance<IPrayerTimesView>();
            vm.Load();
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


        #region Relaxation Management Methods
        public void ShowCordonStressExamView()
        {
            var vm = ServiceLocator.Current.GetInstance<CordonStressExamVM>();
            var view = ServiceLocator.Current.GetInstance<ICordonStressExamView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowDepressionBeckExamView()
        {
            var vm = ServiceLocator.Current.GetInstance<DepressionBeckExamVM>();
            var view = ServiceLocator.Current.GetInstance<IDepressionBeckExamView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowPersonalityBrigadeExamView()
        {
            var vm = ServiceLocator.Current.GetInstance<PersonalityBrigadeExamVM>();
            var view = ServiceLocator.Current.GetInstance<IPersonalityBrigadeExamView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowPsychologyExamView()
        {
            var vm = ServiceLocator.Current.GetInstance<PsychologyExamVM>();
            var view = ServiceLocator.Current.GetInstance<IPsychologyExamView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowRelaxationWaysExamView()
        {
            var vm = ServiceLocator.Current.GetInstance<RelaxationWaysExamVM>();
            var view = ServiceLocator.Current.GetInstance<IRelaxationWaysExamView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        #endregion


        #region Nursa Relaxatio Setting Methods

        public void ShowSoftwareSettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<SoftwareSettingsVM>();
            var view = ServiceLocator.Current.GetInstance<ISoftwareSettingsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowCalendarSettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<CalendarSettingsVM>();
            var view = ServiceLocator.Current.GetInstance<ICalendarSettingsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowCategorySettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<CategorySettingsVM>();
            var view = ServiceLocator.Current.GetInstance<ICategorySettingsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowDisplaySettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<DisplaySettingsVM>();
            var view = ServiceLocator.Current.GetInstance<IDisplaySettingsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowGeneralSettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<GeneralSettingsVM>();
            var view = ServiceLocator.Current.GetInstance<IGeneralContactsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowUserSettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<UserSettingsVM>();
            var view = ServiceLocator.Current.GetInstance<IUserSettingsView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowPrayerTimeSettingsView()
        {
            var vm = ServiceLocator.Current.GetInstance<PrayerTimeSettingsVM>();
            var view = ServiceLocator.Current.GetInstance<IPrayerTimeSettingsView>();
            vm.Load();
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

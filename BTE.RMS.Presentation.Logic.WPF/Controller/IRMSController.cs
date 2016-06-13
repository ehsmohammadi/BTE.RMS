using System;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Logic.Controller
{
    public interface IRMSController
    {
        #region Public

        void BeginInvokeOnDispatcher(Action action);
        void HandleException(Exception exp);
        void Close(WorkspaceViewModel workspaceViewModel);
        void ShowMainWindow();
        void Logout();
        void FullScreenMode();
        void SendToTry();
        
        void ShowMessage(string message);

        bool ShowConfirmationMessage(string title, string text);

        #endregion

        void ShowTaskListView();
        void ShowTaskView(long? id);

        #region TodayMethods

        void ShowTodayCalendarAndEventsView();
        void ShowTodayEducationalTipView();
        void ShowSummeryPlanningView();
        #endregion

        #region TimeManagement Methods
        void ShowNotesAndAppointmentsListView();
        void ShowNotesAndAppointmentsView(SummeryTaskItem selectedTaskItem);
        void ShowNotesAndAppointmentsView();
        void ShowReviewAndControlView();
        void ShowCalendarCalculationsView();
        void ShowCalendarYearInOneView();
        void ShowSearchView();

        #endregion

        #region Personal Strategic Management Methods
        void ShowMyHorizonVisionView();
        void ShowOveralObjectiveView();
        //void ShowOveralObjectiveView(SummeryOveralObjective selectedOveralObjective);
        void ShowOveralObjectiveListView();
        void ShowLifePlaningView();
        void ShowSecondaryObjectivesListView();
        void ShowSecondaryObjectiveView();
        void ShowPlaningView();
        void ShowProgramAdvanceControlView();
        #endregion

        #region ManagementContacts Methods
        void ShowSendingRelationEmailsView();
        void ShowGeneralContactsView();
        #endregion


        #region EducationManagement Methods
        void ShowConversionMeasuresView();
        void ShowCityDistanceView();
        void ShowEduacationBlogLibraryView();
        void ShowEduacationBlogLibraryListView();
        void ShowDailyShortTipsLibraryView();
        void ShowDailyShortTipsLibraryListView();
        void ShowLibraryImportExportFileView();
        #endregion

        #region PersonalFinancialManagement Methods
        void ShowFinancialAccountsView();
        void ShowFinancialAccountsListView();
        void ShowPersonalBudgetingView();
        void ShowPersonalBudgetingListView();
        void ShowRegisterReceiptAndPaymentView();
        void ShowRegisterReceiptAndPaymentListView();
        void ShowMaturityAndChequeListView();
        void ShowMaturityAndChequeView();
        #endregion

        #region QuranAndPrayer Methods
        void ShowPrayerTimesView();
        void ShowAzanAndPrayerPlayingView();
        #endregion

        #region Settings

        void ShowSoftwareSettingsView();
        void ShowCalendarSettingsView();
        void ShowCategorySettingsView();
        void ShowDisplaySettingsView();
        void ShowGeneralSettingsView();
        void ShowUserSettingsView();
        void ShowPrayerTimeSettingsView();

        #endregion

        #region RelaxationManagement

        void ShowCordonStressExamView();
        void ShowDepressionBeckExamView();
        void ShowPersonalityBrigadeExamView();
        void ShowPsychologyExamView();
        void ShowRelaxationWaysExamView();

        #endregion


        void ShowTimeLineView();

        void ShowAppoinmentView();
    }
}

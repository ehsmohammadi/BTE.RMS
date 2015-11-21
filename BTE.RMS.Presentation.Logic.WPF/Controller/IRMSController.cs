using System;
using BTE.Presentation;

namespace BTE.RMS.Presentation.Logic.WPF.Controller
{
    public interface IRMSController
    {
        #region Public
        void BeginInvokeOnDispatcher(Action action);
        void HandleException(Exception exp);
        void Close(WorkspaceViewModel workspaceViewModel);
        void ShowMainWindow();
        void Logout();
        #endregion

        #region TodayMethods

        void ShowTodayCalendarAndEventsView();
        void ShowTodayEducationalTipView();
        void ShowSummeryPlanningView();
        #endregion

        #region TimeManagement Methods
        void ShowNotesAndAppointmentsListView();
        void ShowNotesAndAppointmentsView();
        void ShowReviewAndControlView();
        void ShowCalendarCalculationsView();
        #endregion

        #region Personal Strategic Management Methods
        void ShowMyHorizonVisionView();
        void ShowOveralObjectiveView();
        void ShowOveralObjectiveListView();
        void ShowLifePlaningView();
        void ShowSecondaryObjectivesListView();
        void ShowSecondaryObjectiveView();
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


    }
}

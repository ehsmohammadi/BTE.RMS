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
        //void ShowReviewView();
        void ShowCalendarCalculationsView();
        #endregion

        #region Personal Strategic Management Methods
        void ShowMyHorizonVisionView();
        void ShowOveralObjectiveListView();
        void ShowLifePlaningView();
        void ShowSecondaryObjectivesListView();
        #endregion

        #region ManagementContacts Methods
        void ShowSendingOccasionEmailsView();
        void ShowGeneralContactsView();
        #endregion


        #region EducationManagement Methods
        void ShowConversionMeasuresView();
        void ShowCitiesDistanceView();
        void ShowEduacationBlogLibraryView();
        void ShowDailyShortTipsLibraryView();
        void ShowLibraryImportExportFileView();
        #endregion

        #region PersonalFinancialManagement Methods
        void ShowFinancialAccountsView();
        void ShowPersonalBudgetingView();
        void ShowRegisterDownloadsAndPaysView();
        void ShowMaturityAndCzechsView();
        #endregion

        #region QuranAndPrayer Methods
        void ShowPrayerTimesView();
        void ShowAzanAndPrayerPlayingView();
        #endregion


    }
}

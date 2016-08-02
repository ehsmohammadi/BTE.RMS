using System;
using BTE.Presentation;

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

        void ShowTimeLineView();

        void ShowAppoinmentView();


        void ShowYearView();
    }
}

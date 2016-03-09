using System;

namespace BTE.Presentation
{
    public interface IViewManager
    {
        void BeginInvokeOnDispatcher(Action action);
        void ShowMainWindow(IView mainWindow);
        void ShowInMainWindow(IView view);
        void ShowInWindow(IView view);   
        object ContentPresenter { get; set; }
        void Close(IView view);
        bool ShowConfirmationMessage(string title, string text);
        void ShowMessage(string message);
    }
}

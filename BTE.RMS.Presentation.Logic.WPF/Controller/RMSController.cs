using System;
using BTE.Core;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Meeting.View;
using BTE.RMS.Presentation.Logic.Meeting.ViewModel;
using BTE.RMS.Presentation.Logic.ViewModels.Timeline;
using BTE.RMS.Presentation.Logic.ViewModels.TimeView.YearView;
using BTE.RMS.Presentation.Logic.Views;
using BTE.RMS.Presentation.Logic.WPF.Views;

namespace BTE.RMS.Presentation.Logic.Controller
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

        #region Public

        public void ShowMessage(string message)
        {
            viewManager.ShowMessage(message);
        }

        public bool ShowConfirmationMessage(string title, string text)
        {
            return viewManager.ShowConfirmationMessage(title, text);
        }

        public void BeginInvokeOnDispatcher(Action action)
        {
            throw new NotImplementedException();
        }

        public void HandleException(Exception exp)
        {
            throw new NotImplementedException();
        }


        public void Close(WorkspaceViewModel workspaceViewModel)
        {
            var view = workspaceViewModel.View;
            viewManager.Close(view);
            workspaceViewModel.Dispose();
        }

        public void ShowMainWindow()
        {
            var vm = ServiceLocator.Current.GetInstance<MainViewModel>();
            var view = ServiceLocator.Current.GetInstance<IMainWindow>();
            //vm.Load();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void Logout()
        {
        }
        public void FullScreenMode()
        {

        }

        public void SendToTry()
        {

        }

        #endregion

        public void ShowAppoinmentView()
        {
            var vm = ServiceLocator.Current.GetInstance<MeetingVM>();
            var view = ServiceLocator.Current.GetInstance<IMeeting>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }
        public void ShowTimeLineView()
        {
            var vm = ServiceLocator.Current.GetInstance<TimelineVM>();
            var view = ServiceLocator.Current.GetInstance<ITimeline>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }

        public void ShowYearView()
        {
            var vm = ServiceLocator.Current.GetInstance<YearViewVM>();
            var view = ServiceLocator.Current.GetInstance<IYearView>();
            view.ViewModel = vm;
            viewManager.ShowInMainWindow(view);
        }
    }
}

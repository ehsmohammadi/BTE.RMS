using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

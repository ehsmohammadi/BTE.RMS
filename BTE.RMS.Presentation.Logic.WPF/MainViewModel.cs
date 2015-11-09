using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.Controller;

namespace BTE.RMS.Presentation.Logic.WPF
{
    public class MainVM : WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;

        #endregion

        #region Properties

        private CommandViewModel signOutCommand;
        public CommandViewModel SignOutCommand
        {
            get
            {
                if (signOutCommand == null)
                {
                    signOutCommand = new CommandViewModel("خروج", new DelegateCommand(signOut));
                }
                return signOutCommand;
            }
        }

        #endregion

        #region Constructor

        public MainVM()
        {
            DisplayName = "سیستم مدیریت آرامش بانک مهر";

        }

        public MainVM(IRMSController controller)
        {
            this.controller = controller;
            DisplayName = "سیستم مدیریت آرامش بانک مهر";
        }

        #endregion

        #region Commands

        private ObservableCollection<CommandViewModel> toDayCommands;
        public ObservableCollection<CommandViewModel> ToDayCommands
        {
            get
            {
                return toDayCommands ?? (toDayCommands = new ObservableCollection<CommandViewModel>(createToDayCommands()));
            }
        }

        private ObservableCollection<CommandViewModel> timeManagementCommands;
        public ObservableCollection<CommandViewModel> TimeManagementCommands
        {
            get
            {
                return timeManagementCommands ?? (timeManagementCommands = new ObservableCollection<CommandViewModel>(createTimeManagementCommands()));
            }
        }


        private ObservableCollection<CommandViewModel> personalStrategicManagementCommands;
        public ObservableCollection<CommandViewModel> PersonalStrategicManagementCommands
        {
            get
            {
                return personalStrategicManagementCommands ?? (personalStrategicManagementCommands = new ObservableCollection<CommandViewModel>(createPersonalStrategicManagementCommands()));
            }
        }


        #endregion

        #region Command Methods

        private ObservableCollection<CommandViewModel> createToDayCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
                new CommandViewModel("تقویم و مناسبت های امروز", new DelegateCommand(
                    () =>
                    {
                        controller.ShowTodayCalendarAndEventsView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("مطالب و نکات آموزشی امروز", new DelegateCommand(
                    () =>
                    {
                        controller.ShowTodayEducationalTipView();
                    }
                    )));
            cmdList.Add(
               new CommandViewModel("خلاصه برنامه امروز", new DelegateCommand(
                   () =>
                   {
                       controller.ShowSummeryPlanningView();
                   }
                   )));


            return cmdList;

        }

        private ObservableCollection<CommandViewModel> createTimeManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("یادداشت ها /قرار ملاقات", new DelegateCommand(
                   () =>
                   {
                       controller.ShowNotesAndAppointmentsListView();
                   }
                   )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createPersonalStrategicManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("برنامه ریزی عمر", new DelegateCommand(
                   () =>
                   {
                       controller.ShowLifePlaningView();
                   }
                   )));
            return cmdList;

        }

        #endregion

        #region Methods

        private void signOut()
        {
            controller.Logout();
        }
        #endregion
    }
}

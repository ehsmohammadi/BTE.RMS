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

        #endregion

        #region Command Methods

        private ObservableCollection<CommandViewModel> createToDayCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("خلاصه برنامه امروز", new DelegateCommand(
                   () =>
                   {
                       controller.ShowSummeryPlanningView();
                       //controller.GetRemoteInstance<IPeriodController>(
                       //    (res, exp) =>
                       //    {
                       //        controller.HideBusyIndicator();
                       //        if (res != null)
                       //        {
                       //            res.ShowPeriodList(isShiftPressed);
                       //        }
                       //        else if (exp != null)
                       //        {
                       //            controller.HandleException(exp);
                       //        }
                       //    });
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

using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic
{
    public sealed class MainViewModel : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ISyncService syncService;

        #endregion

        #region Properties

        private bool selective;
        public bool Selective
        {
            get
            {
                return selective;
            }
            set
            {
                this.selective = value;
                OnPropertyChanged("Selective");
            }
        }

        public CommandViewModel SelectMenu
        {
            get
            {
                return new CommandViewModel("منوی روزانه", new DelegateCommand(Selectmenu));
            }
        }

        public CommandViewModel HideMenu
        {
            get
            {
                return new CommandViewModel("منوی روزانه", new DelegateCommand(Hidemenu));
            }
        }

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

        private CommandViewModel fullScreenCommand;

        public CommandViewModel FullScreenCommand
        {
            get
            {
                if (fullScreenCommand == null)
                {
                    fullScreenCommand = new CommandViewModel("نمایش تمام صفحه", new DelegateCommand(fullscreen));
                }
                return fullScreenCommand;
            }
        }

        private CommandViewModel sendToTryCommand;

        public CommandViewModel SendToTryCommand
        {
            get
            {
                if(sendToTryCommand==null)
                {
                    sendToTryCommand=new CommandViewModel("فرستادن به Try",new DelegateCommand(sendToTry));
                }
                return sendToTryCommand;
            }
        }

        private CommandViewModel aboutUsCommand;

        public CommandViewModel AboutUsCommand
        {
            get
            {
                if(aboutUsCommand==null)
                {
                    aboutUsCommand=new CommandViewModel("درباره ما",new DelegateCommand(aboutUs));
                }
                return aboutUsCommand;
            }
        }

        private CommandViewModel helpCommand;

        public CommandViewModel HelpCommand
        {
            get
            {
                if (helpCommand == null)
                {
                    helpCommand=new CommandViewModel("راهنما",new DelegateCommand(help));
                }
                return helpCommand;
            }
        }

        private CommandViewModel settingCommand;

        public CommandViewModel SettingCommand
        {
            get
            {
                if (settingCommand==null)
                {
                    settingCommand=new CommandViewModel("تنظیمات",new DelegateCommand(setting));
                }
                return settingCommand;
            }
        }

        public CommandViewModel SyncCommand
        {
            get
            {
                if (settingCommand == null)
                {
                    settingCommand = new CommandViewModel("همگام سازی", new DelegateCommand(sync));
                }
                return settingCommand;
            }
        }
        #endregion

        #region Constructor

        public MainViewModel()
        {
            DisplayName = "سیستم مدیریت آرامش بانک مهر";

        }

        public MainViewModel(IRMSController controller,ISyncService syncService)
        {
            this.controller = controller;
            this.syncService = syncService;
            DisplayName = "سیستم مدیریت آرامش بانک مهر";
        }

        #endregion

        #region Commands


        private ObservableCollection<CommandViewModel> timeLineCommands;
        public ObservableCollection<CommandViewModel> TimeLineCommands
        {
            get
            {
                return timeLineCommands ?? (timeLineCommands = new ObservableCollection<CommandViewModel>(createTimeLineCommands()));
            }
        }

        #endregion

        #region Command Methods

        private ObservableCollection<CommandViewModel> createTimeLineCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
                new CommandViewModel("تقویم و مناسبت های امروز", new DelegateCommand(
                    () =>
                    {
                        //controller.ShowTodayCalendarAndEventsView();
                    }
                    )));
            //cmdList.Add(
            //    new CommandViewModel("مطالب و نکات آموزشی امروز", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowTodayEducationalTipView();
            //        }
            //        )));
            //cmdList.Add(
            //   new CommandViewModel("خلاصه برنامه امروز", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowSummeryPlanningView();
            //       }
            //       ))
            //       );


            return cmdList;

        }

        #endregion

        #region PrivateMethods

        private void Selectmenu()
        {
            Selective = true;
        }

        private void Hidemenu()
        {
            Selective = false;
        }

        private void signOut()
        {
            controller.Logout();
            OnRequestClose();
        }
        private void fullscreen()
        {
           controller.FullScreenMode();
        }
        private void sendToTry()
        {
            controller.SendToTry();
        }
        private void aboutUs()
        {
            
        }
        private void help()
        {

        }
        private void setting()
        {
            //controller.ShowSoftwareSettingsView();
        }
        private void sync()
        {
            syncService.Sync((res, exp) =>
            {
                if (exp != null)
                    controller.HandleException(exp);
                else
                {
                    controller.ShowMessage("Sync is completed.");
                }
            });
        }
        #endregion

        #region Public Methods


        #endregion

        #region Properties

        
        #endregion
   
    }
}

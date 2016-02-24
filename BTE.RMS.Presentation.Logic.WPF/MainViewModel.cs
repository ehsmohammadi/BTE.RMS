using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.Controller;

namespace BTE.RMS.Presentation.Logic
{
    public class MainViewModel : WorkspaceViewModel
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




        #endregion

        #region Constructor

        public MainViewModel()
        {
            DisplayName = "سیستم مدیریت آرامش بانک مهر";

        }

        public MainViewModel(IRMSController controller)
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


        private ObservableCollection<CommandViewModel> managementContactsCommands;
        public ObservableCollection<CommandViewModel> ManagementContactsCommands
        {
            get
            {
                return managementContactsCommands ?? (managementContactsCommands = new ObservableCollection<CommandViewModel>(createManagementContactsCommands()));
            }
        }
        private ObservableCollection<CommandViewModel> educationManagementCommands;
        public ObservableCollection<CommandViewModel> EducationManagementCommands
        {
            get
            {
                return educationManagementCommands ?? (educationManagementCommands = new ObservableCollection<CommandViewModel>(createEducationManagementCommands()));
            }
        }


        private ObservableCollection<CommandViewModel> relaxationManagementCommands;
        public ObservableCollection<CommandViewModel> RelaxationManagementCommands
        {
            get
            {
                return relaxationManagementCommands ?? (relaxationManagementCommands = new ObservableCollection<CommandViewModel>(createRelaxationManagementCommands()));
            }
        }


        private ObservableCollection<CommandViewModel> personalFinancialManagementCommands;
        public ObservableCollection<CommandViewModel> PersonalFinancialManagementCommands
        {
            get
            {
                return personalFinancialManagementCommands ?? (personalFinancialManagementCommands = new ObservableCollection<CommandViewModel>(createPersonalFinancialManagementCommands()));
            }
        }


        private ObservableCollection<CommandViewModel> quranAndPrayerCommands;
        public ObservableCollection<CommandViewModel> QuranAndPrayerCommands
        {
            get
            {
                return quranAndPrayerCommands ?? (quranAndPrayerCommands = new ObservableCollection<CommandViewModel>(createQuranAndPrayerCommands()));
            }
        }

        //private ObservableCollection<CommandViewModel> settinsCommands;
        //public ObservableCollection<CommandViewModel> SettingsCommands
        //{
        //    get
        //    {
        //        return settinsCommands ?? (settinsCommands = new ObservableCollection<CommandViewModel>(createSettinsCommands()));
        //    }
        //}
        #endregion

        #region Command Methods

        private ObservableCollection<CommandViewModel> createToDayCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //    new CommandViewModel("تقویم و مناسبت های امروز", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowTodayCalendarAndEventsView();
            //        }
            //        )));
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

        private ObservableCollection<CommandViewModel> createRelaxationManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //   new CommandViewModel("روش های کسب آرامش", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowRelaxationWaysExamView();
            //       }
            //       )));
            //cmdList.Add(
            //    new CommandViewModel("آزمون های روانشناسی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowPsychologyExamView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("آزمون استرس کوردون", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowCordonStressExamView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("آزمون تعیین تیپ شخصیتی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowPersonalityBrigadeExamView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("آزمون افسردگی بک", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowDepressionBeckExamView();
            //        }
            //        )));
            return cmdList;
        }

        private ObservableCollection<CommandViewModel> createTimeManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("یادداشت ها /قرار ملاقات", new DelegateCommand(
                   () =>
                   {
                       controller.ShowTaskListView();
                   }
                   )));
            //cmdList.Add(
            //    new CommandViewModel("یادداشت ها /قرار ملاقات جدید", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowNotesAndAppointmentsView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("مرور و بازبینی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowReviewAndControlView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("جستجو", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowSearchView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("تقویم سال در یک نما", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowCalendarYearInOneView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("محاسبات تقویمی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowCalendarCalculationsView();
            //        }
            //        )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createPersonalStrategicManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //    new CommandViewModel("افق چشم انداز من", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowMyHorizonVisionView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("اهداف کلی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowOveralObjectiveListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("اهداف فرعی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowSecondaryObjectivesListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("برنامه ریزی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowPlaningView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("کنترل پیشرفت برنامه", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowProgramAdvanceControlView();
            //        }
            //        )));
            //cmdList.Add(
            //   new CommandViewModel("برنامه ریزی عمر", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowLifePlaningView();
            //       }
            //       )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createManagementContactsCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //   new CommandViewModel("مدیریت اطلاعات تماس", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowSendingRelationEmailsView();
            //       }
            //       )));
            //cmdList.Add(
            //    new CommandViewModel("اطلاعات تماس عمومی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowGeneralContactsView();
            //        }
            //        )));
            //cmdList.Add(
            //new CommandViewModel("ارسال ایمیل های مناسبتی", new DelegateCommand(
            //    () =>
            //    {
            //        controller.ShowSendingRelationEmailsView();
            //    }
            //    )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createEducationManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //   new CommandViewModel("تبدیل مقیاس ها", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowConversionMeasuresView();
            //       }
            //       )));
            //cmdList.Add(
            //    new CommandViewModel("فاصله شهرهای کشور", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowCityDistanceView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("کتابخانه مطالب آموزشی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowEduacationBlogLibraryListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("کتابخانه نکات کوتاه روز", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowDailyShortTipsLibraryListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("Import/Export کتابخانه", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowLibraryImportExportFileView();
            //        }
            //        )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createPersonalFinancialManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //   new CommandViewModel("حساب های مالی", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowFinancialAccountsListView();
            //       }
            //       )));
            //cmdList.Add(
            //    new CommandViewModel("بودجه ریزی شخصی", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowPersonalBudgetingListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("ثبت دریافت ها و پرداخت ها", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowRegisterReceiptAndPaymentListView();
            //        }
            //        )));
            //cmdList.Add(
            //    new CommandViewModel("ثبت سررسید تعهدات و چک ها", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowMaturityAndChequeListView();
            //        }
            //        )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createQuranAndPrayerCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            //cmdList.Add(
            //   new CommandViewModel("محاسبه اوقات شرعی", new DelegateCommand(
            //       () =>
            //       {
            //           controller.ShowPrayerTimesView();
            //       }
            //       )));
            //cmdList.Add(
            //    new CommandViewModel("پخش اذان و نیایش", new DelegateCommand(
            //        () =>
            //        {
            //            controller.ShowAzanAndPrayerPlayingView();
            //        }
            //        )));
            return cmdList;

        }


        //private ObservableCollection<CommandViewModel> createSettinsCommands()
        //{
        //    var cmdList = new ObservableCollection<CommandViewModel>();
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات عمومی", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowGeneralSettingsView();
        //            }
        //            )));
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات کاربری", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowUserSettingsView();
        //            }
        //            )));
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات تقویمی", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowCalendarSettingsView();
        //            }
        //            )));
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات اوقات شرعی", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowPrayerTimeSettingsView();
        //            }
        //            )));
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات رسته ها", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowCategorySettingsView();
        //            }
        //            )));
        //    cmdList.Add(
        //        new CommandViewModel("تنظیمات نمایشی", new DelegateCommand(
        //            () =>
        //            {
        //                controller.ShowDisplaySettingsView();
        //            }
        //            )));

        //    return cmdList;

        //}


        #endregion

        #region PrivateMethods

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
        #endregion

        #region Public Methods


        #endregion
    }
}

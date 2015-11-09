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
            cmdList.Add(
                new CommandViewModel("مرور و بازبینی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowReviewView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("محاسبات تقویمی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowCalendarCalculationsView();
                    }
                    )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createPersonalStrategicManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
                new CommandViewModel("افق چشم انداز من", new DelegateCommand(
                    () =>
                    {
                        controller.ShowMyHorizonVisionView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("اهداف کلی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowOveralObjectiveListView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("اهداف فرعی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowSecondaryObjectivesListView();
                    }
                    )));
            cmdList.Add(
               new CommandViewModel("برنامه ریزی عمر", new DelegateCommand(
                   () =>
                   {
                       controller.ShowLifePlaningView();
                   }
                   )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createManagementContactsCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("مدیریت اطلاعات تماس", new DelegateCommand(
                   () =>
                   {
                       controller.ShowSendingOccasionEmailsView();
                   }
                   )));
            cmdList.Add(
           new CommandViewModel("اطلاعات تماس عمومی", new DelegateCommand(
               () =>
               {
                   controller.ShowGeneralContactsView();
               }
               )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createEducationManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("تبدیل مقیاس ها", new DelegateCommand(
                   () =>
                   {
                       controller.ShowConversionMeasuresView();
                   }
                   )));
            cmdList.Add(
                new CommandViewModel("فاصله شهرهای کشور", new DelegateCommand(
                    () =>
                    {
                        controller.ShowCitiesDistanceView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("کتابخانه مطالب آموزشی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowEduacationBlogLibraryView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("کتابخانه نکات کوتاه روز", new DelegateCommand(
                    () =>
                    {
                        controller.ShowDailyShortTipsLibraryView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("Import/Export کتابخانه", new DelegateCommand(
                    () =>
                    {
                        controller.ShowLibraryImportExportFileView();
                    }
                    )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createPersonalFinancialManagementCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("حساب های مالی", new DelegateCommand(
                   () =>
                   {
                       controller.ShowFinancialAccountsView();
                   }
                   )));
            cmdList.Add(
                new CommandViewModel("بودجه ریزی شخصی", new DelegateCommand(
                    () =>
                    {
                        controller.ShowPersonalBudgetingView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("ثبت دریافت ها و پرداخت ها", new DelegateCommand(
                    () =>
                    {
                        controller.ShowRegisterDownloadsAndPaysView();
                    }
                    )));
            cmdList.Add(
                new CommandViewModel("ثبت سررسید تعهدات و چک ها", new DelegateCommand(
                    () =>
                    {
                        controller.ShowMaturityAndCzechsView();
                    }
                    )));
            return cmdList;

        }


        private ObservableCollection<CommandViewModel> createQuranAndPrayerCommands()
        {
            var cmdList = new ObservableCollection<CommandViewModel>();
            cmdList.Add(
               new CommandViewModel("محاسبه اوقات شرعی", new DelegateCommand(
                   () =>
                   {
                       controller.ShowPrayerTimesView();
                   }
                   )));
            cmdList.Add(
                new CommandViewModel("پخش اذان و نیایش", new DelegateCommand(
                    () =>
                    {
                        controller.ShowAzanAndPrayerPlayingView();
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

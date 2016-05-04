using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class EduacationBlogLibraryListVM : WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ILibraryServiceWrapper libraryService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<CrudLibrary> libraryNameList;

        public ObservableCollection<CrudLibrary> LibraryNameList
        {
            get { return libraryNameList; }
            set { this.SetField(p => p.LibraryNameList, ref libraryNameList, value); }
        }

        private CrudLibrary selectedLibraryName;

        public CrudLibrary SelectedLibraryName
        {
            get { return selectedLibraryName; }
            set { this.SetField(p => p.SelectedLibraryName, ref selectedLibraryName, value); }
        }
        private ObservableCollection<SummeryEduacationBlog> eduacationBlogList;

        public ObservableCollection<SummeryEduacationBlog> EduacationBlogList
        {
            get { return eduacationBlogList; }
            set { this.SetField(p => p.EduacationBlogList, ref eduacationBlogList, value); }
        }

        private SummeryEduacationBlog selectedEduacationBlog;

        public SummeryEduacationBlog SelectedEduacationBlog
        {
            get { return selectedEduacationBlog; }
            set
            {
                this.SetField(p => p.SelectedEduacationBlog, ref selectedEduacationBlog, value);
            }
        }

        private CommandViewModel showLibraryCmd;

        public CommandViewModel ShowLibraryCmd
        {
            get
            {
                if (showLibraryCmd == null)
                {
                    showLibraryCmd = new CommandViewModel("[نمایش]", new DelegateCommand(showLibrary));
                }
                return showLibraryCmd;
            }
        }
        private CommandViewModel showDateFilterCmd;

        public CommandViewModel ShowDateFilterCmd
        {
            get
            {
                if (showDateFilterCmd == null)
                {
                    showDateFilterCmd = new CommandViewModel("[نمایش]", new DelegateCommand(showDateFilter));
                }
                return showDateFilterCmd;
            }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("کتابخانه جدید", new DelegateCommand(create));
                }
                return createCmd;
            }
        }

        private CommandViewModel modifyCmd;
        public CommandViewModel ModifyCmd
        {
            get
            {
                if (modifyCmd == null)
                {
                    modifyCmd = new CommandViewModel("ویرایش کتابخانه", new DelegateCommand(modify));
                }
                return modifyCmd;
            }
        }

        private CommandViewModel deleteCmd;
        public CommandViewModel DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new CommandViewModel("حذف کتابخانه", new DelegateCommand(delete));
                }
                return deleteCmd;
            }
        }


        #endregion

        #region Constructors

        public EduacationBlogLibraryListVM()
        {
            init();
            
        }
        public EduacationBlogLibraryListVM(IRMSController controller,ILibraryServiceWrapper libraryService)
        {
            this.controller = controller;
            this.libraryService = libraryService;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه مطالب آموزشی";
            EduacationBlogList = new ObservableCollection<SummeryEduacationBlog>();
            libraryNameList = new ObservableCollection<CrudLibrary>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void showDateFilter()
        {

        }
        private void showLibrary()
        {
            libraryService.ShowSelectedEduacationLibrary((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    EduacationBlogList = new ObservableCollection<SummeryEduacationBlog>(res);
                }
                else
                {
                    controller.HandleException(exp);
                }
            }, SelectedLibraryName);
        }
        private void create()
        {
            controller.ShowEduacationBlogLibraryView();
        }

        public void modify()
        {
            controller.ShowEduacationBlogLibraryView();
         
        }
        public void delete()
        {
            controller.ShowEduacationBlogLibraryView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            libraryService.GetAllEduacationBlogList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        eduacationBlogList = new ObservableCollection<SummeryEduacationBlog>(res);
                    }
                    else controller.HandleException(exp);
                });
            libraryService.GetAllEduacationLibraryNameList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        libraryNameList = new ObservableCollection<CrudLibrary>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

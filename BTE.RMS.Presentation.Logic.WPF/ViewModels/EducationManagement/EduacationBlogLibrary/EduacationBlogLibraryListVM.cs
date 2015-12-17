using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class EduacationBlogLibraryListVM : WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IEduacationBlogLibraryServiceWrapper eduacationBlogLibraryService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<EduacationBlog> eduacationBlogs;

        public ObservableCollection<EduacationBlog> EduacationBlogs
        {
            get { return eduacationBlogs; }
            set { this.SetField(p => p.EduacationBlogs, ref eduacationBlogs, value); }
        }

        private EduacationBlog selectedEduacationBlog;

        public EduacationBlog SelectedEduacationBlog
        {
            get { return selectedEduacationBlog; }
            set
            {
                this.SetField(p => p.SelectedEduacationBlog, ref selectedEduacationBlog, value);
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
        public EduacationBlogLibraryListVM(IRMSController controller, IEduacationBlogLibraryServiceWrapper eduacationBlogLibraryService)
        {
            this.controller = controller;
            this.eduacationBlogLibraryService = eduacationBlogLibraryService;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه مطالب آموزشی";
            EduacationBlogs = new ObservableCollection<EduacationBlog>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
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
            eduacationBlogLibraryService.GetAllEduacationBlogLibraryList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        EduacationBlogs = new ObservableCollection<EduacationBlog>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

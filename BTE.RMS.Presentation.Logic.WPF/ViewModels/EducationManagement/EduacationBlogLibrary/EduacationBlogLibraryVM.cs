using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class EduacationBlogLibraryVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ILibraryServiceWrapper libraryService;
        #endregion

        #region Properties & BackFields

        private SummeryEduacationBlog eduacationBlog;

        public SummeryEduacationBlog EduacationBlog
        {
            get { return eduacationBlog; }
            set { this.SetField(p=>p.EduacationBlog,ref eduacationBlog,value);}
        }
        private CommandViewModel registerCmd;
        public CommandViewModel RegisterCmd
        {
            get
            {
                if (registerCmd == null)
                {
                    registerCmd = new CommandViewModel("ثبت", new DelegateCommand(register));
                }
                return registerCmd;
            }
        }
        private CommandViewModel backCmd;
        public CommandViewModel BackCmd
        {
            get
            {
                if (backCmd == null)
                {
                    backCmd = new CommandViewModel("بازگشت", new DelegateCommand(back));
                }
                return backCmd;
            }
        }
        #endregion

        #region Constructors

        public EduacationBlogLibraryVM(IRMSController controller, ILibraryServiceWrapper libraryService)
        {
            this.controller = controller;
            this.libraryService = libraryService;
            init();
        }

        public EduacationBlogLibraryVM()
        {
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه مطالب آموزشی";
            EduacationBlog=new SummeryEduacationBlog();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            //libraryService.CreateEduacationBlog((res, exp) =>
            //{
            //    HideBusyIndicator();
            //    if (exp == null)
            //    {
            //        EduacationBlog = new SummeryEduacationBlog(res);
            //    }
            //    else
            //    {
            //        controller.HandleException(exp);
            //    }
            //}, EduacationBlog);
            controller.ShowEduacationBlogLibraryListView();
        }
        private void back()
        {
            controller.ShowEduacationBlogLibraryListView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {

        }

        #endregion
    }
}

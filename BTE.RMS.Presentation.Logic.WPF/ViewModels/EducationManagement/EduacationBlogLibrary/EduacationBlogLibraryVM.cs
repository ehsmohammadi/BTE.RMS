using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<SummeryEduacationBlog> eduacationBlogList;

        public List<SummeryEduacationBlog> EduacationBlogList
        {
            get { return eduacationBlogList; }
            set { this.SetField(p=>p.EduacationBlogList,ref eduacationBlogList,value);}
        } 
        
        private SummeryEduacationBlog eduacationBlog;

        public SummeryEduacationBlog EduacationBlog
        {
            get { return eduacationBlog; }
            set { this.SetField(p=>p.EduacationBlog,ref eduacationBlog,value);}
        }

        private CrudLibrary crudLibrary;

        public CrudLibrary CrudLibrary
        {
            get { return crudLibrary; }
            set { this.SetField(p=>p.CrudLibrary,ref crudLibrary,value);}
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
            CrudLibrary=new CrudLibrary();
            EduacationBlogList=new List<SummeryEduacationBlog>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            libraryService.CreateCrudEduacationBlog((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    CrudLibrary = new CrudLibrary();
                }
                else
                {
                    controller.HandleException(exp);
                }
            }, CrudLibrary);
            libraryService.CreateSummeryEduacationBlog((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    EduacationBlogList=new List<SummeryEduacationBlog>();
                }
                else
                {
                    controller.HandleException(exp);
                }
            }, EduacationBlogList);
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

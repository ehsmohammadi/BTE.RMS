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
        private readonly IEduacationBlogLibrariesServiceWrapper eduacationBlogLibrariesService;
        #endregion

        #region Properties & BackFields

        private ObservableCollection<EduacationBlogLibrary> eduacationBlogLibraries;

        public ObservableCollection<EduacationBlogLibrary> EduacationBlogLibraries
        {
            get { return eduacationBlogLibraries; }
            set { this.SetField(p => p.EduacationBlogLibraries, ref eduacationBlogLibraries, value); }
        }

        private EduacationBlogLibrary selectedEduacationBlogLibrary;

        public EduacationBlogLibrary SelectedEduacationBlogLibrary
        {
            get { return selectedEduacationBlogLibrary; }
            set
            {
                this.SetField(p => p.SelectedEduacationBlogLibrary, ref selectedEduacationBlogLibrary, value);
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
        public EduacationBlogLibraryListVM(IRMSController controller, IEduacationBlogLibrariesServiceWrapper eduacationBlogLibrariesService)
        {
            this.controller = controller;
            this.eduacationBlogLibrariesService = eduacationBlogLibrariesService;
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه مطالب آموزشی";
            EduacationBlogLibraries = new ObservableCollection<EduacationBlogLibrary>();
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
            eduacationBlogLibrariesService.GetAllEduacationBlogLibrarList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        EduacationBlogLibraries = new ObservableCollection<EduacationBlogLibrary>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}

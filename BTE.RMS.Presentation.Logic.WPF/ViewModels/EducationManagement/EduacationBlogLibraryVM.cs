using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.EducationManagement;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class EduacationBlogLibraryVM : WorkspaceViewModel
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

        #endregion

        #region Constructors

        public EduacationBlogLibraryVM()
        {
            init();
        }
        public EduacationBlogLibraryVM(IRMSController controller,IEduacationBlogLibrariesServiceWrapper eduacationBlogLibrariesService)
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

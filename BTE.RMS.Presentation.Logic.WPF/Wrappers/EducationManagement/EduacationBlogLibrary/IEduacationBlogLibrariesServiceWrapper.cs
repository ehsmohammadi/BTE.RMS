using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement
{
    public interface IEduacationBlogLibrariesServiceWrapper:IServiceWrapper
    {
        void GetAllEduacationBlogLibrarList(Action<List<EduacationBlogLibrary>, Exception> action);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ILibraryServiceWrapper:IServiceWrapper
    {
        void GetAllDailyShortTipList(Action<List<SummeryDailyShortTip>, Exception> action);
        void GetAllEduacationBlogList(Action<List<SummeryEduacationBlog>, Exception> action);
        void GetAllEduacationLibraryNameList(Action<List<CrudLibrary>, Exception> action);
        void GetAllDailyLibraryNameList(Action<List<CrudLibrary>, Exception> action);
        void ShowSelectedDailyLibrary(Action<List<SummeryDailyShortTip>, Exception> action, CrudLibrary selectedLibraryName);
        void ShowSelectedEduacationLibrary(Action<List<SummeryEduacationBlog>, Exception> action, CrudLibrary selectedLibraryName);
        void CreateCrudEduacationBlog(Action<CrudLibrary,Exception> action, CrudLibrary crudLibrary);
        void CreateSummeryEduacationBlog(Action<SummeryEduacationBlog, Exception> action, List<SummeryEduacationBlog> eduacation);
        void CreateCrudDailyShortTip(Action<CrudLibrary, Exception> action, CrudLibrary crudLibrary);
        void CreateSummeryDailyShortTip(Action<SummeryDailyShortTip, Exception> action, List<SummeryDailyShortTip> daily);
        //void DeleteDailyShortTip(Action<Action<CrudLibrary>, Exception> action,CrudLibrary selectedLibrary);
    }
}

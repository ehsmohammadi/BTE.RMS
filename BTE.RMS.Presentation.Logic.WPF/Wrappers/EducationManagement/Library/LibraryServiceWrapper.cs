using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class LibraryServiceWrapper : ILibraryServiceWrapper
    {
        private long getNextId()
        {
            return crudLibraryList.Max(t => t.Id) + 1;
        }
        private static List<CrudLibrary> crudLibraryList = new List<CrudLibrary>
        {
            new CrudLibrary
            {
                Id = 1,
                Name = "کتابخانه پیش فرض مطالب آموزشی",
                Description = "کتابخانه ای جهت نمایش اطلاعات",
                LibraryType = LibraryType.EduacationBlog,
            },
            new CrudLibrary
            {
                Id = 2,
                Name = "کتابخانه من",
                Description = "کتابخانه ای جهت نمایش اطلاعات",
                LibraryType = LibraryType.EduacationBlog
            },
            new CrudLibrary
            {
                Id = 3,
                Description = "کتابخانه پیش فرض نکات روز",
                Name = "کتابخانه ای جهت نمایش اطلاعات",
                LibraryType = LibraryType.DailyShortTip
            },
                        new CrudLibrary
            {
                Id = 4,
                Description = "کتابخانه پیش فرض نکات روز2",
                Name = "2کتابخانه ای جهت نمایش اطلاعات",
                LibraryType = LibraryType.DailyShortTip
            }
            
        };

        private static List<SummeryEduacationBlog> eduacationBlogList = new List<SummeryEduacationBlog>
        {
            new SummeryEduacationBlog
            {
                Id = 1,
                Context = "تیتر1",
                CrudId = 1,
                HeadLine = "تیتر1"
            },
            new SummeryEduacationBlog
            {
                Id = 2,
                HeadLine = "2تیتر",
                Context = "تیتر2",
                CrudId = 2,

            },
            new SummeryEduacationBlog
            {
                Id = 3,
                CrudId = 1,
                Context = "تیتر3",
                HeadLine = "تیتر3",

            },
            new SummeryEduacationBlog
            {
                Id = 4,
                Context = "تیتر4",
                CrudId = 2,
                HeadLine = "تیتر4"
            }
        };
        private static List<SummeryDailyShortTip> dailyShortTipList = new List<SummeryDailyShortTip>
        {
            new SummeryDailyShortTip
            {
                Id = 1,
                CrudId = 3,
                Context = "تیتر1",
                Source = "تیتر1",
            },
                        new SummeryDailyShortTip
            {
                Id = 2,
                CrudId = 3,
                Context = "تیتر2",
                Source = "تیتر2",
            },            new SummeryDailyShortTip
            {
                Id = 3,
                CrudId = 3,
                Context = "تیتر3",
                Source = "تیتر3",
            },            new SummeryDailyShortTip
            {
                Id = 4,
                CrudId = 3,
                Context = "تیتر4",
                Source = "تیتر4",
            },            new SummeryDailyShortTip
            {
                Id = 5,
                CrudId = 4,
                Context = "تیتر5",
                Source = "تیتر5",
            },            new SummeryDailyShortTip
            {
                Id = 6,
                CrudId = 4,
                Context = "تیتر6",
                Source = "تیتر6",
            },
        };
        public void GetAllDailyShortTipList(Action<List<SummeryDailyShortTip>, Exception> action)
        {
            var summeryDailyShort = dailyShortTipList.Select(
                t =>
                    new SummeryDailyShortTip
                    {
                        Id = t.Id,
                        CrudId = crudLibraryList.Single(c => c.Id == t.CrudId).Id,
                        Context = t.Context,
                        Source = t.Source
                    }
                ).ToList();
            action(summeryDailyShort, null);
        }

        public void GetAllEduacationBlogList(Action<List<SummeryEduacationBlog>, Exception> action)
        {
            var summeryEduacation = eduacationBlogList.Select(
                t =>
                    new SummeryEduacationBlog
                    {
                        Id = t.Id,
                        //CrudId = crudEduacationBlogList.Single(c=> c.Id==t.CrudId).Id,
                        CrudId = crudLibraryList.Single(c => c.Id == t.CrudId).Id,
                        Context = t.Context,
                        HeadLine = t.HeadLine,
                    }

                ).ToList();
            action(summeryEduacation, null);
        }

        public void GetAllEduacationLibraryNameList(Action<List<CrudLibrary>, Exception> action)
        {
            action(crudLibraryList.Where(e => e.LibraryType == LibraryType.EduacationBlog).ToList(), null);
        }

        public void GetAllDailyLibraryNameList(Action<List<CrudLibrary>, Exception> action)
        {
            action(crudLibraryList.Where(e => e.LibraryType == LibraryType.DailyShortTip).ToList(), null);
        }

        public void ShowSelectedDailyLibrary(Action<List<SummeryDailyShortTip>, Exception> action, CrudLibrary selectedLibraryName)
        {
            var summeryDailyShort = dailyShortTipList.Where(e => e.CrudId == selectedLibraryName.Id).ToList();
            action(summeryDailyShort, null);
        }

        public void ShowSelectedEduacationLibrary(Action<List<SummeryEduacationBlog>, Exception> action, CrudLibrary selectedLibraryName)
        {
            var summeryEduacation = eduacationBlogList.Where(e => e.CrudId == selectedLibraryName.Id).ToList();
            action(summeryEduacation, null);
        }

        public void CreateCrudEduacationBlog(Action<CrudLibrary, Exception> action, CrudLibrary crudLibrary)
        {
            crudLibrary.LibraryType=LibraryType.EduacationBlog;
            crudLibrary.Id = getNextId();
            crudLibraryList.Add(crudLibrary);
        }

        public void CreateSummeryEduacationBlog(Action<SummeryEduacationBlog, Exception> action, List<SummeryEduacationBlog> eduacation)
        {
            foreach (var item in eduacation)
            {
                item.CrudId = crudLibraryList.Max(t => t.Id);
                item.Id = eduacationBlogList.Max(t => t.Id) + 1;
                eduacationBlogList.Add(item);
            }
        }


        public void CreateCrudDailyShortTip(Action<CrudLibrary, Exception> action, CrudLibrary crudLibrary)
        {
            crudLibrary.LibraryType=LibraryType.DailyShortTip;
            crudLibrary.Id = getNextId();
            crudLibraryList.Add(crudLibrary);
        }

        public void CreateSummeryDailyShortTip(Action<SummeryDailyShortTip, Exception> action, List<SummeryDailyShortTip> daily)
        {
            foreach (var item in daily)
            {
                item.CrudId = crudLibraryList.Max(t => t.Id);
                item.Id = dailyShortTipList.Max(t => t.Id) + 1;
                dailyShortTipList.Add(item);
            }
        }

        //public void DeleteDailyShortTip(Action<Action<CrudLibrary>, Exception> action, CrudLibrary selectedLibrary)
        //{
        //    //var summeryEduacation = eduacationBlogList.Where(e => e.CrudId == selectedLibraryName.Id).ToList();
        //    //action(summeryEduacation, null);
        //    //crudLibraryList.Remove(crudLibraryList.Where(e=>e.Id==selectedLibrary.Id).ToList());
        //}
    }
}

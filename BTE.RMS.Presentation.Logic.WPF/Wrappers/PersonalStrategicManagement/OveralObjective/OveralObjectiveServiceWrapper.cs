using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeOveralObjectiveServiceWrapper : IOveralObjectiveServiceWrapper
    {

        #region List
        private static List<CrudOveralObjective> overalObjectiveList=new List<CrudOveralObjective>
        {
            new CrudOveralObjective
            {
                Id = 1,
                Description = "سلام ایران",
                Overview = "سلام",
                PeriorityTypeId = 2,
                Title = "سلام ایرانیان"
            }
        };
        private static List<PeriorityType> periorityTypeList = new List<PeriorityType>
        {
            new PeriorityType
            {
                Id = 1,
                Title = "A",
                Description = "مهم - فوری"
            },
            new PeriorityType
            {
                Id = 2,
                Title = "B",
                Description = "غیر مهم - فوری"
            },
            new PeriorityType
            {
                Id = 3,
                Title = "C",
                Description = "مهم - غیر فوری"
            },
            new PeriorityType
            {
                Id = 4,
                Title = "D",
                Description = "غیر مهم - غیر فوری"
            }

        };
        #endregion

        #region Private Method
        private long getNextId()
        {
            if (overalObjectiveList.Count == 0)
            {
                return 1;
            }
            return overalObjectiveList.Max(t => t.Id) + 1;
        }
        #endregion


        public void GetAllOveralObjectiveList(Action<List<SummeryOveralObjective>, Exception> action, SummeryOveralObjective selectedOveralObjectiveList)
        {
            if (overalObjectiveList.Count == 0)
            {
                var summeryOveralObjective = overalObjectiveList.Select(t => new SummeryOveralObjective
                {
                    PeriorityTypeTitle = periorityTypeList.Single(c => c.Id == t.PeriorityTypeId).Title,
                    Id = t.Id,
                    Description = t.Description,
                    Title = t.Title
                }).ToList();
                action(summeryOveralObjective, null);
            }
            else
            {
                var minid = overalObjectiveList.Min(c => c.Id);
                var sel = overalObjectiveList.Single(c => c.Id == minid);
                selectedOveralObjectiveList.Id = sel.Id;
                selectedOveralObjectiveList.Title = sel.Title;
                selectedOveralObjectiveList.PeriorityTypeTitle =
                    periorityTypeList.Single(c => c.Id == sel.PeriorityTypeId).Title;
                selectedOveralObjectiveList.Description = sel.Description;
                var summeryOveralObjective = overalObjectiveList.Select(t => new SummeryOveralObjective
                {
                    PeriorityTypeTitle = periorityTypeList.Single(c => c.Id == t.PeriorityTypeId).Title,
                    Id = t.Id,
                    Description = t.Description,
                    Title = t.Title
                }).ToList();
                action(summeryOveralObjective, null);
            }
        }

        public void RemoveOveralObjective(Action<SummeryOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjectiveList)
        {
            if (overalObjectiveList.Count == 0)
            {
                MessageBox.Show("سطری برای حذف کردن وجود ندارد");
            }
            else
            {
                MessageBox.Show("حذف اطلاعات کاربر " + Environment.NewLine + "((" + selectedOveralObjectiveList.Title + "))" +
                                Environment.NewLine + "با موفقیت انجام شود");
                //    //MessageBox.Show("حذف اطلاعات کاربر " + Environment.NewLine + "((" + selectedTaskItem.Title + "))" +
                //    //               Environment.NewLine + "با موفقیت انجام شود", "حذف یادداشت//قرار ملاقات", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.None, MessageBoxOptions.RightAlign);
                overalObjectiveList.Remove(overalObjectiveList.Single(c => c.Id == selectedOveralObjectiveList.Id));
            }
        }

        public void PeriorityTypeList(Action<List<PeriorityType>, Exception> action, PeriorityType selectedPeriorityType)
        {
            var sel = periorityTypeList.Single(c => c.Id==1);
            selectedPeriorityType.Id = sel.Id;
            selectedPeriorityType.Title = sel.Title;
            selectedPeriorityType.Description = sel.Description;
            action(periorityTypeList, null);
        }

        public void UpdateSelectedOveralObjective(Action<SummeryOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjectiveList,
            PeriorityType selectedPeriorityType)
        {
            var task = overalObjectiveList.Single(c => c.Id == selectedOveralObjectiveList.Id);
            task.Title = selectedOveralObjectiveList.Title;
            task.Description = selectedOveralObjectiveList.Description;
           
        }

        public void GetOveralObjective(Action<CrudOveralObjective, Exception> action, long id)
        {
            var task = overalObjectiveList.SingleOrDefault(c => c.Id == id);
            action(task, null);
        }
    }
}

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
        #region Private fields
        #endregion
        private long getNextId()
        {
            return overalObjectiveList.Max(t => t.Id) + 1;
        }

        private static List<CrudOveralObjective> overalObjectiveList = new List<CrudOveralObjective>
        {
            new CrudOveralObjective
            {
                Id = 1,
                Description = "asdasdasd",
                Overview = "asdasdasd",
                PeriorityTypeId = 1,
                Title = "asdsadasd"
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
        public void GetAllOveralObjectives(Action<List<SummeryOveralObjective>, Exception> action)
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

        public void PeriorityTypeList(Action<List<PeriorityType>, Exception> action)
        {
            action(periorityTypeList, null);
        }

        //private List<PeriorityType> periorityTypeList = Enum.GetValues(typeof(PeriorityType)).Cast<PeriorityType>().ToList();
        //public void PeriorityTypeList(Action<List<PeriorityType>, Exception> action)
        //{
        //    action(periorityTypeList, null);
        //}

        public void CreateOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective, PeriorityType periorityTypeList)
        {
            //Employee.JobType = Enum.Parse(JobType,comboBox1.SelectedItem) 
            //mployee.JobType = (JobTypeEnum)Enum.Parse(typeof(JobTypeEnum)
            //var months = Enumerable.Range(1, 12).Select(n => formatInfo.MonthNames[n])
            overalObjective.PeriorityTypeId = periorityTypeList.Id;
            overalObjective.Id = getNextId();
            overalObjectiveList.Add(overalObjective);

        }

        public void RemoveOveralObjective(Action<SummeryOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjective)
        {

            overalObjectiveList.Remove(overalObjectiveList.Single(c => c.Id == selectedOveralObjective.Id));


        }

        public void UpdateOveralObjectice(Action<CrudOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjective)
        {
            //var modify = new CrudOveralObjective
            //{
            //    Title = selectedOveralObjective.Title,
            //    Description = selectedOveralObjective.Description,
                
            //};

        }


        //public void UpdateOveralObjectice(Action<SummeryOveralObjective, Exception> action, SummeryOveralObjective selectedOveralObjective, CrudOveralObjective crudOveralObjectives)
        //{
        //    //var jhj = overalObjectiveList.FirstOrDefault(m => m.Id == id);
        //    //updateOveralObjective.Description = selectedOveralObjective.Description;
        //    //updateOveralObjective.Title = selectedOveralObjective.Title;
        //    //var modify = overalObjectiveList.FirstOrDefault(m => m.Id == selectedOveralObjective.Id);
        //    //if (modify != null)
        //    //{
        //    //    updateOveralObjective = modify;
        //    //}
        //    var modify = overalObjectiveList.Select(t =>
        //    new CrudOveralObjective()
        //    {
        //       Title = selectedOveralObjective.Title,
               
        //    }).ToList();
        //    action(modify, null);
        //}
        #region Comment Codes

        //public class UnitServiceWrapper : IUnitServiceWrapper 
        //{

        //    private readonly IUserProvider userProvider;

        //    private string baseAddress = PMSClientConfig.BaseApiAddress + "Units";

        //    public UnitServiceWrapper(IUserProvider userProvider)
        //    {
        //        this.userProvider = userProvider;
        //    }

        //    public void GetAllUnits(Action<PageResultDTO<UnitDTOWithActions>, Exception> action, int pageSize, int pageIndex)
        //    {

        //        var url = string.Format(baseAddress + "?PageSize=" + pageSize + "&PageIndex=" + pageIndex);
        //        IntegrationWebClient.Get(new Uri(url, UriKind.Absolute),
        //            action, IntegrationWebClient.MessageFormat.Json, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //    public void DeleteUnit(Action<string, Exception> action, long id)
        //    {
        //        var url = string.Format(baseAddress + "?Id=" + id);
        //        IntegrationWebClient.Delete(new Uri(url, UriKind.Absolute), action, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //    public void GetAllUnits(Action<List<UnitDTO>, Exception> action)
        //    {
        //        var url = string.Format(baseAddress);
        //        IntegrationWebClient.Get(new Uri(url, UriKind.Absolute),
        //            action, IntegrationWebClient.MessageFormat.Json, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //    public void GetUnit(Action<UnitDTO, Exception> action, long id)
        //    {
        //        var url = string.Format(baseAddress + "?Id=" + id);
        //        IntegrationWebClient.Get(new Uri(url, UriKind.Absolute),
        //            action, IntegrationWebClient.MessageFormat.Json, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //    public void AddUnit(Action<UnitDTO, Exception> action, UnitDTO unit)
        //    {

        //        var url = string.Format(baseAddress);
        //        IntegrationWebClient.Post(new Uri(url, UriKind.Absolute),
        //            action, unit, IntegrationWebClient.MessageFormat.Json, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //    public void UpdateUnit(Action<UnitDTO, Exception> action, UnitDTO unit)
        //    {
        //        var url = string.Format(baseAddress);
        //        IntegrationWebClient.Put(new Uri(url, UriKind.Absolute),
        //            action, unit,
        //            IntegrationWebClient.MessageFormat.Json, PMSClientConfig.CreateHeaderDic(userProvider.Token));
        //    }

        //}
        #endregion
    }
}

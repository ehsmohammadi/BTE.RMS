using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeOveralObjectiveServiceWrapper:IOveralObjectiveServiceWrapper
    {
        #region Private fields
        private List<CrudOveralObjective> overalObjectives=new List<CrudOveralObjective>();
        #endregion

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
        private  List<SummeryOveralObjective> overalObjectiveList=new List<SummeryOveralObjective>
        {
            new CrudOveralObjective
            {
                ExplainGoal = "پیروزی",
                Title = "موفقیت در امتحانات",
                Overview = "کارنامه 20",
                Periority = "B"
            }
        }; 
        public void CreateOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective)
        {
            overalObjectives.Add(overalObjective);
            action(overalObjective, null);
        }

        public void ModifyOveralObjective(Action<CrudOveralObjective, Exception> action, CrudOveralObjective overalObjective)
        {
            throw new NotImplementedException();
        }

        public void DeleteOveralObjective(Action<string, Exception> action, long id)
        {
            throw new NotImplementedException();
        }

        public void GetOveralObjective(Action<CrudOveralObjective, Exception> action, long id)
        {
            throw new NotImplementedException();
        }

        public void GetAllOveralObjectives(Action<List<SummeryOveralObjective>, Exception> action)
        {
            action(overalObjectiveList, null);
        }
    }
}

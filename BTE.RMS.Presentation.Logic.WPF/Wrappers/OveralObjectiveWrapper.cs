using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MITD.PMS.Integration.Core;
//using MITD.PMS.Presentation.Contracts;

namespace MITD.PMS.Integration.PMS.API
{
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
}

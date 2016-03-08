using System;
using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract
{
    public class DeleteTaskCommand
    {
        public Guid SyncId { get; set; }
        public AppType AppType { get; set; }


        #region Main Properties

        public long Id { get; set; }

        #endregion

    }
}

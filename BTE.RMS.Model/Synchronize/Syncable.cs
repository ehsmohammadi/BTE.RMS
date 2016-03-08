using System;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Synchronize
{
    public abstract class Syncable<T>
    {
        #region Properties


        public Guid SyncId { get; set; }

        public EntityActionType ActionType { get; set; }

        public bool IsSyncedWithAndriodApp { get; set; }

        public bool IsSyncedWithDesktopApp { get; set; }

        public AppType ActionTypeOwner { get; set; }

        #endregion

        #region Constructors
        public Syncable(Guid syncId, bool isSyncedWithAndriodApp, bool isSyncedWithDesktopApp, AppType actionTypeOwner)
        {
            SyncId = syncId;
            IsSyncedWithAndriodApp = isSyncedWithAndriodApp;
            IsSyncedWithDesktopApp = isSyncedWithDesktopApp;
            ActionTypeOwner = actionTypeOwner;
        }

        #endregion

        #region Methods
        


        #endregion
    }

    public enum SyncState
    {
        UnSync=1,
        SyncedWithAndriodApp=2,
        SyncedWithDesktopApp=3,
        SyncedWithAll
    }


}

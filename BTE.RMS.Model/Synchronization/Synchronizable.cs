using System;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Synchronization
{
    public abstract class Synchronizable
    {
        #region Properties

        public Guid SyncId { get; set; }

        public EntityActionType ActionType { get; set; }

        public bool SyncedWithAndriodApp { get; set; }

        public bool SyncedWithDesktopApp { get; set; }

        #endregion

        #region Constructors

        protected Synchronizable()
        {
            
        }

        protected Synchronizable(Guid syncId, AppType appType)
        {
            setSyncId(syncId);
            SyncByCreate(appType);
        }


        #endregion

        #region Methods

        public virtual void Delete(AppType appType)
        {
            SyncByDelete(appType);
        }

        public void SyncWithAndriodApp()
        {
            SyncedWithAndriodApp = true;
        }

        public void SyncWithDesktopApp()
        {
            SyncedWithDesktopApp = true;
        }

        protected void SyncByCreate(AppType appType)
        {
            ActionType=EntityActionType.Create;
            setSyncStatus(appType);

        }

        protected void SyncByUpdate(AppType appType)
        {
            ActionType=EntityActionType.Modify;
            setSyncStatus(appType);
        }

        protected void SyncByDelete(AppType appType)
        {
            ActionType=EntityActionType.Delete;
            setSyncStatus(appType);
        }

        private void setSyncId(Guid syncId)
        {
            if (syncId == null || syncId == default(Guid)||syncId==Guid.Empty)
                syncId = Guid.NewGuid();
            SyncId = syncId;
        }

        private void setSyncStatus(AppType appType)
        {
            SyncedWithAndriodApp = appType == AppType.AndriodApp;
            SyncedWithDesktopApp = appType == AppType.DesktopApp;
        }

        #endregion
    }


}

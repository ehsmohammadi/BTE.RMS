namespace BTE.RMS.Model
{
    public class  Synceable
    {
        bool SyncedWithIphone { get; set; }
        bool SyncedWithWeb { get; set; }
        bool SyncedWithDesktop { get; set; }
        bool SyncedWithAndriod { get; set; }

        public Synceable()
        {
  
        }

        public void SyncWithIphone()
        {
            SyncedWithIphone = true;
        }

    }


}

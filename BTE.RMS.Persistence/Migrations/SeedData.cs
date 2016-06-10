using System.Data.Entity;

namespace BTE.RMS.Persistence
{
    public class RMSDBInitializer : DropCreateDatabaseIfModelChanges<RMSContext>
    {
        protected override void Seed(RMSContext context)
        {
           


            base.Seed(context);
        }
    }
}

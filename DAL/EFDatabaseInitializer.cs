using System.Data.Entity;
namespace ilac_etkilesimleri.DAL
{
    public class EFDatabaseInitializer : DropCreateDatabaseIfModelChanges<TingoonDbContext>
    {
        public override void InitializeDatabase(TingoonDbContext db)
        {

            base.InitializeDatabase(db);
        }
        protected override void Seed(TingoonDbContext db)
        {
            var appSeed = new AppSeed(db);
            base.Seed(db);
        }
    }
}
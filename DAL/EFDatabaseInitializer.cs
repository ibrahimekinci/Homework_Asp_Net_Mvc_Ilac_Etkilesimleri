using System.Data.Entity;
namespace ilac_etkilesimleri.DAL
{
    public class EFDatabaseInitializer : DropCreateDatabaseIfModelChanges<TingoonDbContext>
    {
        public override void InitializeDatabase(TingoonDbContext db)
        {
        }
        protected override void Seed(TingoonDbContext db)
        {
            base.Seed(db);
        }
    }
}
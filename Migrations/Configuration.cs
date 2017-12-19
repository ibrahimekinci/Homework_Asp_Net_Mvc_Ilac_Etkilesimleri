namespace ilac_etkilesimleri.Migrations
{
    using ilac_etkilesimleri.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ilac_etkilesimleri.TingoonDbContext>
    {
        public Configuration()
        {
            //Enable - Migrations –EnableAutomaticMigrations
            //Update-Database -force
            AutomaticMigrationsEnabled = true;//Fasle iken true yapýldý.Sürekli migration ekleme iþini otomatik yapmak için 
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ilac_etkilesimleri.TingoonDbContext db)
        {
            var appSeed = new AppSeed(db);
            //db.Database.Delete();
            //db.Database.Create();
        }
    }
}

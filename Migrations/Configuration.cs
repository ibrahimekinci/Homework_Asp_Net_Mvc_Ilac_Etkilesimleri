namespace ilac_etkilesimleri.Migrations
{
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
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ilac_etkilesimleri.TingoonDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

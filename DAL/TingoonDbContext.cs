using System.Data.Entity;
using ilac_etkilesimleri.DAL;
using ilac_etkilesimleri.Data;

namespace ilac_etkilesimleri
{
    public class TingoonDbContext : EFContextSettings, ITingoonDbContext
    {
        public TingoonDbContext()
        {
            //using (var context = new TingoonDbContext())
            //{
            //   // context.Database.Delete();
            //    //   context.Database.Create();
            //}
        }
        public DbSet<Ilac> Ilac { get; set; }
        public DbSet<EtkenMadde> EtkenMadde { get; set; }
        public DbSet<EtkenMaddeEtkilesim> EtkenMaddeEtkilesim { get; set; }
        public DbSet<IlacEtkilesim> IlacEtkilesim { get; set; }
        public DbSet<IlacEtkenMadde> IlacEtkenMadde { get; set; }


    }
}

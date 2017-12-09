using System.Data.Entity;
using ilac_etkilesimleri.DAL;
using ilac_etkilesimleri.Data;

namespace ilac_etkilesimleri
{
    public class TingoonDbContext : EFContextSettings ,ITingoonDbContext
    {
        public DbSet<Ilac> Ilac { get; set; }
        public DbSet<EtkenMadde> EtkenMadde { get; set; }

    }
}

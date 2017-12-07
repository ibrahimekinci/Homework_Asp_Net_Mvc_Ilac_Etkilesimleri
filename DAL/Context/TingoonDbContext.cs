using System.Data.Entity;
using ilac_etkilesimleri.DAL;
using ilac_etkilesimleri.Data;

namespace ilac_etkilesimleri
{
    public class TingoonDbContext : EFContextSettings ,ITingoonDbContext
    {
        public DbSet<Ilac> IlacModels { get; set; }
        public DbSet<EtkenMadde> EtkenMaddeModels { get; set; }

    }
}

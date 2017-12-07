using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ilac_etkilesimleri.DAL;
namespace ilac_etkilesimleri
{
    public interface ITingoonDbContext
    {
        Database Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void Dispose();
    }
}

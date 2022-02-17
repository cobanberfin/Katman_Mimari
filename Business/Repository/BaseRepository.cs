using Katmanli_Rep.Repository;
using Katmanlı_DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli_Rep.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        DataContext db = new DataContext();
        public T Bul(int id)
        {
            return Set().Find(id);
        }

        public T Bul(string id)
        {
            return Set().Find(id);
        }

        public void Ekle(T entity)
        {
            Set().Add(entity);
            //db.Entry(entity).State = EntityState.Added;
        }

        public int Etkilenenkayit()
        {
            return db.SaveChanges();
            
        }

        public IQueryable<T> GenelListe()
        {
            return Set().AsQueryable();
        }

        public void Guncel()
        {
            db.SaveChanges();
        }

        public List<T> Listele()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return db.Set<T>();
        }

        public void Sil(T entity)
        {
            Set().Remove(entity);
        }
    }
}

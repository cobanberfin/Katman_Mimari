using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanlı_DAL
{ //veri erisim katmanıdır.veri tabanıyla doğrudan etkileşimde bulunan katmandır.
    public class DataContext:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler{ get; set; }
        public DbSet<Sinif> Siniflar { get; set; }




    }
}

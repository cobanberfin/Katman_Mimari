using Entities;
using Katmanli_Rep.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{//Business LAyer :iş kuralları yazılır karar mekanızmasıdır
   public class Repository
    {
        public class OgrenciRepository : BaseRepository<Ogrenci>
        {

        }
        public class SinifRepository : BaseRepository<Sinif>
        {

        }



    }
}

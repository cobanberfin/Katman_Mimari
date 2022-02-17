using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Sinif
    {
        public int SinifID { get; set; }
        [Required]
        public string Kademe { get; set; }
       [Required]
        public string Sube { get; set; }
        public int sinifMevcut { get; set; }
        public ICollection<Ogrenci>Ogrenciler { get; set; }
    }
}

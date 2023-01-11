using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Veresiyeler
    {
        [Key]
        public int Veresiye_Id { get; set; }
        public int Musteri_Id { get; set; }
        public int ToplamTutar { get; set; }
    }
}

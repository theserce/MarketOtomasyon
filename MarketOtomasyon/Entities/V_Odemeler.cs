using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class V_Odemeler
    {
        [Key]
        public int V_Odemeler_Id { get; set; }
        public int Musteri_Id { get; set; }
        public int Veresiye_Id { get; set; }
        public decimal Odeme_Miktari { get; set; }
        public DateTime Odeme_Tarihi { get; set; }
    }
}

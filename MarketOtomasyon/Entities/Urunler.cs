using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Urunler
    {
        [Key]
        public int Urun_Id { get; set; }
        public string Urun_Kodu { get; set; }
        public string Urun_Adi { get; set; }
        public string Irsaliye_No { get; set; }
        public int Barkod_Numarasi { get; set; }
        public decimal Birim_Girdi_Fiyati { get; set; }
        public decimal Satis_Fiyati { get; set; }
        public int Stok { get; set; }
        public int Stok_Esik { get; set; }
    }
}

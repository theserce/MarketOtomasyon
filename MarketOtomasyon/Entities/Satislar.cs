using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Satislar
    {
        [Key]
        public int Satis_Id { get; set; }
        public int Musteri_Id { get; set; }
        public int Urun_Id { get; set; }
        public string Urun_Adi { get; set; }
        public decimal Satis_Fiyati { get; set; }
        public int Adet { get; set; }
        public DateTime Satis_Tarih { get; set; }
        public decimal Tutar { get; set; }
        public string Satis_Turu { get; set; }
    }
}

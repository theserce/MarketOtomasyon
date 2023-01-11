using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Satis_Detay
    {
        [Key]
        public int Satis_Detay_Id { get; set; }
        public int Urun_Id { get; set; }
        public string Urun_Adi { get; set; }
        public decimal Satis_Fiyati { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }
        public int Satis_Id { get; set; }

    }
}

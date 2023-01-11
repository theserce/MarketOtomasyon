using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Stoklar
    {
        [Key]
        public int Stok_Id { get; set; }
        public int Urun_Id { get; set; }
        public int Stok_Adedi { get; set; }
        public int Tedarikci_Id { get; set; }
        public DateTime Giris_Tarihi { get; set; }
    }
}

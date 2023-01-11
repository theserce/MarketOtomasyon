using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class B_Odemeler
    {
        [Key]
        public int B_Odemeler_Id { get; set; }
        public decimal Odeme_Miktari { get; set; }
        public DateTime Odeme_Tarihi { get; set; }
        public int Tedarikci_Id { get; set; }
    }
}

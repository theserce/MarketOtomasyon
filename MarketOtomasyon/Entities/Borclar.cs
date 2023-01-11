using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Borclar
    {
        [Key]
        public int Borc_Id { get; set; }
        public decimal Toplam_Tutar { get; set; }
        public int Tedarikci_Id { get; set; }
    }
}

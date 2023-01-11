using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Entities
{
    public class Tedarikci
    {
        [Key]
        public int Tedarikci_Id { get; set; }
        public string Isım { get; set; }
        public string Telefon { get; set; }
    }
}

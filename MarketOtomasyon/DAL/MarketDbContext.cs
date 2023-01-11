using MarketOtomasyon.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.DAL
{
    public class MarketDbContext :DbContext
    {
        public DbSet<B_Odemeler> B_Odemelers { get; set; }
        public DbSet<Borclar> Borclars { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<Satici> Saticis { get; set; }
        public DbSet<Satis_Detay> Satis_Detays { get; set; }
        public DbSet<Satislar> Satislars { get; set; }
        public DbSet<Stoklar> Stoklars { get; set; }
        public DbSet<Tedarikci> Tedarikcis { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<V_Odemeler> V_Odemelers { get; set; }
        public DbSet<Veresiyeler> Veresiyelers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MarketOtomasyonDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");           
        }
    }
}

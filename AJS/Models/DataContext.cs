using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace AJS.Models
{
    public partial class DataContext : DbContext
    {
        
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString)
        {        
        }
        public virtual DbSet<LoaiSP> LoaiSP { get; set; }
        public virtual DbSet<Product> SanPham { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

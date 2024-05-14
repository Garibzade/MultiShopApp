using Microsoft.EntityFrameworkCore;
using MultiShop.Models;

namespace MultiShop.DataAccesLayer
{
    public class MultiContext : DbContext
    {
        public MultiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-8QLA9CR\SQLEXPRESS;Database=MultiShop;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}

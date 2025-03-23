using Microsoft.EntityFrameworkCore;
using doanchuyennganh.Models;

namespace doanchuyennganh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Sach> Saches { get; set; }
        public DbSet<Theloai> Theloais { get; set; }
        public DbSet<Nhac> Nhacs { get; set; }
        public DbSet<TheLoaiNhac> TheloaiNhacs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ và ràng buộc (nếu cần)
            modelBuilder.Entity<Nhac>()
                .HasOne(n => n.TheloaiNhacs)
                .WithMany(t => t.Nhacs)
                .HasForeignKey(n => n.TheloaiId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}

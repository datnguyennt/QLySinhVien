using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLySinhVien.Models
{
    public partial class DBSinhVienContext : DbContext
    {
        public DBSinhVienContext()
            : base("name=DBSinhVienContext")
        {
        }

        public virtual DbSet<ChiTietSinhVien> ChiTietSinhVien { get; set; }
        public virtual DbSet<LopSinhHoat> LopSinhHoat { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietSinhVien>()
                .Property(e => e.MaSinhVien)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSinhVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSinhVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LopSinhHoat>()
                .HasMany(e => e.ChiTietSinhVien)
                .WithRequired(e => e.LopSinhHoat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSinhVien)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .HasOptional(e => e.ChiTietSinhVien)
                .WithRequired(e => e.SinhVien);
        }
    }
}

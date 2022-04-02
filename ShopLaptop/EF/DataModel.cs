using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopLaptop.EF
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<MetaLaptop> MetaLaptops { get; set; }
        public virtual DbSet<NhuCau> NhuCaus { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hang>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Laptop>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Laptop>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.Laptop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.hinhnen)
                .IsUnicode(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.hinhnen)
                .IsUnicode(false);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataLayer.DAL
{
    public partial class ChamThiDbContext : DbContext
    {
        public ChamThiDbContext()
            : base("name=ChamThiDbContext")
        {
        }

        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<GiamThi> GiamThis { get; set; }
        public virtual DbSet<KetQua> KetQuas { get; set; }
        public virtual DbSet<PhongThi> PhongThis { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TestCase> TestCases { get; set; }
        public virtual DbSet<ThiSinh> ThiSinhs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHoi>()
                .HasOptional(e => e.PhongThi)
                .WithRequired(e => e.CauHoi);

            modelBuilder.Entity<GiamThi>()
                .HasOptional(e => e.TaiKhoan)
                .WithRequired(e => e.GiamThi);

            modelBuilder.Entity<KetQua>()
                .HasOptional(e => e.CauHoi)
                .WithRequired(e => e.KetQua);

            modelBuilder.Entity<KetQua>()
                .HasOptional(e => e.TaiKhoan)
                .WithRequired(e => e.KetQua);

            modelBuilder.Entity<PhongThi>()
                .HasOptional(e => e.TaiKhoan)
                .WithRequired(e => e.PhongThi);

            modelBuilder.Entity<PhongThi>()
                .HasOptional(e => e.ThiSinh)
                .WithRequired(e => e.PhongThi);

            modelBuilder.Entity<TaiKhoan>()
                .HasOptional(e => e.ThiSinh)
                .WithRequired(e => e.TaiKhoan);

            modelBuilder.Entity<TestCase>()
                .HasOptional(e => e.CauHoi)
                .WithRequired(e => e.TestCase);
        }
    }
}

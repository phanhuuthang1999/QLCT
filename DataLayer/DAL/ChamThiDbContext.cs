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

        public virtual DbSet<DM_CauHoi> DM_CauHoi { get; set; }
        public virtual DbSet<DM_DapAn> DM_DapAn { get; set; }
        public virtual DbSet<DM_GiamThi> DM_GiamThi { get; set; }
        public virtual DbSet<DM_KetQua> DM_KetQua { get; set; }
        public virtual DbSet<DM_Khoa> DM_Khoa { get; set; }
        public virtual DbSet<DM_LopHoc> DM_LopHoc { get; set; }
        public virtual DbSet<DM_MonHoc> DM_MonHoc { get; set; }
        public virtual DbSet<DM_NgonNgu> DM_NgonNgu { get; set; }
        public virtual DbSet<DT_ThiSinh> DT_ThiSinh { get; set; }
        public virtual DbSet<KT_KyThi> KT_KyThi { get; set; }
        public virtual DbSet<DangNhap> DangNhap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DM_CauHoi>()
                .Property(e => e.MaCH)
                .IsUnicode(false);

            modelBuilder.Entity<DM_DapAn>()
                .Property(e => e.MaDA)
                .IsUnicode(false);

            modelBuilder.Entity<DM_GiamThi>()
                .Property(e => e.MaGT)
                .IsUnicode(false);

            modelBuilder.Entity<DM_KetQua>()
                .Property(e => e.MaKQ)
                .IsUnicode(false);

            modelBuilder.Entity<DM_Khoa>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<DM_LopHoc>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<DM_MonHoc>()
                .Property(e => e.MaMon)
                .IsUnicode(false);

            modelBuilder.Entity<DM_NgonNgu>()
                .Property(e => e.MaNN)
                .IsUnicode(false);

            modelBuilder.Entity<DT_ThiSinh>()
                .Property(e => e.MaTS)
                .IsUnicode(false);

            modelBuilder.Entity<KT_KyThi>()
                .Property(e => e.MaKyThi)
                .IsUnicode(false);
            modelBuilder.Entity<DangNhap>()
                .Property(e => e.TenDN)
                .IsUnicode(false);
        }
    }
}

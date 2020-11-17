using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    public class DangNhapBll :BaseBll
    {
        public bool GetLogin(string taikhoan,string matkhau)
        {
            return Context.DangNhap.Any(h => h.TenDN.Equals(taikhoan) && h.MatKhau.Equals(matkhau));
        }

        public bool SetTrangThai(bool l)
        {
            return Context.DangNhap.Any(t => t.TrangThai.Equals(l));
        }

        public bool GetTrangThai(string tk)
        {
            return Context.DangNhap.Any(t => t.TenDN.Equals(tk) && t.TrangThai.Equals(false));
        }

        public bool GetTaiKhoan(string tk, string mk)
        {
            return Context.DangNhap.Any(t => t.TenDN == tk && t.MatKhau == mk);
        }

        public List<DangNhap> GetDanhSach(string s)
        {
            var data = Context.DangNhap.AsQueryable();

            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(p => p.TenHienThi.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExist(DangNhap pDangNhap)
        {
            return Context.DangNhap.Any(n => n.TenDN.Equals(pDangNhap.TenDN) && n.Id != pDangNhap.Id);
        }

        public int AddTaiKhoan(DangNhap pDangNhap)
        {
            var taikhoan = Context.DangNhap.FirstOrDefault(p => p.Id.Equals(pDangNhap.Id));
            if (taikhoan == null)
            {
                taikhoan = new DangNhap();
            }
            taikhoan.TenHienThi = pDangNhap.TenHienThi;
            taikhoan.TenDN = pDangNhap.TenDN;
            taikhoan.MatKhau = pDangNhap.MatKhau;
            taikhoan.TrangThai = pDangNhap.TrangThai;
            taikhoan.Quyen = pDangNhap.Quyen;

            Context.DangNhap.Add(taikhoan);

            return Context.SaveChanges();
        }

        public int DeleteTaiKhoan(DangNhap pDangNhap)
        {
            var taikhoan = Context.DangNhap.FirstOrDefault(p => p.TenDN.Equals(pDangNhap.TenDN));

            Context.DangNhap.Remove(taikhoan);

            return Context.SaveChanges();
        }

        public int DeleteMulti(DangNhap pDangNhap)
        {
            var taikhoan = Context.DangNhap.FirstOrDefault(p => p.TenDN.Equals(pDangNhap.TenDN));

            Context.DangNhap.RemoveRange(Context.DangNhap.Where(t => t.Id.Equals(pDangNhap.Id)));
            return Context.SaveChanges();
        }

    }
}

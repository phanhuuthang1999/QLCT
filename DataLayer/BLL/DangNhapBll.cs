using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    public class TaiKhoansBll :BaseBll
    {
        public bool GetLogin(string TaiKhoans,string matkhau)
        {
            return Context.TaiKhoans.Any(h => h.Tk.Equals(TaiKhoans) && h.MatKhau.Equals(matkhau));
        }

        public bool SetisActive(bool l)
        {
            return Context.TaiKhoans.Any(t => t.isActive.Equals(l));
        }

        public bool GetisActive(string tk)
        {
            return Context.TaiKhoans.Any(t => t.Tk.Equals(tk) && t.isActive.Equals(false));
        }

        public bool GetTaiKhoans(string tk, string mk)
        {
            return Context.TaiKhoans.Any(t => t.Tk == tk && t.MatKhau == mk);
        }

        public List<TaiKhoan> GetDanhSach(string s)
        {
            var data = Context.TaiKhoans.AsQueryable();

            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(p => p.TenHienThi.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExist(TaiKhoan pTaiKhoans)
        {
            return Context.TaiKhoans.Any(n => n.Tk.Equals(pTaiKhoans.Tk) && n.Id != pTaiKhoans.Id);
        }

        public int AddTaiKhoans(TaiKhoan pTaiKhoans)
        {
            var TaiKhoans = Context.TaiKhoans.FirstOrDefault(p => p.Id.Equals(pTaiKhoans.Id));
            if (TaiKhoans == null)
            {
                TaiKhoans = new TaiKhoan();
            }
            TaiKhoans.TenHienThi = pTaiKhoans.TenHienThi;
            TaiKhoans.Tk = pTaiKhoans.Tk;
            TaiKhoans.MatKhau = pTaiKhoans.MatKhau;
            TaiKhoans.isActive = pTaiKhoans.isActive;
            TaiKhoans.isQuyen = pTaiKhoans.isQuyen;

            Context.TaiKhoans.Add(TaiKhoans);

            return Context.SaveChanges();
        }

        public int DeleteTaiKhoans(TaiKhoan pTaiKhoans)
        {
            var TaiKhoans = Context.TaiKhoans.FirstOrDefault(p => p.Tk.Equals(pTaiKhoans.Tk));

            Context.TaiKhoans.Remove(TaiKhoans);

            return Context.SaveChanges();
        }

        public int DeleteMulti(TaiKhoan pTaiKhoans)
        {
            var TaiKhoans = Context.TaiKhoans.FirstOrDefault(p => p.Tk.Equals(pTaiKhoans.Tk));

            Context.TaiKhoans.RemoveRange(Context.TaiKhoans.Where(t => t.Id.Equals(pTaiKhoans.Id)));
            return Context.SaveChanges();
        }

    }
}

using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    /// <summary>
    /// Phòng Thi
    /// </summary>
    public class SitesBll : BaseBll
    {
        public List<PhongThi> GetAllSites(string s)
        {
            var data = Context.PhongThis.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(h => h.TenPhong.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExistPhong(PhongThi pPhongThi)
        {
            return Context.PhongThis.Any(p => p.MaPhong == pPhongThi.MaPhong);
        }

        public int SavePhongThi(PhongThi pPhongThi)
        {
            var PhongThi = Context.PhongThis.FirstOrDefault(p => p.Id == pPhongThi.Id);

            if (PhongThi == null)
            {
                PhongThi = new PhongThi();
                Context.PhongThis.Add(PhongThi);
            }

            PhongThi.MaPhong = pPhongThi.MaPhong;
            PhongThi.TenPhong = pPhongThi.TenPhong;
            PhongThi.Port = pPhongThi.Port;
            PhongThi.Status = pPhongThi.Status;
         
            return Context.SaveChanges();
        }

        public int DeletePhongThi(PhongThi pPhongThi)
        {
            var PhongThi = Context.PhongThis.FirstOrDefault(p => p.MaPhong == pPhongThi.MaPhong);
            Context.PhongThis.Remove(PhongThi);


            return Context.SaveChanges();
        }

        /// <summary>
        /// Trạng Thái 1 : Đang có sinh viên thi : 0
        /// </summary>
        /// <param name="pPhongThi"></param>
        /// <returns></returns>
        public bool CheckExistInPhongThi(PhongThi pPhongThi)
        {
            return Context.PhongThis.Any(h => h.Status.Equals(pPhongThi.Status == 1));
        }

    }
}

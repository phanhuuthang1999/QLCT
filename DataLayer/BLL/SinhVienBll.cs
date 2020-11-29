using DataLayer.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.BLL
{
    public class SinhVienBll : BaseBll
    {

        public List<ThiSinh> GetAllThiSinh(string s)
        {
            var data = Context.ThiSinhs.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(h => h.Ten.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExistThiSinh(ThiSinh pThiSinh)
        {
            return Context.ThiSinhs.Any(p => p.MSSV == pThiSinh.MSSV);
        }

        public int SaveThiSinh(ThiSinh pThiSinh)
        {
            var ThiSinh = Context.ThiSinhs.FirstOrDefault(p => p.MSSV == pThiSinh.MSSV);

            if (ThiSinh == null)
            {
                ThiSinh = new ThiSinh();
                Context.ThiSinhs.Add(ThiSinh);
            }

            ThiSinh.MSSV = pThiSinh.MSSV;
            ThiSinh.HoDem = pThiSinh.HoDem;
            ThiSinh.Ten = pThiSinh.Ten;
            ThiSinh.GIoiTinh = pThiSinh.GIoiTinh;
            ThiSinh.NgaySinh = pThiSinh.NgaySinh;

            return Context.SaveChanges();
        }

        public int DeleteThiSinh(ThiSinh pThiSinh)
        {
            var ThiSinh = Context.ThiSinhs.FirstOrDefault(p => p.MSSV == pThiSinh.MSSV);
            Context.ThiSinhs.Remove(ThiSinh);

            return Context.SaveChanges();
        }

    }
}

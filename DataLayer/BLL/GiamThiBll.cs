using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
namespace DataLayer.BLL
{
    public class GiamThiBll : BaseBll
    {

        public List<GiamThi> GetAllGiamThi(string s)
        {
            var data = Context.GiamThis.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(h => h.Ten.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExistGiamThi(GiamThi pGiamThi)
        {
            return Context.GiamThis.Any(p => p.MaGiamThi == pGiamThi.MaGiamThi);
        }

        public int SaveGiamThi(GiamThi pGiamThi)
        {
            var GiamThi = Context.GiamThis.FirstOrDefault(p => p.MaGiamThi == pGiamThi.MaGiamThi);

            if (GiamThi == null)
            {
                GiamThi = new GiamThi();
                Context.GiamThis.Add(GiamThi);
            }

            GiamThi.MaGiamThi = pGiamThi.MaGiamThi;
            GiamThi.HoDem = pGiamThi.HoDem;
            GiamThi.Ten = pGiamThi.Ten;
            GiamThi.GIoiTinh = pGiamThi.GIoiTinh;
            GiamThi.DonViCongTac = pGiamThi.DonViCongTac;

            return Context.SaveChanges();
        }

        public int DeleteGiamThi(GiamThi pGiamThi)
        {
            var GiamThi = Context.GiamThis.FirstOrDefault(p => p.MaGiamThi == pGiamThi.MaGiamThi);
            Context.GiamThis.Remove(GiamThi);

            return Context.SaveChanges();
        }

    }
}

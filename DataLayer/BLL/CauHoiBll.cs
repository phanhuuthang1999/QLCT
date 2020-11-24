using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    public class CauHoiBll : BaseBll
    {

        public List<CauHoi> GetAllQuestion(string s)
        {
            var data = Context.CauHois.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(h => h.TenCauHoi.Contains(s));
            }
            return data.ToList();
        }

        public bool CheckExistQuestion(CauHoi pCauHoi)
        {
            return Context.CauHois.Any(p => p.MaCauHoi == pCauHoi.MaCauHoi);
        }

        public int SaveQuestion(CauHoi pCauHoi)
        {
            var CauHoi = Context.CauHois.FirstOrDefault(p => p.MaCauHoi == pCauHoi.MaCauHoi);

            if (CauHoi == null)
            {
                CauHoi = new CauHoi();
                Context.CauHois.Add(CauHoi);
            }

            CauHoi.MaCauHoi = pCauHoi.MaCauHoi;
            CauHoi.TenCauHoi = pCauHoi.TenCauHoi;
            CauHoi.NoiDung = pCauHoi.NoiDung;
            CauHoi.HinhAnh = pCauHoi.HinhAnh;
            CauHoi.isSuDung = pCauHoi.isSuDung;

            return Context.SaveChanges();
        }

        public int DeleteCauHoi(CauHoi pCauHoi)
        {
            var CauHoi = Context.CauHois.FirstOrDefault(p => p.MaCauHoi == pCauHoi.MaCauHoi);
            Context.CauHois.Remove(CauHoi);

            return Context.SaveChanges();
        }

        public bool CheckExistInCauHoi(CauHoi pCauHoi)
        {
            return Context.CauHois.Any(h => h.isSuDung.Equals(pCauHoi.isSuDung == true));
        }

    }
}

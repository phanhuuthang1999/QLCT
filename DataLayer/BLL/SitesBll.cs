using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
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

    }
}

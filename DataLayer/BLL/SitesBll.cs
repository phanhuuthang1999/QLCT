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
        public List<KT_KyThi> GetAllSites(string s)
        {
            var data = Context.KT_KyThi.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                data = data.Where(h => h.TenKyThi.Contains(s));
            }
            return data.ToList();
        }
    }
}

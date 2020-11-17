using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.BLL
{
    public class BaseBll
    {
        private ChamThiDbContext _context;

        public BaseBll()
        {
            _context = new ChamThiDbContext();
        }

        public void NewContext()
        {
            _context = new ChamThiDbContext();
        }

        public ChamThiDbContext Context { get => _context; set => _context = value; }
    }
}

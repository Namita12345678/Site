using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Model;

namespace DataAccess.Logic
{
    public class CityLogic : CityRepository
    {
        private AppDbContext _context;
        public CityLogic(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public List<CitySubModel> getCityActiveSubModel()
        {
            List<CitySubModel> CSM = (from p in _context.Tbl_Country.Where(q => q.Isactive == true)
                                      join r in _context.Tbl_State.Where(t => t.Isactive == true) on p.CountryId equals
                                          r.CountryId
                                      join s in _context.Tbl_City.Where(u => u.Isactive == true) on r.StateId equals
                                           s.StateId
                                      select new CitySubModel { Cot = p, St = r, Ct = s }).ToList();
            return CSM;
        }
    }
}
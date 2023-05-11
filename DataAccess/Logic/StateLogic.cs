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
    public class StateLogic : StateRepository
    {
        private AppDbContext _context;
        public StateLogic(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<StateSubModel> getStateActiveSubModel()
        {
            List<StateSubModel> CSM = (from p in _context.Tbl_Country.Where(q => q.Isactive == true)
                                       join r in _context.Tbl_State.Where(t => t.Isactive == true) on p.CountryId equals
                                          r.CountryId
                                       select new StateSubModel { Ct = p, St = r }).ToList();
            return CSM;
        }

    }
}
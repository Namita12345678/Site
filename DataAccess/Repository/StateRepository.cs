using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class StateRepository : Repository<Tbl_State>
    {
        private AppDbContext _context;
        public StateRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override Tbl_State Update(Tbl_State obj)
        {
            // obj.UpdatedOn = ServerDate.Now();
            return base.Update(obj);
        }
    }
}


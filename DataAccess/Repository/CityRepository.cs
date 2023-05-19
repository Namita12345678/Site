using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class CityRepository : Repository<Tbl_City>
    {
        private AppDbContext _context;
        public CityRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override Tbl_City Update(Tbl_City obj)
        {
            // obj.UpdatedOn = ServerDate.Now();
            return base.Update(obj);
        }
    }



}

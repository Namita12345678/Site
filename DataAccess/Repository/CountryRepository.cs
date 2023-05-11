using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class CountryRepository : Repository<Tbl_Country>
    {
        private AppDbContext _context;
        public CountryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override Tbl_Country Update(Tbl_Country obj)
        {
            // obj.UpdatedOn = ServerDate.Now();
            return base.Update(obj);
        }
    }
}

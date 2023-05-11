using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Logic
{
    public class CountryLogic : CountryRepository
    {
        private AppDbContext _context;
        public CountryLogic(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

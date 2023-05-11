using DataAccess.Logic;//logic
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface IService
    {
        // AdminLoginLogic AdminLogin { get; }
        CountryLogic Country { get; }
        CityLogic City { get; }
        StateLogic State { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Logic;
using DataAccess;
using DataAccess.Entities;

namespace DataAccess
{
    public class Service: IService
    {

    


    //Login;
    //public AdminLoginLogic AdminLogin
    //{
    //    get
    //    {
    //        if (_AdminLogin == null)
    //        {
    //            _AdminLogin = new AdminLoginLogic(new AppDbContext());
    //        }
    //        return _AdminLogin;
    //    }
    //}



    CountryLogic _Country;
        public CountryLogic Country
        {
            get
            {
                if (_Country == null)
                {
                    _Country = new CountryLogic(new AppDbContext());
                }
                return _Country;
            }
        }

        StateLogic _State;
        public StateLogic State
        {
            get
            {
                if (_State == null)
                {
                    _State = new StateLogic(new AppDbContext());
                }
                return _State;
            }
        }
        CityLogic _City;
        public CityLogic City
        {
            get
            {
                if (_City == null)
                {
                    _City = new CityLogic(new AppDbContext());
                }
                return _City;
            }
        }
    }
}

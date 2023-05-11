using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Model


{
    public class CitySubModel
    {

        public Tbl_Country Cot { get; set; }
        public Tbl_State St{ get; set; }
        public Tbl_City Ct { get; set; }
        public CitySubModel()
        {
            Cot = new Tbl_Country();
            St = new Tbl_State();
            Ct = new Tbl_City();
        }
    }
}
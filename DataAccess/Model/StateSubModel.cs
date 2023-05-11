using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Model
{
    public class StateSubModel
    {

        public Tbl_Country Ct { get; set; }
        public Tbl_State St { get; set; }
        public StateSubModel()
        {
            Ct = new Tbl_Country();
            St = new Tbl_State();
        }
    }
}
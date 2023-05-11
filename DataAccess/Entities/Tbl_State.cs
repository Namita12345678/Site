namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_State
    {
        [Key]
        public int StateId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public int CountryId { get; set; }

        public bool? Isactive { get; set; }

        public bool? Isdisplay { get; set; }
    }
}

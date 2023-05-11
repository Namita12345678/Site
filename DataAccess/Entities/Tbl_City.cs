namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_City
    {
        [Key]
        public int CityId { get; set; }

        [StringLength(100)]
        public string CityName { get; set; }

        public int? StateId { get; set; }

        public bool? Isactive { get; set; }

        public bool? Isdisplay { get; set; }
    }
}

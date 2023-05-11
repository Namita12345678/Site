namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Country
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }

        [StringLength(50)]
        public string CountryCode { get; set; }

        public bool? Isactive { get; set; }

        public bool? Isdisplay { get; set; }
    }
}

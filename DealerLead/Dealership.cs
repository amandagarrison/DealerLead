using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerLead
{
    public class Dealership
    {
        [Key]
        [Column("DealershipId)")]
        [Display(Name = "Dealership ID")]
        public int DealershipId { get; set; }

        [Column("DealershipName")]
        public string Name { get; set; }

        [Column("StreetAddress1")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Column("StreetAddress2")]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("ZipCode")]
        public string Zip { get; set; }

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifyDate { get; set; }

        [Column("CreatingUserId")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }



    }
}

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
        public int Id { get; set; }

        [Column("DealershipName")]
        public string Name { get; set; }

        [Column("StreetAddress1")]



    }
}

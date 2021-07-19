using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerLead
{
    public class SupportedMakes
    {
       
        [Column("MakeName")]
        public string Name { get; set; } 

        [Key]
        [Column("MakeId")]
        public int Id { get; set; }


    }


}

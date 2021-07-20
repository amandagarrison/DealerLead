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

        [Key]
        [Column("MakeId")]
        [Display(Name = "Make ID")]
        public int Id { get; set; }

        [Column("MakeName")]
        [Display(Name = "Name")]
        public string Name { get; set; } 

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifyDate { get; set; }

      
        public List<SupportedModels> Models { get; set; }

        

    }


}

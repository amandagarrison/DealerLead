using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerLead
{
    public class SupportedModels
    {
        [Key]
        [Column("ModelId")]
        public int Id { get; set; }

        [Column("ModelName")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifyDate { get; set; }

        public int MakeId { get; set; }

        public SupportedMakes Make { get; set; }
    }
}

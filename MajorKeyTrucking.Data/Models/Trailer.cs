using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Models
{
    public class Trailer:Equipment
    {
        [Key]
        public int TrailerId { get; set; }


        [Required]
        [DisplayName("Trailer #")]
        [StringLength(20), MaxLength(10)]
        public string TrailerNumber { get; set; }

        
        public IEnumerable<Load> Loads { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

    }

   
}

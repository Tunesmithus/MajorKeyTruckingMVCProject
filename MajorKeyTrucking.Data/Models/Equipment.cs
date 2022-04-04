using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Models
{
    public abstract class Equipment
    {
        [Required]
        [StringLength(17), DisplayName("Vin Number")]
        [MaxLength(50)]
        
        public string VinNumber { get; set; }

        [Required]
        [Range(1950, 2050)]
       
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        public string Model { get; set; }


    }
}

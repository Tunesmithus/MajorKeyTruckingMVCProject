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
    public class Truck:Equipment
    {
        [Key]
        public int TruckId { get; set; }

        [Required]
        [StringLength(100), DisplayName("Truck #")]
        [MaxLength(10)]
        public string EquipmentNumber { get; set; }

        public IEnumerable<Load> Loads { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

    }
}

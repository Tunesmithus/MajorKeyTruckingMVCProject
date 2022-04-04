using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [DisplayName("Category")]
        [MaxLength(50)]
        public string ExpenseName { get; set; }

        [Required]
        [DisplayName("Cost")]
        public decimal ExpenseCost { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(100)]
        public string ExpenseDescription { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int TrailerId { get; set; }
        public Trailer Trailer { get; set; }

        public int TruckId { get; set; }

        public Truck Truck { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MajorKeyTrucking.Data.Models
{
    public class Load
    {
        [Key]
        public int LoadId { get; set; }

        //[Required]
        //[DisplayName("Broker Name"), StringLength(50)]
        
        //public string BrokerName { get; set; }

        [Required]
        [DisplayName("Load #"), StringLength(50)]
        public string LoadNumber { get; set; }

        
        [DisplayName("Unloaded")]
        public decimal UnloadedMiles { get; set; }

        [Required]
        [DisplayName("Loaded")]
        public decimal LoadedMiles { get; set; }

        [Required]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PickUpDate { get; set; }

        [Required]
        [DisplayName("End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [DisplayName("Load Pay")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Range(1.00, 20000.00)]
        public decimal LoadPay { get; set; }

        [Required]
        [ReadOnly(true)]
        [DisplayName("RPM")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        //public decimal RatePerMile { get; set; }
        public decimal RatePerMile { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int TrailerId { get; set; }
        public Trailer Trailer { get; set; }

        public int TruckId { get; set; }

        public Truck Truck { get; set; }

        [DisplayName("Broker Name")]
        public int BrokerId { get; set; }

        public Broker Broker { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }


        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorKeyTrucking.Data.Models
{
    public class Broker
    {
        [Key]
        public int BrokerId { get; set; }

        [DisplayName("Company Name")]
        [MaxLength(50)]
        public string BrokerCompanyName { get; set; }

        [DisplayName("Contact Number")]
        [MaxLength(50)]
        [StringLength(10)]
        public string BrokerPhoneNumber { get; set; }

        [DisplayName("Email")]
        public string BrokerEmail { get; set; }

        public IEnumerable<Load> Loads { get; set; }
    }
}

using MajorKeyTrucking.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MajorKeyTrucking.Data
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        [DisplayName("First Name"), StringLength(50)]
        
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name"), StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [DisplayName("Email"), StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [StringLength(10)]
        [DisplayFormat(DataFormatString ="{0:###-###-####}")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Street Address"), StringLength(50)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
       
        public string State { get; set; }

        [Required]
        [DisplayName ("Zip Code")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("Pay Model"), StringLength(50)]
        public string PayModel { get; set; }

        [Required]
        [DisplayName ("Pay")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal DriverPay { get; set; }

        public IEnumerable<Load> Loads { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }





        //public IEnumerable<SelectListItem> pay { get; set; } = new List<SelectListItem>()
        //{
        //    new SelectListItem{Value = "1", Text = "Hourly"},
        //    new SelectListItem{Value = "2", Text = "Mileage"},
        //    new SelectListItem{Value = "3", Text = "Percentage"}
        //};

        //public PayModel PayType { get; set; }









    }
}

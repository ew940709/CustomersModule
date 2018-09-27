using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomersModule.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Display(Name="First name")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Display(Name="Last name")]
        [StringLength(100, ErrorMessage = "Maximum length is 100 characters")]
        [Required(ErrorMessage = "Field is required")]
        public string Surname { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Field is required")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Street")]
        [StringLength(250, ErrorMessage = "Maximum length is 250 characters")]
        [Required(ErrorMessage = "Field is required")]
        public string Street { get; set; }

        [Display(Name = "House No")]
        [Required(ErrorMessage = "Field is required")]
        public string HouseNumber { get; set; }

        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Field is required")]
        public string City { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"[0-9]{2}\-[0-9]{3}", ErrorMessage = "Wrong format of the zip code!")]
        public string ZipCode { get; set; }
    }
}
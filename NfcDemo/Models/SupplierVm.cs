using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NfcDemo.Models
{
    [NotMapped]
    public class SupplierVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ITIN:")]
        public string Itin { get; set; }

        [Required]
        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }
    }
}
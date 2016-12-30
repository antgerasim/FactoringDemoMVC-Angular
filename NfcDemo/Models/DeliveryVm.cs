using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NfcDemo.Models
{
    [NotMapped]
    public class DeliveryVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Номер :")]
        public string DelNo { get; set; }

        [Required]
        [Display(Name = "Валюта:")]
        public int Currency { get; set; } 
      
        [Required]
        [Display(Name = "Сумма:")]
        public int Total { get; set; }

        [Required]
        [Display(Name = "Поставщик:")]
        public string Supplier { get; set; }
  
        public long SupplierItin { get; set; }

        public long SupplierId { get; set; }
    }
}
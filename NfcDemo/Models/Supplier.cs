using System.ComponentModel.DataAnnotations;

namespace NfcDemo.Models
{
    public class Supplier
    {
        public int Id { get; set; }
 
        public long Itin { get; set; }

        public string CompanyName { get; set; }
    }
}
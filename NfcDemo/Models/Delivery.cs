namespace NfcDemo.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public string DelNo { get; set; }

        public int Currency { get; set; } //enum here?

        public int Sum { get; set; }

        //Foregn key
        public int SupplierId { get; set; }
        //Nav property
        public Supplier Supplier { get; set; }
    }
}
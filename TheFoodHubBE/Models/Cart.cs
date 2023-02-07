namespace TheFoodHubBE.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int StaffID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

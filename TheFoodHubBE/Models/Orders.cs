namespace TheFoodHubBE.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int StaffID { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    }
}

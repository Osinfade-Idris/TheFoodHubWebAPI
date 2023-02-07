namespace TheFoodHubBE.Models
{
    public class Response
    {
        internal List<Staffs> listStaffs;

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Staffs> ListStaff { get; set; }
        public Staffs staff { get; set; }
        public List<Products> ListProducts { get; set; }
        public Products product { get; set; }
        public List<Cart> ListCart { get; set; }
        public List<Orders> ListOrders { get; set; }
        public Orders order { get; set; }
        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems orderItem { get; set; }

    }
}

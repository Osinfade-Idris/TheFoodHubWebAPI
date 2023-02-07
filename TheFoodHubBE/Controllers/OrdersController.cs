using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TheFoodHubBE.Models;
namespace TheFoodHubBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("placeOrder")]
        public Response placeOrder(Staffs staffs)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.placeOrder(staffs, connection);
            return response;
        }


        [HttpPost]
        [Route("orderList")]
        public Response orderList(Staffs staffs)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.orderList(staffs, connection);
            return response;
        }

    }
}

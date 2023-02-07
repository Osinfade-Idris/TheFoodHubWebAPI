using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TheFoodHubBE.Models;
namespace TheFoodHubBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addCategory")]
        public Response addCategory(string categoryName)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.addCategory(categoryName, connection);
            return response;
        }

        [HttpPost]
        [Route("updateCategory")]
        public Response updateCategory(Category category)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.updateCategory(category, connection);
            return response;
        }

        [HttpPost]
        [Route("addProduct")]
        public Response addUpdateProduct(Products products)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.addProduct(products, connection);
            return response;
        }

        [HttpGet]
        [Route("staffList")]
        public Response userList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.userList(connection);
            return response;
        }
    }
}

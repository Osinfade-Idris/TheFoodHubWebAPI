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
        private DAL dal;
        private SqlConnection connection;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
             dal = new DAL();
             connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
        }

        [HttpPost]
        [Route("addCategory")]
        public Response addCategory(string categoryName)
        {
            try{
                Response response = dal.addCategory(categoryName, connection);
                return response;
            }catch (error){
                Console.WriteLine(error)
            }
        }

        [HttpPost]
        [Route("updateCategory")]
        public Response updateCategory(Category category)
        {
            try{
                Response response = dal.updateCategory(category, connection);
                return response;
                }catch (error){
                Console.WriteLine(error)
            }
        }

        [HttpPost]
        [Route("addProduct")]
        public Response addUpdateProduct(Products products)
        {
            try{
            Response response = dal.addProduct(products, connection);
            return response;
            }catch (error){
                Console.WriteLine(error)
            }
        }

        [HttpGet]
        [Route("staffList")]
        public Response userList()
        {
            try{
                  Response response = dal.userList(connection);
                   return response;
            } catch (error){
                Console.WriteLine(error)
            }
          
        }
    }
}

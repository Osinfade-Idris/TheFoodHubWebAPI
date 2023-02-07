using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TheFoodHubBE.Models;

namespace TheFoodHubBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StaffsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Staffs staffs)
        {
           Response response = new Response();
           DAL dal = new DAL();
           SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            response = dal.register(staffs, connection);
           return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(string Email, string Password)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.login(Email, Password, connection);
            return response;
        }

        [HttpPost]
        [Route("viewStaff")]
        public Response viewStaff(int StaffID)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.viewStaff(StaffID, connection);
            return response;
        }

        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Staffs staffs)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection (_configuration.GetConnectionString("TheFoodHubBE").ToString());
            Response response = dal.updateProfile(staffs, connection);

            return response;
        }


    }
}

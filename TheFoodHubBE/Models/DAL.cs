using System.Data.SqlClient;
using System.Data;

namespace TheFoodHubBE.Models
{
    public class DAL
    { 
        public Response register(Staffs staffs, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("addStaff", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", staffs.FirstName);
            cmd.Parameters.AddWithValue("@LastName", staffs.LastName);
            cmd.Parameters.AddWithValue("@Email", staffs.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", staffs.PhoneNo);
            cmd.Parameters.AddWithValue("@DOB", staffs.DOB);
            cmd.Parameters.AddWithValue("@Gender", staffs.Gender);
            cmd.Parameters.AddWithValue("@Religion", staffs.Religion);
            cmd.Parameters.AddWithValue("@Nationality", staffs.Nationality);
            cmd.Parameters.AddWithValue("@Location", staffs.Location);
            cmd.Parameters.AddWithValue("@Job", staffs.Job);
            cmd.Parameters.AddWithValue("@Role", "Staff");
            cmd.Parameters.AddWithValue("@Status", staffs.Status);
            cmd.Parameters.AddWithValue("@CreatedOn", staffs.CreatedOn);
            cmd.Parameters.AddWithValue("@Password", staffs.Password);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Application Successful";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Application Failed";

            }
            return response;
        }

        public Response login(string Email, string Password, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("Login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Staffs staff = new Staffs();
            if(dt.Rows.Count > 0)
            {
                staff.StaffID = Convert.ToInt32(dt.Rows[0]["StaffID"]);
                staff.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                staff.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                staff.Email = Convert.ToString(dt.Rows[0]["Email"]);
                staff.Role = Convert.ToString(dt.Rows[0]["Role"]);
                response.StatusCode = 200;
                response.StatusMessage = "Staff is Valid";
                response.staff = staff;
            }
            else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff is Invalid";
                response.staff = null;
            }
            return response;
        }

        public Response viewStaff(int StaffID, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("ViewStaff", connection);
            da.SelectCommand.CommandType= CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@StaffID", StaffID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Staffs staff = new Staffs();
            if (dt.Rows.Count > 0)
            {
                staff.StaffID = Convert.ToInt32(dt.Rows[0]["StaffID"]);
                staff.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                staff.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                staff.Email = Convert.ToString(dt.Rows[0]["Email"]);
                staff.Role = Convert.ToString(dt.Rows[0]["Role"]);
                staff.PhoneNo = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                staff.DOB = Convert.ToString(dt.Rows[0]["DOB"]);
                staff.Gender = Convert.ToString(dt.Rows[0]["Gender"]);
                staff.Religion = Convert.ToString(dt.Rows[0]["Religion"]);
                staff.Nationality = Convert.ToString(dt.Rows[0]["Nationality"]);
                staff.Location = Convert.ToString(dt.Rows[0]["Location"]);
                staff.Job = Convert.ToString(dt.Rows[0]["Job"]);
                staff.Password = Convert.ToString(dt.Rows[0]["Password"]);

                staff.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                response.StatusCode = 200;
                response.StatusMessage = "Staff Exists";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Does Not Exist";
                response.staff = staff;
            }
            return response;

        }
        public Response updateProfile(Staffs staffs, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UpdateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffID", staffs.StaffID);
            cmd.Parameters.AddWithValue("@FirstName", staffs.FirstName);
            cmd.Parameters.AddWithValue("@LastName", staffs.LastName);
            cmd.Parameters.AddWithValue("@Email", staffs.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", staffs.PhoneNo);
            cmd.Parameters.AddWithValue("@DOB", staffs.DOB);
            cmd.Parameters.AddWithValue("@Gender", staffs.Gender);
            cmd.Parameters.AddWithValue("@Religion", staffs.Religion);
            cmd.Parameters.AddWithValue("@Nationality", staffs.Nationality);
            cmd.Parameters.AddWithValue("@Location", staffs.Location);
            cmd.Parameters.AddWithValue("@Job", staffs.Job);
            cmd.Parameters.AddWithValue("@Status", staffs.Status);
            
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record Updated Successfully";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Error. Try again later";
            }
            return response;
        }
    
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffID", cart.StaffID);
            cmd.Parameters.AddWithValue("@ProductID", cart.ProductID);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item Added Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item Could Not Be Added";
            }
            return response;
        }

        public Response placeOrder(Staffs staffs, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StaffID", staffs.StaffID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order Has Been Placed Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order Could Not Be Placed";
            }
            return response;
        }

        public Response orderList(Staffs staffs, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrder = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Role", staffs.Role);
            da.SelectCommand.Parameters.AddWithValue("@StaffID", staffs.StaffID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            Staffs staff = new Staffs();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.OrderID = Convert.ToInt32(dt.Rows[i]["OrderID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrder.Add(order);  
                }
                if(listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order Details Fetched";
                    response.ListOrders = listOrder;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order Details Not Available";
                    response.ListOrders = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order Details Not Available";
                response.ListOrders = null;
            }
            return response;
        }

        public Response addCategory(string categoryName, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("AddCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Category Added Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Category Did Not Save, Try Again";
            }
            return response;
        }

        public Response updateCategory(Category category, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("updateCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Category Updated Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Category Did Not Update, Try Again";

            }
            return response;
        }

        public Response addProduct(Products products, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("addProduct", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", products.ProductName);
            cmd.Parameters.AddWithValue("@ProductName", products.CategoryID);
            cmd.Parameters.AddWithValue("@ProductName", products.Price);
            cmd.Parameters.AddWithValue("@ProductName", products.ProductImage);
            cmd.Parameters.AddWithValue("@ProductName", products.Status);
            cmd.Parameters.AddWithValue("@Type", products.Type);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Addded Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product Did Not Save, Try Again";

            }
            return response;
        }

        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            List<Staffs> listStaffs = new List<Staffs>();
            SqlDataAdapter da = new SqlDataAdapter("sp_StaffList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Staffs staff = new Staffs();
                    staff.StaffID = Convert.ToInt32(dt.Rows[i]["StaffID"]);
                    staff.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    staff.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    staff.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    staff.PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]);
                    staff.DOB = Convert.ToString(dt.Rows[i]["DOB"]);
                    staff.Gender = Convert.ToString(dt.Rows[i]["Gender"]);
                    staff.Religion = Convert.ToString(dt.Rows[i]["Religion"]);
                    staff.Nationality = Convert.ToString(dt.Rows[i]["Nationality"]);
                    staff.Location = Convert.ToString(dt.Rows[i]["Location"]);
                    staff.Job = Convert.ToString(dt.Rows[i]["Job"]);
                    staff.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    staff.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    staff.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);

                    listStaffs.Add(staff);
                }
                if (listStaffs.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Staff Details Fetched";
                    response.listStaffs = listStaffs;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Staff Details Not Available";
                    response.listStaffs = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Details Not Available";
                response.ListOrders = null;
            }
            return response;
        }


    }
}

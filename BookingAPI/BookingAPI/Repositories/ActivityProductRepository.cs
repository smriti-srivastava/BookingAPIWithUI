using BookingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingAPI.RepositoryLayer
{
    public class ActivityProductRepository : IProductRepository<Activity>
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK149;Initial Catalog=ProductDB;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public bool AddProduct(Activity activityProduct)
        {
            connection();
            string query = "INSERT INTO Activity(Name, Price, Place, FromTime, ToTime, IsBooked, IsSaved) VALUES(@name, @price, @place, @fromTime, @toTime, @isBooked, @isSaved)";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@name", activityProduct.Name);
            command.Parameters.AddWithValue("@price", activityProduct.Price);
            command.Parameters.AddWithValue("@place", activityProduct.Place);
            command.Parameters.AddWithValue("@fromTime", activityProduct.ToTime);
            command.Parameters.AddWithValue("@toTime", activityProduct.ToTime);
            command.Parameters.AddWithValue("@isBooked", false);
            command.Parameters.AddWithValue("@isSaved", false);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Activity> GetAllProducts()
        {
            connection();
            List<Activity> hotelList = new List<Activity>();
            string query = "SELECT * FROM Activity";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                hotelList.Add(
                    new Activity
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Place = Convert.ToString(dr["Place"]),
                        FromTime = Convert.ToString(dr["FromTime"]),
                        ToTime = Convert.ToString(dr["ToTime"]),
                        Price = (float)Convert.ToDouble(dr["Price"]),
                        IsBooked = Convert.ToBoolean(dr["IsBooked"]),
                        IsSaved = Convert.ToBoolean(dr["IsSaved"])
                    }
                );

            }
            return hotelList;
        }

        public bool SaveProduct(int id)
        {
            connection();
            string query = "UPDATE Activity SET IsSaved=1 WHERE Id=@id";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }

        public bool BookProduct(int id)
        {
            connection();
            string query = "UPDATE Activity SET IsBooked=1 WHERE Id=@id";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
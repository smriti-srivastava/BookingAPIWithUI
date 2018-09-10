using BookingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingAPI.RepositoryLayer
{
    public class HotelProductRepository : IProductRepository<Hotel>
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK149;Initial Catalog=ProductDB;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public bool AddProduct(Hotel hotelProduct)
        {
            connection();
            string query = "INSERT INTO Hotel(Name, Price, LandMark, City, FromDate, ToDate, IsBooked, IsSaved) VALUES(@name, @price, @landMark, @city, @fromDate, @toDate, @isBooked, @isSaved)";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@name", hotelProduct.Name);
            command.Parameters.AddWithValue("@price", hotelProduct.Price);
            command.Parameters.AddWithValue("@landMark", hotelProduct.LandMark);
            command.Parameters.AddWithValue("@city", hotelProduct.City);
            command.Parameters.AddWithValue("@fromDate", hotelProduct.FromDate);
            command.Parameters.AddWithValue("@toDate", hotelProduct.ToDate);
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

        public List<Hotel> GetAllProducts()
        {
            connection();
            List<Hotel> hotelList = new List<Hotel>();
            string query = "SELECT * FROM Hotel";
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
                    new Hotel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        LandMark = Convert.ToString(dr["LandMark"]),
                        City = Convert.ToString(dr["City"]),
                        FromDate = Convert.ToString(dr["FromDate"]),
                        ToDate = Convert.ToString(dr["ToDate"]),
                        IsBooked = Convert.ToBoolean(dr["IsBooked"]),
                        Price = (float)Convert.ToDouble(dr["Price"]),
                        IsSaved = Convert.ToBoolean(dr["IsSaved"])
                    }
                );

            }
            return hotelList;
        }

        public bool SaveProduct(int id)
        {
            connection();
            string query = "UPDATE Hotel SET IsSaved=1 WHERE Id=@id";
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
            string query = "UPDATE Hotel SET IsBooked=1 WHERE Id=@id";
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
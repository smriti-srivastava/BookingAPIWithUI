using BookingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingAPI.RepositoryLayer
{
    public class AirProductRepository : IProductRepository<Air>
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK149;Initial Catalog=ProductDB;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public bool AddProduct(Air airProduct)
        {
            connection();
            string query = "INSERT INTO Air(Name, Price, DepartureTime, ArrivalTime, Duration, IsBooked, IsSaved) VALUES(@name, @price, @departureTime, @arrivalTime, @duration, @isBooked, @isSaved)";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            airProduct.Duration = Convert.ToString(Convert.ToDateTime(airProduct.ArrivalTime) - Convert.ToDateTime(airProduct.DepartureTime));
            command.Parameters.AddWithValue("@name", airProduct.Name);
            command.Parameters.AddWithValue("@price", airProduct.Price);
            command.Parameters.AddWithValue("@departureTime", airProduct.DepartureTime);
            command.Parameters.AddWithValue("@arrivalTime", airProduct.ArrivalTime);
            command.Parameters.AddWithValue("@duration", airProduct.Duration);
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

        public List<Air> GetAllProducts()
        {
            connection();
            List<Air> AirList = new List<Air>();
            string query = "SELECT * FROM Air";
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
                AirList.Add(
                    new Air
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        DepartureTime = Convert.ToString(dr["DepartureTime"]),
                        ArrivalTime = Convert.ToString(dr["ArrivalTime"]),
                        Duration = Convert.ToString(dr["Duration"]),
                        Price = (float)Convert.ToDouble(dr["Price"]),
                        IsBooked = Convert.ToBoolean(dr["IsBooked"]),
                        IsSaved = Convert.ToBoolean(dr["IsSaved"])
                    }
                );

            }
            return AirList;
        }

        public bool SaveProduct(int id)
        {
            connection();
            string query = "UPDATE Air SET IsSaved=1 WHERE Id=@id";
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
            string query = "UPDATE Air SET IsBooked=1 WHERE Id=@id";
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
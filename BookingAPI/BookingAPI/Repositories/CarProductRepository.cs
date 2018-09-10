using BookingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookingAPI.RepositoryLayer
{
    public class CarProductRepository : IProductRepository<Car>
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = @"Data Source=TAVDESK149;Initial Catalog=ProductDB;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

        }
        public bool AddProduct(Car carProduct)
        {
            connection();
            string query = "INSERT INTO Car(Name, Price, Model, Company, IsBooked, IsSaved) VALUES(@name, @price, @model, @company, @isBooked, @isSaved)";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            command.Parameters.AddWithValue("@name", carProduct.Name);
            command.Parameters.AddWithValue("@price", carProduct.Price);
            command.Parameters.AddWithValue("@model", carProduct.Model);
            command.Parameters.AddWithValue("@company", carProduct.Company);
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

        public List<Car> GetAllProducts()
        {
            connection();
            List<Car> carList = new List<Car>();
            string query = "SELECT * FROM Car";
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
                carList.Add(
                    new Car
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Model = Convert.ToString(dr["Model"]),
                        Company = Convert.ToString(dr["Company"]),
                        Price = (float)Convert.ToDouble(dr["Price"]),
                        IsBooked = Convert.ToBoolean(dr["IsBooked"]),
                        IsSaved = Convert.ToBoolean(dr["IsSaved"])
                    }
                );

            }
            return carList;
        }

        public bool SaveProduct(int id)
        {
            connection();
            string query = "UPDATE Car SET IsSaved=1 WHERE Id=@id";
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
            string query = "UPDATE Car SET IsBooked=1 WHERE Id=@id";
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
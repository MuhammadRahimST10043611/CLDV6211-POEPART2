using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace POEPART1.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:st10043611-server.database.windows.net,1433;Initial Catalog=st10043611-db;Persist Security Info=False;User ID=muhammad;Password=Aneesah28!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(connectionString: con_string);

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public int ProductAvailability { get; set; }

        public int insert_product(productTable p)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@ProductName, @ProductPrice, @ProductCategory, @ProductAvailability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", p.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCategory", p.ProductCategory);
                cmd.Parameters.AddWithValue("@ProductAvailability", p.ProductAvailability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }
        }

        //Method to retrive all products from the database
        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable product = new productTable();
                    product.ProductID = Convert.ToInt32(rdr["ProductId"]);
                    product.ProductName = rdr["ProductName"].ToString();
                    product.ProductPrice = Convert.ToInt32(rdr["ProductPrice"]);
                    product.ProductCategory = rdr["ProductCategory"].ToString();
                    product.ProductAvailability = Convert.ToInt32(rdr["ProductAvailability"]);

                    products.Add(product);
                }
            }
            return products;
        }
    }
}





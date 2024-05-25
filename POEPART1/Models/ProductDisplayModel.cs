using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace POEPART1.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public bool ProductAvailability { get; set; }

        public ProductDisplayModel() { }

        public ProductDisplayModel(int productID, string productName, decimal productPrice, string productCategory, bool productAvailability)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
            ProductAvailability = productAvailability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:st10043611-server.database.windows.net,1433;Initial Catalog=st10043611-db;Persist Security Info=False;User ID=muhammad;Password=Aneesah28!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel model = new ProductDisplayModel();
                    model.ProductID = Convert.ToInt32(reader["ProductID"]);
                    model.ProductName = Convert.ToString(reader["ProductName"]);
                    model.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                    model.ProductCategory = Convert.ToString(reader["ProductCategory"]);
                    model.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);
                    products.Add(model);
                }
                reader.Close();
            }
            return products;
        }
    }
}


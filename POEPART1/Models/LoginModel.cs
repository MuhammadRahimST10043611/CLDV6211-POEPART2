using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace POEPART1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:st10043611-server.database.windows.net,1433;Initial Catalog=st10043611-db;Persist Security Info=False;User ID=muhammad;Password=Aneesah28!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectUser(string email, string password)
        {
            int userID = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE UserPassword = @Password AND UserEmail = @Email";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw ex;
                }
            }
            return userID;
        }
    }
}


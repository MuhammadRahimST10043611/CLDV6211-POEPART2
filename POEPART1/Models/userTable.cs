using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace POEPART1.Models
{
    public class userTable
    {
        public static string con_string = "Server=tcp:st10043611-server.database.windows.net,1433;Initial Catalog=st10043611-db;Persist Security Info=False;User ID=muhammad;Password=Aneesah28!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int insert_User(userTable table)
        {
            try
            {
                string sql = "INSERT INTO UserTable (UserName, UserSurname, UserPassword, UserEmail) VALUES (@Name, @Surname, @Password, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", table.Name);
                cmd.Parameters.AddWithValue("@Surname", table.Surname);
                cmd.Parameters.AddWithValue("@Password", table.Password);
                cmd.Parameters.AddWithValue("@Email", table.Email);
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

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADODotNetPractice
{
    public class UserRepo
    {
        public static string connectionString = @"Data Source=LAPTOP-HB42IHJ0\SQLEXPRESS;Initial Catalog=DemoDBPractice;Integrated Security=True;TrustServerCertificate=True;Encrypt=false";
       // public string connectionConnection = @"Server=LAPTOP-HB42IHJ0\SQLEXPRESS;Database=DemoDBPractice;Trusted_Connection=True";
        //The second connection string is a template for connecting to any SQL Server instance and database, which you can customize.
        SqlConnection connection = new SqlConnection(connectionString);// throwing exception

        public bool AddUserDetails(UserDetails user)
        {
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("spAddUserDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName",  user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                connection.Open();
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                { 
                    return true;
                }
                return false;
            }
        }

        public void GetAllUsers()
        {
            UserDetails users = new UserDetails();
            using (connection)
            {
                string query = "select * from UserDetails";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.UserId = reader.GetInt32(0);
                        users.FirstName = reader.GetString(1);
                        users.LastName = reader.GetString(2);
                        users.Email = reader.GetString(3);
                        users.Password = reader.GetString(4);
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", users.UserId, users.FirstName, users.LastName, users.Email, users.Password);

                    }
                }
            }
        }


        public void UpdateUser(UserDetails user)
        {
            using (this.connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateUserDetails", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                this.connection.Open();
                
                cmd.ExecuteNonQuery();
                Console.WriteLine("User updated successfully!");

            }
        }

        public void DeleteUser(int userId)
        {
            using (this.connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteUser", this.connection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                this.connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("User deleted successfully!");
            }
        }
    }
}

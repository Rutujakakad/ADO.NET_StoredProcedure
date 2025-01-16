// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using Microsoft.Data.SqlClient;
namespace ADODotNetPractice
{
    class Program
    {
        private static string connectionString;

        static void Main(string[] args)
        {

            string connectionSring = @"Data Source=LAPTOP-HB42IHJ0\SQLEXPRESS;Initial Catalog=CoDb;Integrated Security=True;TrustServerCertificate=True;Encrypt=false";
            SqlConnection connection;
            try
            {
                connection = new SqlConnection(connectionSring);
                connection.Open();
                Console.WriteLine("Connection established successfully");

                Console.WriteLine("Select from the options below\n1. Create\n2. Retrieve\n3. Update \n4. Delete");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // Create path for CRUD operations: Insert
                        Console.WriteLine("ENter your name:");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter your Age:");
                        int userAge = int.Parse(Console.ReadLine());
                        string insertQuery = "INSERT INTO Details(user_name, user_age) VALUES ('" + userName + "', " + userAge + ")";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("Data is successfully inserted into table");
                        break;
                    case 2:
                        //Retreieve =>R
                        string displayQuery = "Select * from Details";
                        SqlCommand displayCommand = new SqlCommand(displayQuery, connection);
                        SqlDataReader dataReader = displayCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                            Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                            Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());

                        }
                        dataReader.Close();

                        break;
                    case 3:
                        //Update
                        int u_id;
                        int u_age;
                        Console.WriteLine("Enter the user id you would like to update");
                        u_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("ENetr the age of the user to update");
                        u_age = int.Parse(Console.ReadLine());
                        string update_Query = "UPDATE Details SET user_age = " + u_age + " WHERE user_id = " + u_id + "";
                        SqlCommand updateCommand = new SqlCommand(update_Query, connection);
                        updateCommand.ExecuteNonQuery();
                        Console.WriteLine("Data Updated Successfully");
                        break;
                    case 4:
                        // Delete 
                        int d_id;
                        Console.WriteLine("Enter the id of the record that is to be deleted");
                        d_id = int.Parse(Console.ReadLine());
                        string deleteQuery = "DELETE FROM Details Where user_id = " + d_id;
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.ExecuteNonQuery();
                        Console.WriteLine(" Deleted Successfully");
                        connection.Close();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    
}

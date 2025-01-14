// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
namespace ADODotNetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            AddInput();
            UserRepo repo = new UserRepo();
            repo.GetAllUsers();

            var updatedUser = new UserDetails
            {
                UserId = 1,
                FirstName = "Johnny",
                LastName = "Daren",
                Email = "johnny.doe@example.com",
                Password = "newpassword123"
            };
            repo.UpdateUser(updatedUser);
            repo.DeleteUser(11);
        }
        public static void AddInput()
        {
            UserRepo repo = new UserRepo();
            UserDetails user = new UserDetails();
            user.FirstName = "John";
            user.LastName = "Dsouza";
            user.Email = "john@gmail.com";
            user.Password = "John@123";
            Console.WriteLine(repo.AddUserDetails(user) ? "Data added successfully": "Operation failed");
        }

        
    }

}

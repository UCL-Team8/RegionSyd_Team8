using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd_Team8.Models
{
    public class UserRepository
    {
        private List<User> users;

        public UserRepository()
        {
            // Her we can replace by the database or other data source about the users (disponent) information.
            users = new List<User>
            {
                new User { Username = "admin", Password = "password123" },
                new User { Username = "user1", Password = "password456" }
            };
        }

        
        // Method to get all users (It can be done her by a call to DB or API)
        public List<User> GetAllUsers()
        {
            return users;
        }

        // Method to find a user by username and password
        public User FindUser(string username, string password)
        {
            // Safeguard against null values by checking for null and assigning empty strings as default.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Return null or handle the error as per your design.
                return null;
            }

            return users.FirstOrDefault(u => u.Username == username && u.Password == password); ;
        }


    }
}

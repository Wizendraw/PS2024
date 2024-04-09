using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(this User user)
        {
            string output = $"User Name: {user.Name} \n" +
                    $"Password: {user.Password} \n" +
                    $"ID: {user.ID} \n" +
                    $"Role: {user.Role} \n" +
                    $"Expires: {user.Expires}";

            return output;
        }
        public static bool ValidateCredentials(this UserData data, string name, string password)
        {
            if(name == null || password == null)
            {
                throw new Exception("The field cannot be empty");
            }
           
            return data.ValidateUser(name, password);
        }
        public static bool ValidateCredentialsLinq(this UserData data, string name, string password)
        {
            if (name == null || password == null)
            {
                throw new Exception("The field cannot be empty");
            }

            return data.ValidateUserLinq(name, password);
        }
        public static User GetUser(this UserData data, string name, string password)
        {
            return data.GetUser(name, password);
        }
    }
}

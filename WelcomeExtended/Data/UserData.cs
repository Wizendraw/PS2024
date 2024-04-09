using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> m_Users;
        private int m_NextID;
        private bool m_IsActive = false;
        public UserData()
        {
            m_Users = new List<User>();
            m_NextID = 0;
        }
        public void AddUser(User user)
        {
            user.ID = m_NextID++;
            m_Users.Add(user);
            m_NextID++;
        }
        
        public User AddUser()
        {
            Console.WriteLine("Enter user Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter user Password");
            string pass = Console.ReadLine();

            bool isValidRole;
            do
            {
                Console.WriteLine("Enter user Role. \n\tADMIN, STUDENT, PROFESSOR, INSPECTOR, \n\t ");
                string role = Console.ReadLine();

                isValidRole = Enum.TryParse<UserRolesEnum>(role.ToUpper(), out var rola);
                if (isValidRole)
                {
                    User user = new User(name, pass, rola);
                    user.ID = m_NextID++;
                    m_Users.Add(user);
                    ++m_NextID;

                    return m_Users.Last();
                }
                else
                    Console.WriteLine("Wrong user Role!\n");
            } while (!isValidRole);

            return m_Users.Last(); // for the compiler
        }
        public void RemoveUser(User user) 
        {
            m_Users.Remove(user);
        }
        public void RemoveUser()
        {
            Console.WriteLine("Enter user Name to remove\n");
            string name = Console.ReadLine();

            foreach (User user in m_Users)
            {
                if (user.Name == name)
                {
                    m_Users.Remove(user);
                    return;
                }
            }
        }
        public bool ValidateUser(string name, string password)
        {
            foreach(User user in m_Users) 
            {
                if(user.Name == name && user.Password == password) 
                    return true;

            }
            return false;
        }

        public bool ValidateUserLambda(string name,string password)
        {
            return m_Users.Where(x=>x.Name==name && x.Password==password).FirstOrDefault() != null;
        }
        public bool ValidateUserLinq(string name,string password)
        {
            var ret = from user in m_Users
                      where user.Name == name && user.Password == password
                      select user.ID;
           
            return ret != null;
        }
        /// <summary>
        /// if NullException check for valid name/pass
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string name, string password)
        {
            foreach (User user in m_Users)
            {
                if (user.Name == name && user.Password == password)
                    return user;

            }

            return null;
        }

        public void SetActive(string name, string date)
        {
            DateTime temp;
            if(DateTime.TryParse(date, out temp)) //valid date
            {
                foreach (User user in m_Users)
                {
                    if (user.Name == name)
                    {
                        user.Expires = temp;
                        return;                     // skip searching
                    }

                }
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            foreach (User user in m_Users)
            {
                if (user.Name == name)
                {
                    user.Role = role;
                    return;
                }

            }
        }
    }
}

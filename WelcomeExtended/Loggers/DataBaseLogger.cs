using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

namespace WelcomeExtended.Loggers
{
    public static class DataBaseLogger
    {
        static DataBaseContext context = new DataBaseContext();
        public static void ShowMenu(UserData data)
        {
            bool keep;
            do
            {
                Console.WriteLine("Choose menu option\n\t1.List all users 2.Add new user to DB 3. Delete user\n");
                keep = int.TryParse(Console.ReadLine(), out int input);
                if (keep)
                {
                    switch (input)
                    {
                        case 1:
                            ListAll();
                            break;
                        case 2:
                            DataBaseUser user = (DataBaseUser)data.AddUser();   //Add first to local 
                            context.Add<DataBaseUser>(user);                    //then to DB
                            context.SaveChanges(); 
                            break;
                        case 3:
                            data.RemoveUser();
                            break;
                        default:
                            return;
                    }
                }
            } while (keep);
        }

        private static void ListAll()
        {
            StringBuilder sb = new StringBuilder();

            context.Database.EnsureCreated();
            context.SaveChanges();

            var users = context.Users.ToList();

            foreach (var user in users)
            {
                sb.AppendLine(user.ToString()+ '\n');
            }
            Console.WriteLine(sb.ToString());
        }
    }
}

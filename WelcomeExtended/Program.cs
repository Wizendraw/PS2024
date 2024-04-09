// See https://aka.ms/new-console-template for more information
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;
using static WelcomeExtended.Others.Delegates;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData data = new UserData();

            DataBaseLogger.ShowMenu(data);
            /*
            UserData data = new UserData();

            using (var context = new DataBaseContext())
            {
                context.Database.EnsureCreated();
                DataBaseUser user = new DataBaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.UtcNow,
                    Role = UserRolesEnum.STUDENT
                };
                data.AddUser(user);                 //local
                context.Add<DataBaseUser>(user);    //DB
                    
                context.SaveChanges();
                var users = context.Users.ToList();
                Console.ReadKey();
            }

            try
            {
                if (UserHelper.ValidateCredentialsLinq(data, "user", "password"))
                    Console.WriteLine(UserHelper.ToString(data.GetUser("user", "password"))); 
                else
                    throw new Exception("[Exception] User not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
#if false
            {


                UserData userData = new UserData();
                var user = new User("John Smith", "password123", UserRolesEnum.STUDENT);

                userData.AddUser(user);

                User user2 = new User("Student2", "123", UserRolesEnum.STUDENT);
                User user3 = new User("Teacher", "1234", UserRolesEnum.PROFESSOR);
                User user4 = new User("Admin", "12345", UserRolesEnum.ADMIN);

                userData.AddUser(user2);
                userData.AddUser(user3);
                userData.AddUser(user4);

                Console.WriteLine("Enter user name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter password");
                string pass = Console.ReadLine();

                try
                {
                    if (UserHelper.ValidateCredentials(userData, name, pass))
                        Console.WriteLine(UserHelper.ToString(userData.GetUser(name, pass)));
                    else
                        throw new Exception("[Exception] User not found");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /*
            try
            {
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.Display();
                view.DisplayError();
            }
            catch (Exception ex) 
            {
                var log = new ActionOnError(Log);
                log(ex.Message);
            }
            */
#endif
        }
    }
}

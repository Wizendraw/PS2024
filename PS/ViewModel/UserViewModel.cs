using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User m_User;

        public UserViewModel(User user)
        {
            m_User = user;
        }
        public User User
        {
            get { return m_User; }
            set { m_User = value; }
        }
        public string Name
        {
            get { return m_User.Name; }
            set { m_User.Name = value; }
        }

        public string Password
        {
            get { return m_User.Password; }
            set { m_User.Password = value; }
        }
        public UserRolesEnum Role
        {
            get { return m_User.Role; }
            set { m_User.Role = value; }
        }

    }
}

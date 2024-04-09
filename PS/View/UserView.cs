using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel m_ViewModel;
        public UserView(UserViewModel viewMdel)
        {
            m_ViewModel = viewMdel;
        }
        public void Display()
        {
            Console.WriteLine("Welcome \nUser:{0}\nRole:{1}", m_ViewModel.Name, m_ViewModel.Role);
        }
        public void DisplayError()
        {
            throw new Exception("Some error text message");
        }

        public UserViewModel ViewModel
        {
            get { return m_ViewModel; }
            set { m_ViewModel = value; }
        }

    }
}

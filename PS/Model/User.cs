using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string m_Name;
        private string m_Password;
        private int m_Id;
        private DateTime m_Expires;
        private UserRolesEnum m_Role;

        public User()
        {
            m_Name = "UnknownUser";
        }
        public User(string name)
        {
            m_Name =name;
        }
        public User(string name, string password, UserRolesEnum role)
        {
            m_Name = name;
            m_Password = password;
            m_Role = role; 
            m_Expires = DateTime.UtcNow.AddYears(1);
        }
        
        public string Name 
        { 
            get => m_Name; 
            set => m_Name = value;  
        }
        public virtual int ID
        {
            get => m_Id;
            set => m_Id = value; 
        }

        public string Password 
        { 
            get => m_Password;
            set => m_Password = value;
        }
        public UserRolesEnum Role 
        { 
            get => m_Role; 
            set => m_Role = value;
        }
        public DateTime Expires
        {
            get => m_Expires;
            set => m_Expires = value;
        }
        public override string ToString()
        {
            return  $"User Name: {Name} \n" +
                    $"Password: {Password} \n" +
                    $"ID: {ID} \n" +
                    $"Role: {Role} \n" +
                    $"Expires: {Expires}";
        }

    }
}

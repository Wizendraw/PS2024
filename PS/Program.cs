
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

class Program
{
    static void Main(string[] args)
    {
        User potrbitel = new User();
        UserViewModel model = new UserViewModel(potrbitel);
        UserView view = new UserView(model);
        view.Display();
        
        string name = Console.ReadLine();
        User nov = new User(name);
        model.Name = name;
        view.Display();
    }
}

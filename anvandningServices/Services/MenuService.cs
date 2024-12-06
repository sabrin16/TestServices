using anvandningServices.Factories;
using anvandningServices.Models;

namespace anvandningServices.Services;

public class MenuService
{
    private readonly UserService _userService = new UserService();


    public void Show()
    {
        while(true)
        {
            MainMenu();
        }
    }


    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine($"{"1.",-5} Create");
        Console.WriteLine($"{"2.",-5} View");
        Console.WriteLine($"{"Q.",-5} Quit Application");
        Console.WriteLine("---------------------------------");
        Console.Write("Choose your menu option: ");
        var option = Console.ReadLine()!;

        switch (option)
        {
            case "q":
                QuitOption();
                break;

            case "1":
                CreateOption();
                break;

            case "2":
                ViewOption();
                break;

            default:
                InvalidOption();
                break;
        }
    }

    public void QuitOption()
    {
        Console.Clear();
        Console.Write("Do you want to exit this application (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }


    public void CreateOption()
    {
        UserRegistrationForm userRegistrationForm = UserFactory.Create();

        Console.Clear();

        Console.Write("Enter your first name: ");
        userRegistrationForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        userRegistrationForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        userRegistrationForm.Email = Console.ReadLine()!;

        Console.Write("Enter your password: ");
        userRegistrationForm.Password = Console.ReadLine()!;

        bool result = _userService.Create(userRegistrationForm);

        if (result)
            OutputDialog("User was successfully created.");
        else
            OutputDialog("User was not created successfully.");

    }


    public void ViewOption()
    {                
        var users = _userService.GetAll();

        Console.Clear();

        foreach(var user in users)
        {
            Console.WriteLine($"{"Id:",-15}{user.Id}");
            Console.WriteLine($"{"Name:",-15}{user.FirstName} {user.LastName}");
            Console.WriteLine($"{"Email:",-15}{user.Email}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }


    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("You must enter a valid option.");
        Console.ReadKey();
    }


    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}


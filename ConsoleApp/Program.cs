using ConsoleApp.Services;

MenuManager menuManager = new MenuManager();

while (true)
{
    Console.Clear();
    Console.WriteLine("# ADRESS BOOK #");
    Console.WriteLine();
    Console.WriteLine($"{"1.", -2} Add Contact");
    Console.WriteLine($"{"2.",-2} Show One Contact");
    Console.WriteLine($"{"3.",-2} Show All Contacts");
    Console.WriteLine($"{"4.",-2} Remove a Contact");
    Console.WriteLine($"{"5.",-2} Exit");
    Console.Write("\nEnter your choice: ");
    

    int choice;

    if (int.TryParse(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                menuManager.AddContact();
                break;

            case 2:
                Console.Clear();
                menuManager.ShowOneContact();
                Console.ReadKey();
                break;

            case 3:
                Console.Clear();
                menuManager.ShowAllContacts();
                Console.ReadKey();
                break;

            case 4:
                Console.Clear();
                menuManager.RemoveContact();
                Console.ReadKey();
                break;

            case 5:
                menuManager.ExitProgram();
                break;

            default:
                Console.WriteLine("\nInvalid choice. Please try again.");
                Console.ReadKey();
                break;
        }
    }

    else
    {
        Console.WriteLine("\nInvalid input. Please enter a number.");
        Console.ReadKey();
    }
}

using ConsoleApp.Services;

MenuManager menuManager = new MenuManager();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Show One Contact");
    Console.WriteLine("3. Show All Contacts");
    Console.WriteLine("4. Remove a Contact");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");
    

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
                Console.WriteLine("Exiting the program");
                return;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                break;
        }
    }

    else
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        Console.ReadKey();
    }
}

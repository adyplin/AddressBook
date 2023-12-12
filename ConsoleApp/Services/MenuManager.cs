using ConsoleApp.Models;
namespace ConsoleApp.Services;

public class MenuManager
{
    private readonly ContactManager _contactManager = new ContactManager();


    public void AddContact()
    {
        Contact contact = new Contact();

        Console.Write("Enter First name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter Last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter Phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter Address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter City: ");
        contact.City = Console.ReadLine()!;

        Console.Write("Enter Postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        _contactManager.AddContactToList(contact);
    }


    public void ShowOneContact()
    {

        Console.Write("Enter email or first and last name of the contact to show: ");
        string searchKey = Console.ReadLine()!;

        try
        {
            Contact contactToShow = _contactManager.GetContactByEmailOrName(searchKey);

            if (contactToShow != null)
            {
                Console.WriteLine("Contact information:");
                Console.WriteLine($"Name: {contactToShow.FirstName} {contactToShow.LastName}");
                Console.WriteLine($"Email: {contactToShow.Email}");
                Console.WriteLine($"Phone Number: {contactToShow.PhoneNumber}");
                Console.WriteLine($"Address: {contactToShow.Address}, {contactToShow.City}, {contactToShow.PostalCode}");
                
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while showing the contact: {ex.Message}");
        }
    }

    public void ShowAllContacts()
    {
        try
        {
            IEnumerable<Contact> contacts = _contactManager.GetContactsFromList();

            if (contacts.Any())
            {
                Console.WriteLine("All Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("---------------");
                }
            }
            else
            {
                Console.WriteLine("No contacts available.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading contacts: {ex.Message}");
        }
    }

    public void RemoveContact()
    {
        Console.Write("Enter email or first and last name of the contact to remove: ");
        string searchKey = Console.ReadLine()!;

        try
        {
            Contact contactToRemove = _contactManager.GetContactByEmailOrName(searchKey);

            if (contactToRemove != null)
            {
                _contactManager.RemoveContactFromList(contactToRemove);
                Console.WriteLine("Contact removed successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while removing the contact: {ex.Message}");
        }
    }

    public void ExitProgram()
    {
        Console.Clear();
        Console.WriteLine("Are you sure that you want to close the application? (y/n)");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(5);
        }
    }
}

 

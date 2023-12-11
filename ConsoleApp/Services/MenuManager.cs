using ConsoleApp.Models;
namespace ConsoleApp.Services;

public class MenuManager
{
    private readonly ContactManager _contactManager = new ContactManager();


    public void AddContact()
    {
        Contact contact = new Contact();

        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your address: ");
        contact.Address = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contact.City = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        _contactManager.AddContactToList(contact);

        Console.WriteLine("Contact was added successfully");
        Console.ReadKey();
    }

    public void ShowOneContact()
    {

        Console.Write("Enter email or name of the contact to show: ");
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
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while showing the contact: {ex.Message}");
            Console.ReadKey();
        }
    }

    public void ShowAllContacts()
    {
        try
        {
            IEnumerable<Contact> contacts = _contactManager.GetContactFromList();

            if (contacts.Any())
            {
                Console.WriteLine("All Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.PostalCode}");
                    Console.WriteLine("---------------");

                }
            }
            else
            {
                Console.WriteLine("No contacts available.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading contacts: {ex.Message}");
            Console.ReadKey();
        }
    }

    public void RemoveContact()
    {
        Console.Write("Enter email or name of the contact to remove: ");
        string searchKey = Console.ReadLine()!;

        try
        {
            Contact contactToRemove = _contactManager.GetContactByEmailOrName(searchKey);

            if (contactToRemove != null)
            {
                _contactManager.RemoveContactFromList(contactToRemove);
                Console.WriteLine("Contact removed successfully.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Contact not found.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while removing the contact: {ex.Message}");
            Console.ReadKey();
        }
    }
}

 

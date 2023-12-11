using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class ContactManager
{
    private readonly FileManager _fileManager = new FileManager(@"C:\Projects-Education\contacts.json");
    private List<Contact> _contactsList = new List<Contact>();

    public void AddContactToList(Contact contact)
    {
       try
        {
            if (!_contactsList.Any(c => c.Email == contact.Email))
            {
                _contactsList.Add(contact);

                _fileManager.SaveContentToFile(JsonConvert.SerializeObject(_contactsList));
            }
            else
            {
                Console.WriteLine("Contact with this email already exists.");
                Console.ReadKey();
            }
        }
        catch (Exception ex) {Debug.WriteLine(ex.Message); }
    }

    public IEnumerable<Contact> GetContactFromList() 
    {
        try
        {
            var content = _fileManager.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                _contactsList = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _contactsList;
    }

    public Contact GetContactByEmailOrName(string searchKey)
    {
        IEnumerable<Contact> contacts = GetContactFromList();

        return contacts.FirstOrDefault(c =>
            c.Email.Equals(searchKey, StringComparison.OrdinalIgnoreCase) ||
            $"{c.FirstName} {c.LastName}".Equals(searchKey, StringComparison.OrdinalIgnoreCase))!;
    }

    public void RemoveContactFromList(Contact contact)
    {
        _contactsList.Remove(contact);
        _fileManager.SaveContentToFile(JsonConvert.SerializeObject(_contactsList));
    }


}



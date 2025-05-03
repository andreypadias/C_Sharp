using System.Text.Json;

public class ContactController
{

    string filePath = "contact.json";

    //Method to add contact
    public void AddContact(Contact contact)
    {
        List<Contact> contacts;

        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            // File doesn't exist or is empty — start a new list
            contacts = new List<Contact>();
        }
        else
        {
            string jsonContent = File.ReadAllText(filePath);

            // Attempt to deserialize existing content to a list
            try
            {
                contacts = JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();

                // If the content is a single object (not a list), wrap it
                if (contacts == null)
                {
                    var singleContact = JsonSerializer.Deserialize<Contact>(jsonContent);
                    contacts = singleContact != null ? new List<Contact> { singleContact } : new List<Contact>();
                }
            }
            catch
            {
                // Fallback: try reading a single object
                var singleContact = JsonSerializer.Deserialize<Contact>(jsonContent);
                contacts = singleContact != null ? new List<Contact> { singleContact } : new List<Contact>();
            }
        }

        contacts.Add(contact);

        // Serialize back to JSON array
        var options = new JsonSerializerOptions { WriteIndented = true };
        string updatedJson = JsonSerializer.Serialize(contacts, options);
        File.WriteAllText(filePath, updatedJson);
    }


    //Method to delete
    public void DeleteContact(int id)
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("No contacts found.");
        return;
    }

    // Read the entire JSON file content
    string jsonContent = File.ReadAllText(filePath);

    // Deserialize the JSON content into a list of Contact objects
    List<Contact> contacts;

    try
    {
        contacts = JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();
    }
    catch (JsonException)
    {
        Console.WriteLine("The JSON file is not in a valid format.");
        return;
    }

    // Find the contact with the matching ID
    var contactToDelete = contacts.FirstOrDefault(c => c.Id == id);
    if (contactToDelete == null)
    {
        Console.WriteLine($"No contact found with ID {id}.");
        return;
    }

    // Remove the contact from the list
    contacts.Remove(contactToDelete);

    // Serialize the updated list back to the JSON file
    string updatedJson = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, updatedJson);

    Console.WriteLine($"Contact with ID {id} has been deleted successfully.");
}

    //Method to update
    public void UpdateContact(int id, Contact updatedContact)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        // Read the entire JSON file content
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON content into a list of Contact objects
        List<Contact> contacts;

        try
        {
            contacts = JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();
        }
        catch (JsonException)
        {
            Console.WriteLine("The JSON file is not in a valid format.");
            return;
        }

        // Find the contact with the matching ID
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            Console.WriteLine($"No contact found with ID {id}.");
            return;
        }

        // Update the contact's details
        contact.Id = updatedContact.Id;
        contact.Name = updatedContact.Name;
        contact.Email = updatedContact.Email;
        contact.Phone = updatedContact.Phone;

        // Serialize the updated list back to the JSON file
        string updatedJson = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, updatedJson);

        Console.WriteLine($"Contact with ID {id} has been updated successfully.");
    }
    //Method to search
    public void SearchContact(string name)
    {


        if (!File.Exists(filePath))
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        // Read the entire JSON file content
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON content into a list of Contact objects
        List<Contact> contacts;

        try
        {
            // Attempt to deserialize as a list of contacts
            contacts = JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();

            // If deserialization as a list fails, try deserializing as a single object
            if (contacts == null)
            {
                var singleContact = JsonSerializer.Deserialize<Contact>(jsonContent);
                contacts = singleContact != null ? new List<Contact> { singleContact } : new List<Contact>();
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("The JSON file is not in a valid format.");
            return;
        }

        // Check if the deserialization was successful
        if (contacts == null || contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        // Find matching contacts
        var searchResults = contacts
            .Where(c => c.Name != null && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Display matching contacts
        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Contacts matching '{name}':");
            foreach (var contact in searchResults)
            {
                Console.WriteLine($" ID:{contact.Id} ,Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}");
            }
        }
        else
        {
            Console.WriteLine($"No contacts found with the name '{name}'.");
        }
    }

    //Method to show contact list
    public void ShowAllContacts()
    {

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        // Read the entire JSON file content
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON content into a list of Contact objects
        List<Contact> contacts;

        try
        {
            // Attempt to deserialize as a list of contacts
            contacts = JsonSerializer.Deserialize<List<Contact>>(jsonContent) ?? new List<Contact>();

            // If deserialization as a list fails, try deserializing as a single object
            if (contacts == null)
            {
                var singleContact = JsonSerializer.Deserialize<Contact>(jsonContent);
                contacts = singleContact != null ? new List<Contact> { singleContact } : new List<Contact>();
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("The JSON file is not in a valid format.");
            return;
        }

        // Check if the deserialization was successful
        if (contacts == null || contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }
        
        foreach (var contact in contacts)
        {
            Console.WriteLine($"ID:{contact.Id} , Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}");
        }

    }

}
using System.Net;

public class ContactView
{
     ContactController contactController = new ContactController();
    public void MainMenu()
    {
        do
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Update Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Search Contact");
            Console.WriteLine("5. Show All Contacts");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    UpdateContact();
                    break;
                case "3":
                    DeleteContact();
                    break;
                case "4":
                    SearchContact();
                    break;
                case "5":
                    ShowContactList(); 
                    break;
                case "6":
                    ShowExitMessage();
                    break;
                default:
                    ShowInvalidInput();
                    break;
            }
        } while (true);
        
    }

    public void AddContact()
    {
        try
        {
            Contact contact = new Contact();
            System.Console.WriteLine("Add Contact");
            Console.WriteLine("Enter contact name:");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Enter contact email:");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter contact phone:");
            contact.Phone = Console.ReadLine();
            contact.Id = new Random().Next(1, 1000)+(int)(DateTime.Now.Ticks); // Generate a random ID for the contact
            Console.WriteLine("Adding a new contact...");
            contactController.AddContact(contact);
            System.Console.WriteLine("Contact added successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("An error occurred while adding the contact. Error: " + ex.Message);
            throw;
        }
       
    }
    public void UpdateContact()
    {
        // Implement update contact logic here
        Console.WriteLine("Update Contact. Type the ID of the contact you want to update:");
        string? input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int id))
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter new contact name:");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Enter new contact email:");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter new contact phone:");
            contact.Phone = Console.ReadLine();
            contact.Id = id; // Use the provided ID
            contactController.UpdateContact(id, contact);
        }
        else
        {
            Console.WriteLine("Please enter a valid ID.");
        }
        Console.WriteLine("Contact updated successfully.");
    }

    public void DeleteContact()
    {
        // Implement delete contact logic here
        Console.WriteLine("Delete Contact");
    }

    public void SearchContact()
    {
        // Implement search contact logic here
        Console.WriteLine("Type the name of the contact you want to search:");
        string? input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            contactController.SearchContact(input);
        }
        else
        {
            Console.WriteLine("Please enter a valid name.");
        }

    }

    public void ShowContactList()
    {
        Console.WriteLine("Contact List:");
        contactController.ShowAllContacts();
        // Implement logic to display all contacts here
    }

    public void ShowExitMessage()
    {
        System.Console.WriteLine("Do you want to exit the application? (y/n)");
        string? input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && input.ToLower() == "y")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Returning to the main menu...");
        }
        Console.WriteLine("Exiting the application. Goodbye!");
    }

    public void ShowInvalidInput()
    {
        Console.WriteLine("Invalid input. Please try again.");
    }   
}
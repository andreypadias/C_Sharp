# Personal Agenda

A simple console-based application to manage a personal agenda. This application allows users to add, update, delete, search, and display contacts stored in a JSON file.

---

## Features

- **Add Contact**: Add a new contact to the JSON file.
- **Update Contact**: Update an existing contact's details using its ID.
- **Delete Contact**: Remove a contact from the JSON file using its ID.
- **Search Contact**: Search for contacts by name.
- **Show All Contacts**: Display all contacts stored in the JSON file.

---

## Technologies Used

- **Language**: C#
- **Data Storage**: JSON file
- **Framework**: .NET Core

---

## Project Structure

```
PersonalAgenda/
├── Controller/
│   └── ContactController.cs      # Handles contact-related operations
├── View/
│   └── ContactView.cs            # Handles user interaction
├── Model/
│   └── Contact.cs                # Defines the Contact class
├── Program.cs                    # Entry point of the application
└── contact.json                  # JSON file to store contact data
```

---

## How to Run

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/PersonalAgenda.git
   cd PersonalAgenda
   ```

2. **Build the Project**:  
   Ensure you have the .NET SDK installed. Run:
   ```bash
   dotnet build
   ```

3. **Run the Application**:  
   ```bash
   dotnet run
   ```

4. **Follow the Menu**:  
   Use the menu options to add, update, delete, search, or display contacts.

---

## JSON File Format

The `contact.json` file stores all contacts in the following format:

```json
[
  {
    "Id": 1,
    "Name": "John Doe",
    "Email": "john.doe@example.com",
    "Phone": "123-456-7890"
  },
  {
    "Id": 2,
    "Name": "Jane Smith",
    "Email": "jane.smith@example.com",
    "Phone": "987-654-3210"
  }
]
```

---

## Methods Overview

### `ContactController.cs`

- `AddContact(Contact contact)`: Adds a new contact to the JSON file.  
- `UpdateContact(int id, Contact updatedContact)`: Updates an existing contact's details using its ID.  
- `DeleteContact(int id)`: Deletes a contact from the JSON file using its ID.  
- `SearchContact(string name)`: Searches for contacts by name.  
- `ShowAllContacts()`: Displays all contacts stored in the JSON file.

### `ContactView.cs`

- `MainMenu()`: Displays the main menu and handles user input.  
- `AddContact()`: Collects user input to add a new contact.  
- `UpdateContact()`: Collects user input to update an existing contact.  
- `DeleteContact()`: Collects user input to delete a contact.  
- `SearchContact()`: Collects user input to search for contacts by name.  
- `ShowAllContacts()`: Displays all contacts.

---

## Future Enhancements

- Add validation for user input (e.g., email format, phone number format).  
- Implement sorting and filtering options for the contact list.  
- Add support for exporting contacts to a CSV file.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Author

**Your Name**  
GitHub: [your-username](https://github.com/your-username)

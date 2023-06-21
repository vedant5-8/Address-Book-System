
namespace Address_Book_System
{
    internal class AddressBookController
    {
        List<AddressBooks> addressBooks = new List<AddressBooks>();

        public void ExistingAddressBook()
        {
            AddressBooks addressBook1 = new AddressBooks("Personal");
            AddressBooks addressBook2 = new AddressBooks("Private");

            addressBooks.Add(addressBook1);
            addressBooks.Add(addressBook2);
        }
        public void ExistingContacts()
        {
            string Address_Book_Name1 = "Personal";

            Contact contact1 = new Contact("Vedant", "Patil", "vedantnp200@gmail.com", "8390386312", "Kalva", "Thane", "Maharashtra", "400605");
            Contact contact2 = new Contact("Raj", "Patil", "raj25@gmail.com", "9513576548", "Ranjankhar", "Alibag", "Maharashtra", "402209");
            Contact contact3 = new Contact("Sunny", "Patel", "sunnyp@gmail.com", "9713624805", "Khudad ", "Ahmedabad", "Gujrat", "380123");

            foreach (var addressBook in addressBooks)
            {
                if (addressBook.AddressBookName == Address_Book_Name1)
                {
                    addressBook.AddContact(contact1);
                    addressBook.AddContact(contact2);
                    addressBook.AddContact(contact3);
                }
            }

            string Address_Book_Name2 = "Private";

            Contact contact4 = new Contact("Mahesh", "Dattani", "mahesh.dattani@gmail.com", "8531467395", "Kachohalli", "Bangalore", "Karnataka", "560030");
            Contact contact5 = new Contact("Sahil", "Mhatre", "sahilkm@gmail.com", "8624753654", "Ranjankhar", "Alibag", "Maharashtra", "402209");
            Contact contact6 = new Contact("Raghubir", "Singh", "raghu.singh@gmail.com", "9371648250", "Kalwar", "Jaipur", "Rajasthan", "302010");

            foreach (var addressBook in addressBooks)
            {
                if (addressBook.AddressBookName == Address_Book_Name2)
                {
                    addressBook.AddContact(contact4);
                    addressBook.AddContact(contact5);
                    addressBook.AddContact(contact6);
                }
            }
        }

        // Add new address book 
        public void AddNewAddressBook()
        {
            Console.Write("Enter new Address Book name: ");
            string newAddressBookName = Console.ReadLine();

            if (addressBooks.Exists(ab => ab.AddressBookName == newAddressBookName))
            {
                Console.WriteLine("An address book with the name '{0}' already exists.", newAddressBookName);
            }
            else
            {
                var newAddressBook = new AddressBooks(newAddressBookName);
                addressBooks.Add(newAddressBook);
                Console.WriteLine("A new address book with the name '{0}' has been created.", newAddressBookName);
            }
        }

        // Display all address books
        public void DisplayAddressBook()
        {
            Console.WriteLine("Address Book Name: ");
            foreach (var books in addressBooks)
            {
                Console.WriteLine(books.AddressBookName);
            }
        }

        // Add new contact in existing address book
        public void AddContact()
        {
            Console.WriteLine("Enter existing address book name: ");
            string addrBook = Console.ReadLine();

            var addressBook = addressBooks.Find(ab => ab.AddressBookName == addrBook);

            if (addressBook != null)
            {
                Console.Write("Enter First Name: ");
                string FirstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string LastName = Console.ReadLine();
                Console.Write("Enter Email: ");
                string Email = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                string PhoneNumber = Console.ReadLine();
                Console.Write("Enter Address: ");
                string Address = Console.ReadLine();
                Console.Write("Enter City: ");
                string City = Console.ReadLine();
                Console.Write("Enter State: ");
                string State = Console.ReadLine();
                Console.Write("Enter Zip Code: ");
                string ZipCode = Console.ReadLine();

                Contact contact = new Contact(FirstName, LastName, Email, PhoneNumber, Address, City, State, ZipCode);

                foreach (var address_Book in addressBooks)
                {
                    if (address_Book.AddressBookName == addrBook)
                    {
                        address_Book.AddContact(contact);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} address book not found.", addrBook);
            }

        }

        // Display all contacts in the collection
        public void DisplayContact()
        {
            foreach (var address_Book in addressBooks)
            {
                Console.WriteLine($"Address Book: {address_Book.AddressBookName}");
                foreach (var contact in address_Book.Contacts)
                {
                    Console.WriteLine("\nName: {0} {1}", contact.FirstName, contact.LastName);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Zip Code: " + contact.ZipCode);
                }
                Console.WriteLine();
            }
        }

        // Edit an existing contact
        public void ModifyContactInAddressBook()
        {
            Console.WriteLine("To edit contact, Enter first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("To edit contact, Enter last name: ");
            string lastName = Console.ReadLine();

            string Field = string.Empty, NewValue = string.Empty;

            foreach (var address_Book in addressBooks)
            {
                var contact = address_Book.Contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

                if (contact != null)
                {
                    char input = 'n';

                    while (char.ToLower(input) == 'n')
                    {
                        Console.WriteLine("To Update Contact");
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last Name");
                        Console.WriteLine("3. Email");
                        Console.WriteLine("4. Phone number");
                        Console.WriteLine("5. Address");
                        Console.WriteLine("6. City");
                        Console.WriteLine("7. State");
                        Console.WriteLine("8. Zip Code");
                        Console.Write("==> ");
                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter New First Name: ");
                                NewValue = Console.ReadLine();
                                Field = "FirstName";
                                break;
                            case 2:
                                Console.WriteLine("Enter New Last Name: ");
                                NewValue = Console.ReadLine();
                                Field = "LastName";
                                break;
                            case 3:
                                Console.WriteLine("Enter New Email: ");
                                NewValue = Console.ReadLine();
                                Field = "Email";
                                break;
                            case 4:
                                Console.WriteLine("Enter New Phone Number: ");
                                NewValue = Console.ReadLine();
                                Field = "PhoneNumber";
                                break;
                            case 5:
                                Console.WriteLine("Enter New Address: ");
                                NewValue = Console.ReadLine();
                                Field = "Address";
                                break;
                            case 6:
                                Console.WriteLine("Enter New City: ");
                                NewValue = Console.ReadLine();
                                Field = "City";
                                break;
                            case 7:
                                Console.WriteLine("Enter New State: ");
                                NewValue = Console.ReadLine();
                                Field = "State";
                                break;
                            case 8:
                                Console.WriteLine("Enter New Zip Code: ");
                                NewValue = Console.ReadLine();
                                Field = "ZipCode";
                                break;
                            default:
                                Console.WriteLine("Select valid option.");
                                break;
                        }

                        foreach (var addressBook in addressBooks)
                        {
                            addressBook.ModifyContact(firstName, lastName, Field, NewValue);
                        }

                        Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                        input = Convert.ToChar(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("Contact {0} {1} not found in '{2}' address book.", firstName, lastName, address_Book.AddressBookName);
                }
            }

        }

        // Delete an existing contact
        public void DeleteContactFromAddressBook()
        {
            Console.WriteLine("To delete contact, Enter first name: ");
            string FirstName = Console.ReadLine();

            Console.WriteLine("To delete contact, Enter last name: ");
            string LastName = Console.ReadLine();

            foreach (var address_Book in addressBooks)
            {
                var contact = address_Book.Contacts.FirstOrDefault(c => c.FirstName.Equals(FirstName) && c.LastName.Equals(LastName));

                if (contact != null)
                {
                    Console.WriteLine("\nDo you want to delete the contact? (y/N)");
                    char input = 'y';
                    input = Convert.ToChar(Console.ReadLine());

                    if (char.ToLower(input) == 'y')
                    {
                        foreach (var addressBook in addressBooks)
                        {
                            addressBook.DeleteContact(FirstName, LastName);
                        }
                        Console.WriteLine("Contact deleted successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Contact {0} {1} not found in '{2}' address book.", FirstName, LastName, address_Book.AddressBookName);
                }
            }
        }

        public void FindContactByCityOrStateInAddressBook()
        {
            char input = 'n';

            while (char.ToLower(input) == 'n')
            {
                Console.WriteLine("Select an Option: ");
                Console.WriteLine("1. Find by City");
                Console.WriteLine("2. Find by State");
                Console.Write("=> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the city name of the contact to search for:");
                        var city = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.FindContactsByCity(city);

                            if (contacts.Count == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the city '{city}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Contacts found in the '{addressBook.AddressBookName}' address book for the city '{city}':");
                                foreach (var contact in contacts)
                                {
                                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                                }
                                Console.WriteLine();
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter the state name of the contact to search for:");
                        var state = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.FindContactsByState(state);

                            if (contacts.Count == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the city '{state}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Contacts found in the '{addressBook.AddressBookName}' address book for the city '{state}':");
                                foreach (var contact in contacts)
                                {
                                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                                }
                                Console.WriteLine();
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
                Console.Write("Do you want to exit? (y = YES,n = NO): ");
                input = Convert.ToChar(Console.ReadLine());
            }
        }

        public void ViewContactByCityOrStateInAddressBook()
        {
            char input = 'n';

            while (char.ToLower(input) == 'n')
            {
                Console.WriteLine("Select an Option: ");
                Console.WriteLine("1. View by City");
                Console.WriteLine("2. View by State");
                Console.Write("=> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the city name of the contact to search for:");
                        var city = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.FindContactsByCity(city);

                            if (contacts.Count == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the city '{city}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Contacts found in the '{addressBook.AddressBookName}' address book for the city '{city}':\n");
                                foreach (var contact in contacts)
                                {
                                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                                    Console.WriteLine("Email: " + contact.Email);
                                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                                    Console.WriteLine("Address: " + contact.Address);
                                    Console.WriteLine("City: " + contact.City);
                                    Console.WriteLine("State: " + contact.State);
                                    Console.WriteLine("Postal Code: " + contact.ZipCode);
                                    Console.WriteLine();
                                }
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter the state name of the contact to search for:");
                        var state = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.FindContactsByState(state);

                            if (contacts.Count == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the city '{state}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Contacts found in the '{addressBook.AddressBookName}' address book for the city '{state}':\n");
                                foreach (var contact in contacts)
                                {
                                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                                    Console.WriteLine("Email: " + contact.Email);
                                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                                    Console.WriteLine("Address: " + contact.Address);
                                    Console.WriteLine("City: " + contact.City);
                                    Console.WriteLine("State: " + contact.State);
                                    Console.WriteLine("Postal Code: " + contact.ZipCode);
                                    Console.WriteLine();
                                }
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
                Console.Write("Do you want to exit? (y = YES,n = NO): ");
                input = Convert.ToChar(Console.ReadLine());
            }
        }

        public void CountContactByCityOrState()
        {
            char input = 'n';

            while (char.ToLower(input) == 'n')
            {
                Console.WriteLine("Select an Option: ");
                Console.WriteLine("1. Count by City");
                Console.WriteLine("2. Count by State");
                Console.Write("=> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the city name of the contact to count for:");
                        var city = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.CountContactsByCity(city);

                            if (contacts == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the city '{city}'.");
                            }
                            else
                            {
                                var count = addressBook.CountContactsByCity(city);
                                Console.WriteLine($"There are {count} contacts in the '{addressBook.AddressBookName}' address book for the city '{city}'.");
                            }
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter the state name of the contact to search for:");
                        var state = Console.ReadLine();

                        foreach (var addressBook in addressBooks)
                        {
                            var contacts = addressBook.CountContactsByState(state);

                            if (contacts == 0)
                            {
                                Console.WriteLine($"No contacts were found in the '{addressBook.AddressBookName}' address book for the state '{state}'.");
                            }
                            else
                            {
                                var count = addressBook.CountContactsByState(state);
                                Console.WriteLine($"There are {count} contacts in the '{addressBook.AddressBookName}' address book for the state '{state}'.");
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
                Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                input = Convert.ToChar(Console.ReadLine());
            }
        }

        public void SortContactsByNameInAscOrder()
        {
            foreach (var addressBook in addressBooks)
            {
                addressBook.SortContactsByFirstName();

                Console.WriteLine("Sorting all contacts in {0} addressbook by First Name:\n", addressBook.AddressBookName);
                foreach (var contact in addressBook.Contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Postal Code: " + contact.ZipCode);
                    Console.WriteLine();
                }
            }
        }

    }
}

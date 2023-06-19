
namespace Address_Book_System
{
    internal class AddressBookController
    {
        List<AddressBooks> addressBooks = new List<AddressBooks>();

        List<Contact> contactsList = new List<Contact>();

        // Add new address book 
        public void AddNewAddressBook()
        {
            AddressBooks book = new AddressBooks();

            Console.Write("Enter new Address Book name: ");
            book.AddressBookName = Console.ReadLine();

            if (!addressBooks.Exists(p => p.AddressBookName == book.AddressBookName))
            {
                addressBooks.Add(book);
            }
            else
            {
                Console.WriteLine(book.AddressBookName + " is already exists in the collection.");
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
            string addressB = Console.ReadLine();

            foreach (var addrBook in addressBooks)
            {
                if (addrBook.AddressBookName == addressB)
                {
                    Contact contact = new Contact();

                    Console.Write("Enter firstname: ");
                    contact.FirstName = Console.ReadLine();
                    Console.Write("Enter lastname: ");
                    contact.LastName = Console.ReadLine();
                    Console.Write("Enter email: ");
                    contact.Email = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Enter address: ");
                    contact.Address = Console.ReadLine();
                    Console.Write("Enter city: ");
                    contact.City = Console.ReadLine();
                    Console.Write("Enter state: ");
                    contact.State = Console.ReadLine();
                    Console.Write("Enter postalcode: ");
                    contact.ZipCode = Convert.ToInt32(Console.ReadLine());

                    if (!contactsList.Exists(
                        p => p.FirstName == contact.FirstName && p.LastName == contact.LastName &&
                        p.Email == contact.Email && p.PhoneNumber == contact.PhoneNumber &&
                        p.Address == contact.Address && p.City == contact.City &&
                        p.State == contact.State && p.ZipCode == contact.ZipCode))
                    {
                        contactsList.Add(contact);
                    }
                    else
                    {
                        Console.WriteLine("The contact details are already exists in the collection.");
                    }
                }
            }
        }

        // Display all contacts in the collection
        public void DisplayContact()
        {
            if (contactsList.Count == 0)
            {
                Console.WriteLine("The address book does not have any contacts.");
            }
            else
            {
                foreach (Contact contact in contactsList)
                {
                    Console.WriteLine("\nName: {0} {1}", contact.FirstName, contact.LastName);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Postal Code: " + contact.ZipCode);
                }
            }
        }

        public void EditExistingContact()
        {
            Console.WriteLine("To edit contact, Enter first name: ");
            string name = Console.ReadLine();

            foreach (Contact contact in contactsList)
            {
                if (contactsList.Contains(contact))
                {
                    if (contact.FirstName.Equals(name))
                    {
                        char input = 'y';

                        while (char.ToLower(input) == 'y')
                        {
                            Console.WriteLine("To Update Contact");
                            Console.WriteLine("1. Email");
                            Console.WriteLine("2. Phone number");
                            Console.WriteLine("3. Address");
                            Console.WriteLine("4. City");
                            Console.WriteLine("5. State");
                            Console.WriteLine("6. Postal Code");
                            Console.Write("==>");
                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Enter new email: ");
                                    string email = Console.ReadLine();
                                    contact.Email = email;
                                    break;
                                case 2:
                                    Console.WriteLine("Enter new phone number: ");
                                    long phone = Convert.ToInt64(Console.ReadLine());
                                    contact.PhoneNumber = phone;
                                    break;
                                case 3:
                                    Console.WriteLine("Enter new address: ");
                                    string address = Console.ReadLine();
                                    contact.Address = address;
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new city: ");
                                    string city = Console.ReadLine();
                                    contact.City = city;
                                    break;
                                case 5:
                                    Console.WriteLine("Enter new state: ");
                                    string state = Console.ReadLine();
                                    contact.State = state;
                                    break;
                                case 6:
                                    Console.WriteLine("Enter new postal code: ");
                                    long pincode = Convert.ToInt32(Console.ReadLine());
                                    contact.ZipCode = pincode;
                                    break;
                            }
                            Console.Write("Do you want to change anything else? (y = YES,n = NO): ");
                            input = Convert.ToChar(Console.ReadLine());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Name does not exists.");
                    }
                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("To delete contact, Enter first name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Do you want to delete the contact? (y/N)");
            char input = 'y';
            input = Convert.ToChar(Console.ReadLine());

            if (char.ToLower(input) == 'y')
            {
                foreach (var contact in contactsList)
                {
                    if (contact.FirstName == name)
                    {
                        contactsList.Remove(contact);
                        Console.WriteLine("Contact deleted successfully");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Contact name not found ");
                    }
                }
            }

        }

        // Search contact details by City name
        public void SearchByCity()
        {
            Console.WriteLine("Enter name of the city: ");
            string city = Console.ReadLine();

            foreach (Contact contact in contactsList.FindAll(c => c.City.Equals(city)))
            {
                Console.WriteLine("\nName: {0} {1}", contact.FirstName, contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Postal Code: " + contact.ZipCode);
            }
        }

        // Search contact details by State name
        public void SearchByState()
        {
            Console.WriteLine("Enter name of the state: ");
            string state = Console.ReadLine();

            foreach (Contact contact in contactsList.FindAll(c => c.State.Equals(state)))
            {
                Console.WriteLine("\nName: {0} {1}", contact.FirstName, contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Postal Code: " + contact.ZipCode);
            }
        }

    }
}

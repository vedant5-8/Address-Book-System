
namespace Address_Book_System
{
    internal class AddressBook
    {

        List<Contact> contactsList = new List<Contact>();


        public void AddContact()
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

            contactsList.Add(contact);

        }

        public void DisplayContact()
        {
            foreach (Contact contact in contactsList)
            {
                Console.WriteLine("Name: {0} {1}", contact.FirstName, contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Postal Code: " + contact.ZipCode);
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

                        while(char.ToLower(input) == 'y')
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

    }
}

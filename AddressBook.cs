
namespace Address_Book_System
{
    internal class AddressBook
    {

        Contact contact = new Contact();
        List<Contact> contactsList = new List<Contact>();


        public void AddContact()
        {
            Console.WriteLine();
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

            foreach (var contact in contactsList)
            {
                if (contactsList.Contains(contact))
                {
                    if (contact.FirstName.Equals(name))
                    {
                        char input = 'y';

                        while(Char.ToLower(input) == 'y')
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
    }
}

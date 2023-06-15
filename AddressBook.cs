using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class AddressBook
    {
        List<Contact> con = new List<Contact>();

        public void AddContact()
        {
            Contact contact = new Contact();

            Console.WriteLine("Enter firstname: ");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter lastname: ");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter phone number: ");
            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter address: ");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter state: ");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter postalcode: ");
            contact.PostalCode = Convert.ToInt32(Console.ReadLine());

            con.Add(contact);

        }

        public void DisplayContact()
        {
            foreach (Contact contact in con)
            {
                Console.WriteLine("First Name: " + contact.FirstName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Postal Code: " + contact.PostalCode);
                Console.WriteLine();
            }
        }

        public void UpdateContact()
        {
            Console.WriteLine("To update contact, Enter first name: ");
            string name = Console.ReadLine();

            foreach (var data in con)
            {
                if (con.Contains(data))
                {
                    if (data.FirstName == name)
                    {
                        Console.WriteLine("Name Exists.");

                        Console.WriteLine("To Update Contact");
                        Console.WriteLine("1. Last Name");
                        Console.WriteLine("2. Email");
                        Console.WriteLine("3. Phone number");
                        Console.WriteLine("4. Address");
                        Console.WriteLine("5. City");
                        Console.WriteLine("6. State");
                        Console.WriteLine("7. Postal Code");
                        Console.Write("==>");
                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter new Lastname: ");
                                string lastName = Console.ReadLine();
                                data.LastName = lastName;
                                break;
                            case 2: 
                                Console.WriteLine("Enter new email: ");
                                string email = Console.ReadLine();
                                data.Email = email;
                                break;
                            case 3:
                                Console.WriteLine("Enter new phone number: ");
                                long phone = Convert.ToInt64(Console.ReadLine());
                                data.PhoneNumber = phone;
                                break;
                            case 4:
                                Console.WriteLine("Enter new address: ");
                                string address = Console.ReadLine();
                                data.Address = address;
                                break;
                            case 5:
                                Console.WriteLine("Enter new city: ");
                                string city = Console.ReadLine();
                                data.City = city;
                                break;
                            case 6:
                                Console.WriteLine("Enter new state: ");
                                string state = Console.ReadLine();
                                data.State = state;
                                break;
                            case 7:
                                Console.WriteLine("Enter new postal code: ");
                                long pincode = Convert.ToInt32(Console.ReadLine());
                                data.PostalCode = pincode;
                                break;
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

            var itemToRemove = con.Single(c => c.FirstName == name);
            con.Remove(itemToRemove);

        }

    }
}

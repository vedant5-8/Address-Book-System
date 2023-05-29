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
            }
        }
    }
}

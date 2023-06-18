
namespace Address_Book_System
{
    internal class AddressBook
    {

        Contact contact = new Contact();

        public void AddContact()
        {
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
        }

        public void DisplayContact()
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
}

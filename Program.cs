
namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("----Welcome to Address Book System----");
            Console.ResetColor();

            AddressBookController controller = new AddressBookController();

            while (true)
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. Add New Address Book");
                Console.WriteLine("2. Add New Contact in Existing Address Book");
                Console.WriteLine("3. Display all contacts");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Display Address Book");
                Console.WriteLine("7. Search contancts by City");
                Console.WriteLine("0. Exit");
                Console.Write("=> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        controller.AddNewAddressBook();
                        break;
                    case 2:
                        controller.AddContact();
                        break;
                    case 3:
                        controller.DisplayContact();
                        break;
                    case 4:
                        controller.EditExistingContact();
                        break;
                    case 5:
                        controller.DeleteContact();
                        break;
                    case 6:
                        controller.DisplayAddressBook();
                        break;
                    case 7:
                        controller.SearchByCity();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
            }
        }
    }
}
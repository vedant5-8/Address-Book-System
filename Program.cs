
namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("----Welcome to Address Book System----");
            Console.ResetColor();

            AddressBook book = new AddressBook();

            while (true)
            {
                Console.WriteLine("\nSelect an option: ");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("0. Exit");
                Console.Write("=> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        book.AddContact();
                        break;
                    case 2:
                        book.DisplayContact();
                        break;
                    case 3:
                        book.EditExistingContact();
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
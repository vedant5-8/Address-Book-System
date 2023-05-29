using System;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Welcome to Address Book System----");

            AddressBook book = new AddressBook();

            while (true)
            {
                Console.WriteLine("Enter an option: ");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contact");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
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
                    default:
                        Console.WriteLine("Enter valid option.");
                        break;
                }
            }

        }
    }
}
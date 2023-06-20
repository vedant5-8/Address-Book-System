
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
                Console.WriteLine("7. Search contacts by City or State");
                Console.WriteLine("8. View contacts by City or State");
                Console.WriteLine("9. Count contacts by City or State");
                Console.WriteLine("10. Sort contacts by First Name");
                Console.WriteLine("11. Sort contacts by City, State or Zip Code");
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
                        char input = 'n';
                        while (char.ToLower(input) == 'n')
                        {
                            Console.WriteLine("\nSelect an option: ");
                            Console.WriteLine("1. Search by city.");
                            Console.WriteLine("2. Search by state.");
                            Console.Write("=> ");
                            option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    controller.SearchByCity();
                                    break;
                                case 2:
                                    controller.SearchByState();
                                    break;
                                default:
                                    Console.WriteLine("Enter valid option.");
                                    break;
                            }
                            Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                            input = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    case 8:
                        char input1 = 'n';
                        while (char.ToLower(input1) == 'n')
                        {
                            Console.WriteLine("\nSelect an option: ");
                            Console.WriteLine("1. View by city.");
                            Console.WriteLine("2. View by state.");
                            Console.Write("=> ");
                            option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    controller.ViewByCity();
                                    break;
                                case 2:
                                    controller.ViewByState();
                                    break;
                                default:
                                    Console.WriteLine("Enter valid option.");
                                    break;
                            }
                            Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                            input1 = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    case 9:
                        char input2 = 'n';
                        while (char.ToLower(input2) == 'n')
                        {
                            Console.WriteLine("\nSelect an option: ");
                            Console.WriteLine("1. Count by city.");
                            Console.WriteLine("2. Count by state.");
                            Console.Write("=> ");
                            option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    controller.CountByCity();
                                    break;
                                case 2:
                                    controller.CountByState();
                                    break;
                                default:
                                    Console.WriteLine("Enter valid option.");
                                    break;
                            }
                            Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                            input2 = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    case 10:
                        controller.SortContactsByName();
                        break;
                    case 11:
                        char input3 = 'n';
                        while (char.ToLower(input3) == 'n')
                        {
                            Console.WriteLine("\nSelect an option: ");
                            Console.WriteLine("1. Sort by city.");
                            Console.WriteLine("2. Sort by state.");
                            Console.WriteLine("3. Sort by zip code");
                            Console.Write("=> ");
                            option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    controller.SortContactsByCity();
                                    break;
                                case 2:
                                    controller.SortContactsByState();
                                    break;
                                case 3: 
                                    controller.SortContactsByZipCode();
                                    break;
                                default:
                                    Console.WriteLine("Enter valid option.");
                                    break;
                            }
                            Console.Write("\nDo you want to exit? (y = YES,n = NO): ");
                            input3 = Convert.ToChar(Console.ReadLine());
                        }
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
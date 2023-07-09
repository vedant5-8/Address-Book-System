
using static System.Net.Mime.MediaTypeNames;
using System.Net;

namespace Address_Book_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("----Welcome to Address Book System----");
            Console.ResetColor();

            int option;

            Console.WriteLine("\nSelect an option: ");
            Console.WriteLine("1. Manage Address Book and Contact Details in List Collection.");
            Console.WriteLine("2. Manage Address Book and Contact Details in MS SQL Server");
            Console.WriteLine("0. Exit");
            Console.Write("==> ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddressBookController controller = new AddressBookController();

                    controller.ExistingAddressBook();
                    controller.ExistingContacts();

                    while (true)
                    {
                        Console.WriteLine("\nSelect an option: ");
                        Console.WriteLine("1. Add New Address Book");
                        Console.WriteLine("2. Add New Contact in Existing Address Book");
                        Console.WriteLine("3. Display all contacts");
                        Console.WriteLine("4. Display all address books");
                        Console.WriteLine("5. Modify an existing Contact");
                        Console.WriteLine("6. Delete an existing data");
                        Console.WriteLine("7. Find contact details by City or State");
                        Console.WriteLine("8. View contact details by City or State");
                        Console.WriteLine("9. Count contact details by City or State");
                        Console.WriteLine("10. Sort contacts by Name in Ascending order");
                        Console.WriteLine("11. Sort contacts by City or State or Zip Code");
                        Console.WriteLine("12.Write and Read Address Book and Contacts details to TEXT file");
                        Console.WriteLine("13. Write and Read Address Book and Contacts details to CSV file");
                        Console.WriteLine("14. Write and Read Address Book and Contacts details to JSON file");
                        Console.WriteLine("0. Exit");
                        Console.Write("=> ");
                        option = Convert.ToInt32(Console.ReadLine());

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
                                controller.DisplayAddressBook();
                                break;
                            case 5:
                                controller.ModifyContactInAddressBook();
                                break;
                            case 6:
                                controller.DeleteContactFromAddressBook();
                                break;
                            case 7:
                                controller.FindContactByCityOrStateInAddressBook();
                                break;
                            case 8:
                                controller.ViewContactByCityOrStateInAddressBook();
                                break;
                            case 9:
                                controller.CountContactByCityOrState();
                                break;
                            case 10:
                                controller.SortContactsByNameInAscOrder();
                                break;
                            case 11:
                                controller.SortContactByCityOrStateOrZipCode();
                                break;
                            case 12:
                                controller.WriteToFileUsingFileIO();
                                controller.ReadFromFileUsingFileIO();
                                break;
                            case 13:
                                controller.WriteToCSVFileUsingCSVHelper();
                                controller.ReadFromCSVFileUsingCSVHelper();
                                break;
                            case 14:
                                controller.WriteToJSONFileUsingNewtonsoftJson();
                                controller.ReadFromJSONFileUsingNewtonsoftJson();
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter valid option.");
                                break;
                        }
                    }

                case 2:
                    AddressBookDatabaseController databaseController = new AddressBookDatabaseController();

                    /* Create database in MS SQL Server */

                    // databaseController.CreateDatabase();

                    /* Create Address Book table in Database */

                    // databaseController.CreateTable_Address_Books();

                    /* Create Contacts table in Database */

                    // databaseController.CreateTable_Contacts();

                    while (true)
                    {
                        Console.WriteLine("\nSelect an option: ");
                        Console.WriteLine("1. Insert new address book in Address Book table.");
                        Console.WriteLine("0. Exit");
                        Console.Write("=> ");
                        option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                databaseController.InsertNewAddressBook();
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter valid option.");
                                break;
                        }
                    }

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
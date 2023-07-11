
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
            Console.WriteLine("2. Manage Address Book and Contact Details in MS SQL Server.");
            Console.WriteLine("3. Manage Address Book and Contact Details using Multithreading.");
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

                    /* Alter table to add Date_Added Column to store current date when a new record is added to the table. */

                    // databaseController.Alter_Contacts_Table();

                    while (true)
                    {
                        Console.WriteLine("\nSelect an option: ");
                        Console.WriteLine("1. Insert new address book in Address Book table.");
                        Console.WriteLine("2. Insert new Contact Details in Contacts table.");
                        Console.WriteLine("3. Update existing contact details.");
                        Console.WriteLine("4. Delete a existing contact.");
                        Console.WriteLine("5. Retrieve all Address Books");
                        Console.WriteLine("6. Retrieve all contact details.");
                        Console.WriteLine("7. Retrive Records By Range Of Date");
                        Console.WriteLine("8. Retrive All Records By City");
                        Console.WriteLine("9. Retrive All Records By State");
                        Console.WriteLine("10. Insert one contact in multiple address books");
                        Console.WriteLine("11. Count records by City");
                        Console.WriteLine("12. Count records by State");
                        Console.WriteLine("13. Retrive All Records Order By Name");
                        Console.WriteLine("14. Retrive All Contacts By Address Book Name.");
                        Console.WriteLine("0. Exit");
                        Console.Write("=> ");
                        option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                databaseController.InsertNewAddressBook();
                                break;
                            case 2:
                                databaseController.InsertNewContact();
                                break;
                            case 3:
                                databaseController.UpdateRecord();
                                break;
                            case 4:
                                databaseController.DeleteRecord();
                                break;
                            case 5:
                                databaseController.RetriveAllAddressBookName(); 
                                break;
                            case 6:
                                databaseController.RetriveAllRecords();
                                break;
                            case 7:
                                databaseController.RetriveRecordsByRangeOfDate();
                                break;
                            case 8:
                                databaseController.RetriveAllRecordsByCity();
                                break;
                            case 9:
                                databaseController.RetriveAllRecordsByState();
                                break;
                            case 10:
                                databaseController.InsertContactInMultipleAddressBook();
                                break;
                            case 11:
                                databaseController.CountContactsByCity();
                                break;
                            case 12:
                                databaseController.CountContactsByState();
                                break;
                            case 13:
                                databaseController.RetriveAllRecordsOrderByName();
                                break;
                            case 14:
                                databaseController.RetriveAllContactsByAddressBookName();
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter valid option.");
                                break;
                        }
                    }
                case 3:
                    ThreadController threadController = new ThreadController();

                    List<AddressBooksModel> addressBooksList = new List<AddressBooksModel>();
                    List<ContactModel> contactList = new List<ContactModel>();

                    // Add multiple AddressBooks and Contacts to the lists
                    addressBooksList.Add(new AddressBooksModel { AddressBookName = "Book 1" });
                    addressBooksList.Add(new AddressBooksModel { AddressBookName = "Book 2" });

                    contactList.Add(new ContactModel { AddressBookName = "Book 1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St", City = "Mumbai", State = "Maharashtra", ZipCode = "400001" });
                    contactList.Add(new ContactModel { AddressBookName = "Book 2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "0987654321", Address = "456 Main St", City = "Mumbai", State = "Maharashtra", ZipCode = "400001" });

                    foreach (AddressBooksModel addressBooksModel in addressBooksList)
                    {
                        Thread thread1 = new Thread(() => threadController.InsertNewAddressBook(addressBooksModel));
                        thread1.Start();
                    }

                    foreach (ContactModel contactModel in contactList)
                    {
                        Thread thread2 = new Thread(() => threadController.InsertNewContact(addressBooksList[0], contactModel));
                        thread2.Start();
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
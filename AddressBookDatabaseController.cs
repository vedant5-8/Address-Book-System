using System.Data.SqlClient;

namespace Address_Book_System
{
    public class AddressBookDatabaseController
    {
        // UC1: Create database on MS SQL Server
        public void CreateDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=master;integrated security=true");
                con.Open();

                string Query = "CREATE DATABASE Address_Book_Service_C_Sharp;";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Database Created Successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC2: Create Address Book table in database
        public void CreateTable_Address_Books()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                string Query = "CREATE TABLE Address_Books(AddressBook_Name VARCHAR(255) PRIMARY KEY);";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC3: Create Contacts table in database
        public void CreateTable_Contacts()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                string Query = "CREATE TABLE Contacts(" +
                    "ID INT PRIMARY KEY IDENTITY(1,1)," +
                    "AddressBook_Name VARCHAR(255) FOREIGN KEY REFERENCES Address_Books(AddressBook_Name)," +
                    "First_Name VARCHAR(255)," +
                    "Last_Name VARCHAR(255)," +
                    "Email VARCHAR(255)," +
                    "Phone_Number VARCHAR(255)," +
                    "Address VARCHAR(255)," +
                    "City VARCHAR(255)," +
                    "State VARCHAR(255)," +
                    "Zip_Code VARCHAR(255)," +
                    ");";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC4: Insert new address books in Address Book table

        public void InsertNewAddressBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                AddressBooks addressBooksModel = new AddressBooks();

                Console.Write("Enter New Address Book Name: ");
                addressBooksModel.AddressBookName = Console.ReadLine();

                string Query = "INSERT INTO Address_Books VALUES (@AddressBookName);";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@AddressBookName", addressBooksModel.AddressBookName);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("{0} row affected.", rowsAffected);
                Console.WriteLine("Record Inserted Successfully.");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC5: Insert new Contact details in Contacts table
        public void InsertNewContact()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                AddressBooks addressBooksModel = new AddressBooks();
                Contact contactModel = new Contact();

                Console.Write("Enter the name of the address book to which you want to add a new contact: ");
                addressBooksModel.AddressBookName = Console.ReadLine();

                Console.WriteLine("Enter contact Details: \n");

                Console.WriteLine("Enter Your First Name");
                contactModel.FirstName = Console.ReadLine();

                Console.WriteLine("Enter Your Last Name: ");
                contactModel.LastName = Console.ReadLine();

                Console.WriteLine("Enter Your Email: ");
                contactModel.Email = Console.ReadLine();

                Console.WriteLine("Enter Your Phone Number: ");
                contactModel.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter Your Address: ");
                contactModel.Address = Console.ReadLine();

                Console.WriteLine("Enter Your City: ");
                contactModel.City = Console.ReadLine();

                Console.WriteLine("Enter Your State: ");
                contactModel.State = Console.ReadLine();

                Console.WriteLine("Enter Your Zip Code: ");
                contactModel.ZipCode = Console.ReadLine();

                string Query = "INSERT INTO Contacts VALUES (@AddressBookName, @FirstName, @LastName, @Email, @PhoneNumber, @Address, @City, @State, @ZipCode);";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@AddressBookName", addressBooksModel.AddressBookName);
                cmd.Parameters.AddWithValue("@FirstName", contactModel.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contactModel.LastName);
                cmd.Parameters.AddWithValue("@Email", contactModel.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", contactModel.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", contactModel.Address);
                cmd.Parameters.AddWithValue("@City", contactModel.City);
                cmd.Parameters.AddWithValue("@State", contactModel.State);
                cmd.Parameters.AddWithValue("@ZipCode", contactModel.ZipCode);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("{0} rows are inserted.", rowsAffected);
                Console.WriteLine("Record Inserted Successfully.");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

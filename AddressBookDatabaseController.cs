﻿using System.Data.SqlClient;

namespace Address_Book_System
{
    public class AddressBookDatabaseController
    {

        AddressBooks addressBooksModel = new AddressBooks();

        Contact contactModel = new Contact();

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

        // UC18: Alter table to add Date_Added Column to store current date when a new record is added to the table.

        public void Alter_Contacts_Table()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                string Query = "ALTER TABLE Contacts ADD Date_Added DATE DEFAULT GETDATE();";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Column Added Successfully.");
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

                string Query = "INSERT INTO Contacts " +
                    "(AddressBook_Name, First_Name, Last_Name, Email, Phone_Number, Address, City, State, Zip_Code) " +
                    "VALUES (@AddressBookName, @FirstName, @LastName, @Email, @PhoneNumber, @Address, @City, @State, @ZipCode);";

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

        // UC6: Update existing contact details

        public void UpdateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("To Edit Records");
                Console.Write("Enter Your First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Your Last Name: ");
                string lastName = Console.ReadLine();

                while (true)
                {
                    string Query = String.Empty;
                    Console.WriteLine("\nSelect an option: ");
                    Console.WriteLine("1. Update Address Book Name.");
                    Console.WriteLine("2. Update First Name.");
                    Console.WriteLine("3. Update Last Name.");
                    Console.WriteLine("4. Update Email.");
                    Console.WriteLine("5. Update Phone Number.");
                    Console.WriteLine("6. Update Address.");
                    Console.WriteLine("7. Update City.");
                    Console.WriteLine("8. Update State.");
                    Console.WriteLine("9. Update Zip Code.");
                    Console.WriteLine("0. Exit");
                    Console.Write("==> ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter New Address Book Name: ");
                            addressBooksModel.AddressBookName = Console.ReadLine();
                            Query = "UPDATE Contacts SET AddressBook_Name = @AddressBookName WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 2:
                            Console.Write("Enter New First Name: ");
                            contactModel.FirstName = Console.ReadLine();
                            Query = "UPDATE Contacts SET First_Name = @FirstName WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 3:
                            Console.Write("Enter New Last Name: ");
                            contactModel.LastName = Console.ReadLine();
                            Query = "UPDATE Contacts SET Last_Name = @LastName WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 4:
                            Console.Write("Enter New Email: ");
                            contactModel.Email = Console.ReadLine();
                            Query = "UPDATE Contacts SET Email = @Email WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 5:
                            Console.Write("Enter New Phone Number: ");
                            contactModel.PhoneNumber = Console.ReadLine();
                            Query = "UPDATE Contacts SET Phone_Number = @PhoneNumber WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 6:
                            Console.Write("Enter New Address: ");
                            contactModel.Address = Console.ReadLine();
                            Query = "UPDATE Contacts SET Address = @Address WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 7:
                            Console.Write("Enter New City: ");
                            contactModel.City = Console.ReadLine();
                            Query = "UPDATE Contacts SET City = @City WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 8:
                            Console.Write("Enter New State: ");
                            contactModel.State = Console.ReadLine();
                            Query = "UPDATE Contacts SET State = @State WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 9:
                            Console.Write("Enter New Zip Code: ");
                            contactModel.ZipCode = Console.ReadLine();
                            Query = "UPDATE Contacts SET Zip_Code = @ZipCode WHERE First_Name = @firstName AND Last_Name = @lastName;";
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nEnter valid option.");
                            break;
                    }

                    SqlCommand cmd = new SqlCommand(Query, con);

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);

                    switch (option)
                    {
                        case 1:
                            cmd.Parameters.AddWithValue("@AddressBookName", addressBooksModel.AddressBookName);
                            break;
                        case 2:
                            cmd.Parameters.AddWithValue("@FirstName", contactModel.FirstName);
                            break;
                        case 3:
                            cmd.Parameters.AddWithValue("@LastName", contactModel.LastName);
                            break;
                        case 4:
                            cmd.Parameters.AddWithValue("@Email", contactModel.Email);
                            break;
                        case 5:
                            cmd.Parameters.AddWithValue("@PhoneNumber", contactModel.PhoneNumber);
                            break;
                        case 6:
                            cmd.Parameters.AddWithValue("@Address", contactModel.Address);
                            break;
                        case 7:
                            cmd.Parameters.AddWithValue("@City", contactModel.City);
                            break;
                        case 8:
                            cmd.Parameters.AddWithValue("@State", contactModel.State);
                            break;
                        case 9:
                            cmd.Parameters.AddWithValue("@ZipCode", contactModel.ZipCode);
                            break;
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("{0} row affected.", rowsAffected);
                    Console.WriteLine("Record Updated Successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC7: Delete a contact detail

        public void DeleteRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("To Edit Records");
                Console.Write("Enter Your First Name: ");
                contactModel.FirstName = Console.ReadLine();

                Console.Write("Enter Your Last Name: ");
                contactModel.LastName = Console.ReadLine();

                string Query = "DELETE FROM Contacts WHERE First_Name = @FirstName AND Last_Name = @LastName;";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@firstName", contactModel.FirstName);
                cmd.Parameters.AddWithValue("@lastName", contactModel.LastName);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("{0} row affected.", rowsAffected);
                Console.WriteLine("Record Deleted Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC8: Retrieve all records

        public void RetriveAllRecords()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();
                string Query = "SELECT * FROM Contacts";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(1);
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Address Book Name: \"" + addressBooksModel.AddressBookName + "\"");
                        Console.ResetColor();
                        Console.WriteLine("Person Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC9: Count Records By City or State
        public void CountContactsByCity()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("Enter City: ");
                contactModel.City = Console.ReadLine();

                string Query = "SELECT COUNT(*) FROM Contacts WHERE City = @City";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@City", contactModel.City);

                int count = (int)cmd.ExecuteScalar();

                Console.WriteLine("Total number of contacts present in {0} city are {1}.", contactModel.City, count);

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CountContactsByState()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("Enter State: ");
                contactModel.State = Console.ReadLine();

                string Query = "SELECT COUNT(*) FROM Contacts WHERE State = @State";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@State", contactModel.State);

                int count = (int)cmd.ExecuteScalar();

                Console.WriteLine("Total number of contacts present in {0} state are {1}.", contactModel.State, count);

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC10: Retrive All Records Order By Name
        public void RetriveAllRecordsOrderByName()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("Enter City: ");
                contactModel.City = Console.ReadLine();

                string Query = "SELECT * FROM Contacts WHERE City = @City ORDER BY First_Name;";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@City", contactModel.City);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nContacts Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(1);
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Address Book Name: \"" + addressBooksModel.AddressBookName + "\"");
                        Console.ResetColor();
                        Console.WriteLine("Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC11: Retrive All Address Book Name

        public void RetriveAllAddressBookName()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                string Query = "SELECT * FROM Address_Books;";

                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");
                    Console.WriteLine("\nAddress Books: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(0);

                        Console.WriteLine(addressBooksModel.AddressBookName);
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Address_Books Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC12: Retrive All Contacts By Address Book Name
        public void RetriveAllContactsByAddressBookName()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("Enter Address Book Name: ");
                addressBooksModel.AddressBookName = Console.ReadLine();

                string Query = "SELECT * FROM Contacts WHERE AddressBook_Name = @AddressBookName;";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@AddressBookName", addressBooksModel.AddressBookName);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Contacts from {0} Address Book: ", addressBooksModel.AddressBookName);

                    while (sqlDataReader.Read())
                    {
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.WriteLine("Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Address_Books Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC13: Count Records By Address Book Name
        public void CountRecordsByAddressBookName()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.WriteLine("Enter Address Book Name: ");
                addressBooksModel.AddressBookName = Console.ReadLine();

                string Query = "SELECT COUNT(*) FROM Contacts c INNER JOIN Address_Books a ON c.AddressBook_Name = a.AddressBook_Name WHERE a.AddressBook_Name = @AddressBookName;";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@AddressBookName", addressBooksModel.AddressBookName);

                int count = (int)cmd.ExecuteScalar();

                Console.WriteLine("Total number of contacts present in {0} address book are {1}.", addressBooksModel.AddressBookName, count);

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC18: Retrive Records By Range Of Date
        public void RetriveRecordsByRangeOfDate()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Contact contactModel = new Contact();

                Console.Write("Enter Staring Date: ");
                DateTime StartingDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("\nEnter Ending Date: ");
                DateTime EndingDate = Convert.ToDateTime(Console.ReadLine());

                string Query = "SELECT * FROM Contacts WHERE Date_Added BETWEEN @StartingDate AND @EndingDate;";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@StartingDate", StartingDate);
                cmd.Parameters.AddWithValue("@EndingDate", EndingDate);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(1);
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Address Book Name: \"" + addressBooksModel.AddressBookName + "\"");
                        Console.ResetColor();
                        Console.WriteLine("Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC19: Retrive All Records By City or State name
        public void RetriveAllRecordsByCity()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Contact contactModel = new Contact();

                Console.WriteLine("Enter City: ");
                contactModel.City = Console.ReadLine();

                string Query = "SELECT * FROM Contacts WHERE City = @City";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@City", contactModel.City);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(1);
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Address Book Name: \"" + addressBooksModel.AddressBookName + "\"");
                        Console.ResetColor();
                        Console.WriteLine("Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RetriveAllRecordsByState()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Contact contactModel = new Contact();

                Console.WriteLine("Enter State: ");
                contactModel.State = Console.ReadLine();

                string Query = "SELECT * FROM Contacts WHERE State = @State";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@State", contactModel.State);

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\nRecords Retrived from Database: ");

                    while (sqlDataReader.Read())
                    {
                        addressBooksModel.AddressBookName = sqlDataReader.GetString(1);
                        contactModel.FirstName = sqlDataReader.GetString(2);
                        contactModel.LastName = sqlDataReader.GetString(3);
                        contactModel.Email = sqlDataReader.GetString(4);
                        contactModel.PhoneNumber = sqlDataReader.GetString(5);
                        contactModel.Address = sqlDataReader.GetString(6);
                        contactModel.City = sqlDataReader.GetString(7);
                        contactModel.State = sqlDataReader.GetString(8);
                        contactModel.ZipCode = sqlDataReader.GetString(9);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Address Book Name: \"" + addressBooksModel.AddressBookName + "\"");
                        Console.ResetColor();
                        Console.WriteLine("Name: {0} {1}", contactModel.FirstName, contactModel.LastName);
                        Console.WriteLine("Email: " + contactModel.Email);
                        Console.WriteLine("Phone Number: " + contactModel.PhoneNumber);
                        Console.WriteLine("Address: " + contactModel.Address);
                        Console.WriteLine("City: " + contactModel.City);
                        Console.WriteLine("State: " + contactModel.State);
                        Console.WriteLine("Zip Code: " + contactModel.ZipCode);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("Record Not Found in Employee_Payroll Table");
                }

                sqlDataReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC20: Insert Contact In Multiple Address Book
        public void InsertContactInMultipleAddressBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

                Console.Write("How many address books do you want to save a contact?\n=> ");
                int n = Convert.ToInt32(Console.ReadLine());

                List<string> AddressBookNames = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter name of address book {0}: ", i + 1);
                    AddressBookNames.Add(Console.ReadLine());
                }

                Console.WriteLine("Enter contact Details: \n");

                Console.WriteLine("Enter Your First Name");
                string First_Name = Console.ReadLine();

                Console.WriteLine("Enter Your Last Name: ");
                string Last_Name = Console.ReadLine();

                Console.WriteLine("Enter Your Email: ");
                string Email = Console.ReadLine();

                Console.WriteLine("Enter Your Phone Number: ");
                string Phone_Number = Console.ReadLine();

                Console.WriteLine("Enter Your Address: ");
                string Address = Console.ReadLine();

                Console.WriteLine("Enter Your City: ");
                string City = Console.ReadLine();

                Console.WriteLine("Enter Your State: ");
                string State = Console.ReadLine();

                Console.WriteLine("Enter Your Zip Code: ");
                string Zip_Code = Console.ReadLine();

                string Query = string.Empty;

                for (int i = 0; i < n; i++)
                {
                    Query += "INSERT INTO Contacts " +
                        "(AddressBook_Name, First_Name, Last_Name, Email, Phone_Number, Address, City, State, Zip_Code) " +
                        "VALUES (@AddressBookName" + i + ", @First_Name, @Last_Name, @Email, @Phone_Number, @Address, @City, @State, @Zip_Code);";
                }

                SqlCommand cmd = new SqlCommand(Query, con);

                for (int i = 0; i < n; i++)
                {
                    cmd.Parameters.AddWithValue("@AddressBookName" + i, AddressBookNames[i]);
                }

                cmd.Parameters.AddWithValue("@First_Name", First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", Last_Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Phone_Number", Phone_Number);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@Zip_Code", Zip_Code);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("{0} rows are inserted.", rowsAffected);
                Console.WriteLine("Record Inserted Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

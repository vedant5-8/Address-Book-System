
using System.Data.SqlClient;

namespace Address_Book_System
{
    public class AddressBooksModel
    {
        public string AddressBookName { get; set; }
        public List<Contact> Contacts { get; set; }

        public AddressBooksModel() { }

        public AddressBooksModel(string addressBookName)
        {
            AddressBookName = addressBookName;
            Contacts = new List<Contact>();
        }
    }
    public class ContactModel
    {
        public string AddressBookName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ContactModel() { }

        public ContactModel(string addressBookName, string firstName, string lastName, string email, string phoneNumber, string address, string city, string state, string zipCode)
        {
            AddressBookName = addressBookName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

    }

    internal class ThreadController
    {
        // Insert new address books in Address Book table
        public void InsertNewAddressBook(AddressBooksModel addressBooksModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

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

        // Insert new Contact details in Contacts table
        public void InsertNewContact(AddressBooksModel addressBooksModel, ContactModel contactModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-4VPJFH9\SQLEXPRESS;initial catalog=Address_Book_Service_C_Sharp;integrated security=true");
                con.Open();

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
    }
}

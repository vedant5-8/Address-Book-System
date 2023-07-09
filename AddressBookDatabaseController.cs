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

    }
}

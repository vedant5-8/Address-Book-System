using CsvHelper;
using Newtonsoft.Json;
using System.Globalization;

namespace Address_Book_System
{
    public class AddressBooks
    {
        public string AddressBookName { get; set; }
        public List<Contact> Contacts { get; set; }

        public AddressBooks(string addressBookName)
        {
            AddressBookName = addressBookName;
            Contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {

            if (Contacts.Any(c => c.FirstName == contact.FirstName && c.LastName == contact.LastName &&
                        c.Email == contact.Email && c.PhoneNumber == contact.PhoneNumber &&
                        c.Address == contact.Address && c.City == contact.City &&
                        c.State == contact.State && c.ZipCode == contact.ZipCode))
            {
                Console.WriteLine($"A contact with the same details already exists in the '{AddressBookName}' address book.");
            }
            else
            {
                Contacts.Add(contact);
                Console.WriteLine($"A new contact has been added to the '{AddressBookName}' address book.");
            }
        }

        public void ModifyContact(string firstName, string lastName, string field, string newValue)
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].FirstName == firstName && Contacts[i].LastName == lastName)
                {
                    switch (field)
                    {
                        case "FirstName":
                            Contacts[i].FirstName = newValue;
                            break;
                        case "LastName":
                            Contacts[i].LastName = newValue;
                            break;
                        case "Email":
                            Contacts[i].Email = newValue;
                            break;
                        case "PhoneNumber":
                            Contacts[i].PhoneNumber = newValue;
                            break;
                        case "Address":
                            Contacts[i].Address = newValue;
                            break;
                        case "City":
                            Contacts[i].City = newValue;
                            break;
                        case "State":
                            Contacts[i].State = newValue;
                            break;
                        case "ZipCode":
                            Contacts[i].City = newValue;
                            break;
                    }
                    break;
                }
            }
        }

        public void DeleteContact(string firstName, string lastName)
        {
            Contacts.RemoveAll(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public List<Contact> FindContactsByCity(string city)
        {
            return Contacts.Where(c => c.City == city).ToList();
        }

        public List<Contact> FindContactsByState(string state)
        {
            return Contacts.Where(c => c.State == state).ToList();
        }

        public int CountContactsByCity(string city)
        {
            return Contacts.Count(c => c.City == city);
        }

        public int CountContactsByState(string state)
        {
            return Contacts.Count(c => c.State == state);
        }

        public void SortContactsByFirstName()
        {
            Contacts = Contacts.OrderBy(c => c.FirstName).ToList();
        }

        public void SortContactsByCity()
        {
            Contacts = Contacts.OrderBy(c => c.City).ToList();
        }

        public void SortContactsByState()
        {
            Contacts = Contacts.OrderBy(c => c.State).ToList();
        }

        public void SortContactsByZipCode()
        {
            Contacts = Contacts.OrderBy(c => c.ZipCode).ToList();
        }

        public static void WriteToTxtFile(List<AddressBooks> addressBooks, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var addressBook in addressBooks)
                {
                    writer.WriteLine("Address Book: " + addressBook.AddressBookName);
                    foreach (var contact in addressBook.Contacts)
                    {
                        writer.WriteLine("\nName: {0} {1}", contact.FirstName, contact.LastName);
                        writer.WriteLine("Email: " + contact.Email);
                        writer.WriteLine("Phone Number: " + contact.PhoneNumber);
                        writer.WriteLine("Address: " + contact.Address);
                        writer.WriteLine("City: " + contact.City);
                        writer.WriteLine("State: " + contact.State);
                        writer.WriteLine("Postal Code: " + contact.ZipCode);
                    }
                    writer.WriteLine();
                }
            }
        }

        public static void ReadFromTxtFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string contacts;
                while ((contacts = reader.ReadLine()) != null)
                {
                    Console.WriteLine(contacts);
                }
            }
        }

        public static void WriteAddressBooksToCsv(List<AddressBooks> addressBooks, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(addressBooks.SelectMany(ab => ab.Contacts.Select(c => new
                {
                    AddressBookName = ab.AddressBookName,
                    c.FirstName,
                    c.LastName,
                    c.Email,
                    c.PhoneNumber,
                    c.Address,
                    c.City,
                    c.State,
                    c.ZipCode,
                })));
            }
        }

        public static void ReadAddressBooksFromCsvFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>().ToList();
                var groupedRecords = records.GroupBy(r => r.AddressBookName);

                foreach (var group in groupedRecords)
                {
                    Console.WriteLine($"Address Book: {group.Key}");
                    foreach (var record in group)
                    {
                        Console.WriteLine($"Name: {record.FirstName} {record.LastName}");
                        Console.WriteLine("Email: " + record.Email);
                        Console.WriteLine("Phone Number: " + record.PhoneNumber);
                        Console.WriteLine("Address: " + record.Address);
                        Console.WriteLine("City: " + record.City);
                        Console.WriteLine("State: " + record.State);
                        Console.WriteLine("Postal Code: " + record.ZipCode);
                        Console.WriteLine();
                    }
                }
            }
        }

    }
}

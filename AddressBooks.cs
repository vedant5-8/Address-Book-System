
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

    }
}

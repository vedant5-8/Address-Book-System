using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Nodes;

namespace Address_Book_System
{
    public class ContactDetails
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class AddressBookJSONController
    {
        RestClient client;

        public void Setup()
        {
            client = new RestClient("http://localhost:3000");
        }

        private RestResponse getContactsList()
        {
            if (client == null)
            {
                Setup();
            }

            RestRequest request = new RestRequest("/Contacts", Method.Get);

            RestResponse response = client.Execute(request);

            return response;
        }

        public void DisplayContacts()
        {
            RestResponse response = getContactsList();

            List<ContactDetails> dataResponse = JsonConvert.DeserializeObject<List<ContactDetails>>(response.Content);

            Console.WriteLine(dataResponse.Count());

            foreach (ContactDetails contact in dataResponse)
            {
                Console.WriteLine("First Name: " + contact.FirstName);
                Console.WriteLine("Last Name: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("City: " + contact.City);
                Console.WriteLine("State: " + contact.State);
                Console.WriteLine("Zip Code: " + contact.ZipCode);
                Console.WriteLine();
            }
        }

        public void AddContact()
        {
            ContactDetails contact = new ContactDetails();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            // Check if a contact with the same first and last name already exists
            RestRequest getRequest = new RestRequest("/Contacts", Method.Get);
            if (client == null)
            {
                Setup();
            }
            RestResponse getResponse = client.Execute(getRequest);
            List<ContactDetails> existingContacts = JsonConvert.DeserializeObject<List<ContactDetails>>(getResponse.Content);
            bool contactExists = existingContacts.Any(c => c.FirstName == contact.FirstName && c.LastName == contact.LastName);

            if (contactExists)
            {
                Console.WriteLine("Contact already exists.");
                return;
            }

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();
            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            contact.ZipCode = Console.ReadLine();

            RestRequest postRequest = new RestRequest("/Contacts", Method.Post);
            JsonObject jObjectBody = new JsonObject();
            jObjectBody.Add("FirstName", contact.FirstName);
            jObjectBody.Add("LastName", contact.LastName);
            jObjectBody.Add("Email", contact.Email);
            jObjectBody.Add("PhoneNumber", contact.PhoneNumber);
            jObjectBody.Add("Address", contact.Address);
            jObjectBody.Add("City", contact.City);
            jObjectBody.Add("State", contact.State);
            jObjectBody.Add("ZipCode", contact.ZipCode);

            postRequest.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            RestResponse postResponse = client.Execute(postRequest);

            ContactDetails dataResponse = JsonConvert.DeserializeObject<ContactDetails>(postResponse.Content);
            Console.WriteLine(postResponse.Content);
        }

        public void UpdateContact()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            // Check if a contact with the same first and last name exists
            RestRequest getRequest = new RestRequest("/Contacts", Method.Get);
            if (client == null)
            {
                Setup();
            }
            RestResponse getResponse = client.Execute(getRequest);
            List<ContactDetails> existingContacts = JsonConvert.DeserializeObject<List<ContactDetails>>(getResponse.Content);
            ContactDetails contact = existingContacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            while (true)
            {
                Console.WriteLine("To Update Contact");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. Phone number");
                Console.WriteLine("3. Address");
                Console.WriteLine("4. City");
                Console.WriteLine("5. State");
                Console.WriteLine("6. Zip Code");
                Console.WriteLine("0. Exit");
                Console.Write("==> ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter Email: ");
                        contact.Email = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter Phone Number: ");
                        contact.PhoneNumber = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Address: ");
                        contact.Address = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter City: ");
                        contact.City = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter State: ");
                        contact.State = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Enter Zip Code: ");
                        contact.ZipCode = Console.ReadLine();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid options.");
                        break;
                }

                // Send the updated contact information to the server
                RestRequest putRequest = new RestRequest($"/Contacts/{contact.ID}", Method.Put);
                JsonObject jObjectBody = new JsonObject();

                jObjectBody.Add("FirstName", contact.FirstName);
                jObjectBody.Add("LastName", contact.LastName);
                jObjectBody.Add("Email", contact.Email);
                jObjectBody.Add("PhoneNumber", contact.PhoneNumber);
                jObjectBody.Add("Address", contact.Address);
                jObjectBody.Add("City", contact.City);
                jObjectBody.Add("State", contact.State);
                jObjectBody.Add("ZipCode", contact.ZipCode);

                putRequest.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

                RestResponse putResponse = client.Execute(putRequest);

                ContactDetails dataResponse = JsonConvert.DeserializeObject<ContactDetails>(putResponse.Content);

            }
        }

        public void DeleteContact()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            // Check if a contact with the same first and last name exists
            RestRequest getRequest = new RestRequest("/Contacts", Method.Get);
            if (client == null)
            {
                Setup();
            }
            RestResponse getResponse = client.Execute(getRequest);
            List<ContactDetails> existingContacts = JsonConvert.DeserializeObject<List<ContactDetails>>(getResponse.Content);
            ContactDetails contact = existingContacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            // Send a delete request to the server
            RestRequest deleteRequest = new RestRequest($"/Contacts/{contact.ID}", Method.Delete);
            RestResponse deleteResponse = client.Execute(deleteRequest);

            Console.WriteLine("Contact deleted.");
        }

    }
}

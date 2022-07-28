using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace RestSharpAddressBook
{
    public class AddressBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }


    }
    public class RestSharpAddrssBookTests
    {
        RestClient client;
        [SetUp]
        public void Setup()
        {
            client = new RestClient("http://localhost:5000");
        }
        private RestResponse getAddressList()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.Get);

            RestResponse response = client.Execute(request);
            return response;
        }

        [Test]
        public void OnCallingGETApi_ReturnAddressBookList()
        {
            RestResponse response = getAddressList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook> dataResponse = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);

            foreach (AddressBook addressBook in dataResponse)
            {
                System.Console.WriteLine("id: " + addressBook.Id + ",FirstName: " + addressBook.FirstName + ",LastName: " + addressBook.LastName + ",Address" + addressBook.Address + ",Ciyt" + addressBook.City + ",State" + addressBook.State + ",Phonenumber" + addressBook.PhoneNumber + ",Zip" + addressBook.Zip + ",Email" + addressBook.Email);
            }
        }
        [Test]
        public void givenContacts_OnPost_ShouldReturnAddedAddressBook()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.Post);
            JsonObject jObjectbody = new JsonObject();
            jObjectbody.Add("FirstName", "Ganesh");
            jObjectbody.Add("LastName", "jhonny");
            jObjectbody.Add("PhoneNumber", "9187654344");
            jObjectbody.Add("Address", "Ganapathinagara");
            jObjectbody.Add("City", "wyizag");
            jObjectbody.Add("State", "Ap");
            jObjectbody.Add("Zip", "1234");
            jObjectbody.Add("email", "ganesha@gmail.com");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("Ganesh", dataResponse.FirstName);
            Assert.AreEqual("jhonny", dataResponse.LastName);
            Assert.AreEqual("9187654344", dataResponse.PhoneNumber);
            Assert.AreEqual("Ganapathinagara", dataResponse.Address);
            Assert.AreEqual("wyizag", dataResponse.City);
            Assert.AreEqual("Ap", dataResponse.State);
            Assert.AreEqual("1234", dataResponse.Zip);
            Assert.AreEqual("ganesha@gmail.com", dataResponse.Email);

        }
        [Test]
        public void GivenMultipleEmployee_OnPost_ThenShouldReturnEmployeeList()
        {
            List<AddressBook> contactList = new List<AddressBook>();
            contactList.Add(new AddressBook { FirstName = "Ananya", LastName = "Raghu", PhoneNumber = "8877456345", Address = "abc layout", City = "Hydrabad", State = "Telangana", Zip = "147677", Email = "sgf@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "sharanya", LastName = "yk", PhoneNumber = "7356456345", Address = "Feroz Shah Kotla", City = "VishakaPatnam", State = "Andrapradesh", Zip = "247677", Email = "gsd@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "jhnavi", LastName = "shekar", PhoneNumber = "6577456345", Address = "Feroz Shah Kotla", City = "Chennai", State = "TN", Zip = "347677", Email = "ads@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "mahesh", LastName = "b", PhoneNumber = "57577456345", Address = "Feroz Shah Kotla", City = "pudicheryy", State = "Goa", Zip = "447677", Email = "ascx@gmail.com" });
            foreach (var ContactData in contactList)
            {
                RestRequest request = new RestRequest("/AddressBook", Method.Post);
                JsonObject jObjectBody = new JsonObject();
                jObjectBody.Add("FirstName", ContactData.FirstName);
                jObjectBody.Add("LastName", ContactData.LastName);
                jObjectBody.Add("PhoneNumber", ContactData.PhoneNumber);
                jObjectBody.Add("Address", ContactData.Address);
                jObjectBody.Add("City", ContactData.City);
                jObjectBody.Add("State", ContactData.State);
                jObjectBody.Add("Zip", ContactData.Zip);
                jObjectBody.Add("Email", ContactData.Email);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                RestResponse response1 = client.Execute(request);
                Assert.AreEqual(response1.StatusCode, HttpStatusCode.Created);
                AddressBook dataResorce1 = JsonConvert.DeserializeObject<AddressBook>(response1.Content);
                Assert.AreEqual(ContactData.FirstName, dataResorce1.FirstName);
                Assert.AreEqual(ContactData.LastName, dataResorce1.LastName);
                Assert.AreEqual(ContactData.PhoneNumber, dataResorce1.PhoneNumber);
                Assert.AreEqual(ContactData.Address, dataResorce1.Address);
                Assert.AreEqual(ContactData.City, dataResorce1.City);
                Assert.AreEqual(ContactData.State, dataResorce1.State);
                Assert.AreEqual(ContactData.Zip, dataResorce1.Zip);
                Assert.AreEqual(ContactData.Email, dataResorce1.Email);
                System.Console.WriteLine(response1.Content);
            };

            RestResponse response = getAddressList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook> dataResorce = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(6, dataResorce.Count);
        }
        [Test]
        public void GivenEmployee_WhenUpdateSalary_ThenShouldReturnUpdatedEmployeeSalary()
        {
            RestRequest request = new RestRequest("/AddressBook/1", Method.Put);
            JsonObject jObjectBody = new JsonObject();
            jObjectBody.Add("FirstName", "gajannana");
            jObjectBody.Add("LastName", "jhonny");
            jObjectBody.Add("PhoneNumber", "91000654344");
            jObjectBody.Add("Address", "circlenagara");
            jObjectBody.Add("City", "Durga");
            jObjectBody.Add("State", "Ap");
            jObjectBody.Add("Zip", "1234");
            jObjectBody.Add("email", "gagananna@gmail.com");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            AddressBook dataResorce = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("gajannana", dataResorce.FirstName);
            Assert.AreEqual("jhonny", dataResorce.LastName);
            Assert.AreEqual("91000654344", dataResorce.PhoneNumber);
            Assert.AreEqual("circlenagara", dataResorce.Address);
            Assert.AreEqual("Durga", dataResorce.City);
            Assert.AreEqual("Ap", dataResorce.State);
            Assert.AreEqual("1234", dataResorce.Zip);
            Assert.AreEqual("gagananna@gmail.com", dataResorce.Email); ;
            Console.WriteLine(response.Content);
        }
        [Test]
        public void GivenEmployeeId_WhenDelete_ThenShouldReturnSuccess()
        {
            RestRequest request = new RestRequest("/AddressBook/6", Method.Delete);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }
    }
}
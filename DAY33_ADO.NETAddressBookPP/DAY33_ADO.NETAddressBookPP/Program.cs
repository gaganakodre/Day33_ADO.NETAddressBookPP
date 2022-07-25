namespace DAY33_ADO.NETAddressBookPP
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable\n3.InsertTntoTable\n4.RetriveAllContact\n5.UpdatingToExisting");
            int op = Convert.ToInt16(Console.ReadLine());
            AddressBookModel model = new AddressBookModel();
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            switch (op)
            {
                case 1:
                    addressBookRepo.Create_Database();
                    break;
                 case 2:
                    addressBookRepo.CreateTables();
                    break;
                case 3:

                    model.FirstName = "Shree";
                    model.LastName = "Gowri";
                    model.Address = "RR nagara";
                    model.City = "Bangalore";
                    model.State = "Karnataka";
                    model.Zip = "456079";
                    model.PhoneNumber = "990865976";
                    model.Email = "shree@gmail.com";
                    addressBookRepo.AddContact(model);
                    Console.WriteLine("Address insrted sucsses fully");
                    break;

                case 4:
                    addressBookRepo.RetriveAllContact();
                    break;
                case 5:
                    addressBookRepo.updateEmployeeDetails();
                    Console.WriteLine("updated sucsessFully");
                    break;




            }
        }
    }
}


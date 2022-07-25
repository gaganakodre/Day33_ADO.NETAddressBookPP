namespace DAY33_ADO.NETAddressBookPP
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable");
            int op = Convert.ToInt16(Console.ReadLine());
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            switch (op)
            {
                case 1:
                    addressBookRepo.Create_Database();
                    break;
                 case 2:
                    addressBookRepo.CreateTables();
                    break;



            }
        }
    }
}


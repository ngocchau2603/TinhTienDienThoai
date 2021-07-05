using System;

namespace ConsoleApp1
{
    public class Program
    {
        public class Customer
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Type { get; set; }
            public double Tax { get; set; }
        }
        public static void Main()
        {
            Customer customer = new Customer();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(customer);
            }
        }
        private static bool MainMenu(Customer customer)
        {
            var program = new Program();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Thong tin khach hang");
            Console.WriteLine("2) Tinh cuoc");
            Console.WriteLine("3) In so thue");
            Console.WriteLine("4) Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    program.AddCustomerInfo(customer);
                    return true;
                case "2":
                    program.CalculateTeleCost(customer);
                    return true;
                case "3":
                    program.PrintTax(customer);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        private void CalculateTeleCost(Customer customer)
        {
            Console.WriteLine("Nhap phut");
            var sophut = Console.ReadLine();
            int iSoPhut = Convert.ToInt32(sophut);
            if (customer.Type == "0" && iSoPhut > 50) {
                iSoPhut -= 50;
            }
            else
            {
                iSoPhut = 0;
            }
            var sotien = 27000;
            if (iSoPhut > 400)
            {
                sotien += 120 * 200 + 80 * 200
                    + (iSoPhut - 401 + 1) * 40;

            }
            else if (iSoPhut > 200)
            {
                sotien += 120 * 200 + (iSoPhut - 200) * 80;

            }
            else sotien += 120 * iSoPhut;
            if(!string.IsNullOrEmpty(customer.Name))
                Console.WriteLine($"Khach hang {customer.Name} co SDT {customer.Phone}");

            customer.Tax = sotien * 0.1;
            Console.WriteLine($"Cuoc phi:{sotien} VND");
        }
        private void PrintTax(Customer customer)
        {

            Console.WriteLine($"Thue:{customer.Tax} VND");
        }
        private void AddCustomerInfo(Customer customer)
        {
            Console.WriteLine("Nhap ten");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Nhap SDT");
            customer.Phone = Console.ReadLine();
            Console.WriteLine("Nhap loai");
            customer.Type = Console.ReadLine();
        }
    }
}

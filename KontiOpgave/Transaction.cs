using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class Transaction
    {

        public void CreateAccount()
        {
            // Creating a new list
            List<CustomerProperties> customerProperties = new List<CustomerProperties>();

            // Getting input from the customer
            Console.WriteLine("Skriv kontonavnet: ");
            string kontonavn = Console.ReadLine();

            // Adding the information to the list, to create a new account
            CustomerProperties customer= new CustomerProperties();
            customer.AccountName = kontonavn;
            customer.AccountFunds = 0;
            customerProperties.Add(customer);

            string filePath = @"C:\Users\Tec\Desktop\_weeks_8_h1\___programming\__1_bank_konti_group_project\KontiOpgave\kontier\";

            // create new file
            foreach (var item in customerProperties)
            {
                using StreamWriter file = new(filePath + item.AccountName + ".txt", append: true) ;
                file.WriteAsync(item.AccountName + "\n");
                file.WriteAsync(item.AccountFunds.ToString());
            }
        }

    }

    public class CustomerProperties
    {
        public string AccountName { get; set; }
        public decimal AccountFunds { get; set; }

      
    }
}

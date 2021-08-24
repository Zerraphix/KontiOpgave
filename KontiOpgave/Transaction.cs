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
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string AccountPath;
            AccountPath = projectDirectory + @"\kontier";
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

            // create new file
            foreach (var item in customerProperties)
            {
                using StreamWriter file = new(AccountPath + item.AccountName + ".txt", append: true) ;
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

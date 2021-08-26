using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class AccountCreater
    {
        // this method allows the user to create additional accounts
        public void CreateAccount(string i)
        {
            // declaring variables
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;

            // getting the path for the specific user using index i
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\";

            // Creating a new list
            List<CustomerProperties> customerProperties = new List<CustomerProperties>();

            // Getting input from the customer
            Console.WriteLine("Skriv kontonavnet: ");
            string kontonavn = Console.ReadLine();

            // Adding the information to the list, to create a new account
            CustomerProperties customer = new CustomerProperties();

            // The account will have a name chosen by the user, and a default amount of 0
            customer.AccountName = kontonavn;
            customer.AccountFunds = 0;
            customerProperties.Add(customer);

            // create new file
            foreach (var item in customerProperties)
            {
                using StreamWriter file = new(AccountPath + item.AccountName + ".txt", append: true);
                {
                    file.WriteAsync(item.AccountName + "\n");
                    file.WriteAsync(item.AccountFunds.ToString());
                }
            }
        }
    }
    // the properties are retrived and set / get and set...
    public class CustomerProperties
    {
        public string AccountName { get; set; }
        public decimal AccountFunds { get; set; }
    }
}

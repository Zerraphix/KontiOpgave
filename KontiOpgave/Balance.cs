using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace KontiOpgave
{
    public class Balance
    {
        // this method gets the current balance on the user's accounts
        public void BalanceMethod(string i)
        {
            // declare variables
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;

            // we use the index i to identify the correct user
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\";
            
            // Takes all the files from the folder/path "kontier" and puts them into a string array.
            string[] accounts = Directory.GetFiles(AccountPath);

            // goes through the string array and gets the last string in each file, this is the current balance
            foreach (string account in accounts)
            {
                string[] line = System.IO.File.ReadAllLines(account);
                Console.WriteLine($"\n{line[0]}");
                Console.WriteLine($"{line[line.Length - 1]}");
            }
            Console.ReadKey();
        }
    }
}

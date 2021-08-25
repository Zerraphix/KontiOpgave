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
        public void BalanceMethod(string i)
        {
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\" ;
            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(AccountPath);

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

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
        public void BalanceMethod()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string AccountPath;
            AccountPath = projectDirectory + @"\kontier\";
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

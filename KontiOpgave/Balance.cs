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
public void BalanceMethod ()
{
            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(@"C:\Users\Tec\Desktop\_weeks_8_h1\___programming\__1_bank_konti_group_project\KontiOpgave\kontier");

            foreach (string account in accounts)
            {
                string [] line = System.IO.File.ReadAllLines(account);
                Console.WriteLine($"\n{line[0]}");
                Console.WriteLine($"{line[line.Length - 1]}");
            }
            Console.ReadKey();
        }
    }
}

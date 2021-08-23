using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class Balance
    {
        public void BalanceMethod ()
        {
            string[] balance = System.IO.File.ReadAllLines(@"D:\Skole\Programmering\Konti\KontiOpgave\KontiOpgave\kontier\Ferie_Konto.txt");
            /* foreach (var line in balance)
             {

                 Console.WriteLine(line[balance.Length-1]);
             }*/

            Console.WriteLine($"{balance[0]}");
            Console.WriteLine($"{balance[balance.Length - 1]}");

            Console.ReadKey();
        }
    }
}

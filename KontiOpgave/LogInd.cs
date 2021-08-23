using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class LogInd
    {
        public static void Bruger(string bruger)
        {
            int fejl = 0;
            do
            {
                if (fejl == 1)
                {
                    Console.Write("Du har skrevet et brugernavn som ikke er fuld lowercase, prøv igen: ");
                    bruger = Console.ReadLine();
                }
                if (bruger.All(char.IsLower))
                {
                    fejl = 0;
                }
                else
                {
                    fejl = 1;
                }
            }
            while (fejl != 0);
        }
        public static void Password(string password)
        {
            int fejl = 0;
            do
            {
                if (fejl == 1)
                {
                    Console.Write("Det valgte password følger ikke vores regler, prøv at skrive et ny password: ");
                    password = Console.ReadLine();
                }
                if (password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Contains("!") || password.Contains("#") || password.Contains("%"))
                {
                    fejl = 0;

                    if (password.Length >= 12)
                    {
                        fejl = 0;

                        if (password.Contains(" "))
                        {
                            fejl = 1;
                        }
                        else
                        {
                            fejl = 0;

                        }
                    }
                    else
                    {
                        fejl = 1;
                    }
                }
                else
                {
                    fejl = 1;
                }
            }
            while (fejl != 0);
        }
        public static void Logind(string bruger, string kode)
        {
            int fejl = 0;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\joekn\Desktop\Ny mappe (3)\Logind.txt");
            do
            {
                if (fejl == 1)
                {
                    Console.WriteLine("Det ser udtil du har tastet noget forkert, prøv igen");
                    Console.Write("Brugernavn: ");
                    bruger = Console.ReadLine();
                    Console.Write("Password: ");
                    kode = Console.ReadLine();
                }

                foreach (string line in lines)
                {
                    if (line.Contains(bruger))
                    {
                        fejl = 0;
                        if (line.Contains(kode))
                        {
                            fejl = 0;
                        }
                        else
                        {
                            fejl = 1;
                        }
                    }
                    else
                    {
                        fejl = 1;
                    }
                }
            }
            while (fejl != 0);
            Console.WriteLine("Du er nu logget ind");
            Console.ReadKey();
        }
    }
}

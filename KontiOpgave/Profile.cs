using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class Profile
    {
        public void ShowProfile(string i)
        {
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string UserPath, CardPath, svar;
            UserPath = RoamingPath + @"\kontiuser\" + i + @"\Profile.txt";
            CardPath = RoamingPath + @"\kontiuser\" + i + @"\CardInfo.txt";
            string[] UserData = System.IO.File.ReadAllLines(UserPath);
            int counter = 0;
            Console.WriteLine("Navn       : ");
            Console.WriteLine("Typekunde  : ");
            Console.WriteLine("Fødselsdato: ");
            Console.WriteLine("Telefon    : ");
            Console.WriteLine("Email      : ");
            Console.WriteLine("Adresse    : ");
            Console.WriteLine("Cpr        : ");
            foreach (string account in UserData)
            {
                // prints the accounts and amount of money in them
                Console.SetCursorPosition(13,counter);
                Console.Write(account);
                counter++;
            }
            string[] CardInfo = System.IO.File.ReadAllLines(CardPath);
            Console.WriteLine("\n\nDit kort:");
            Console.WriteLine($"{CardInfo[0]}");
            Console.WriteLine($"{CardInfo[CardInfo.Length - 1]}");
            Console.ReadKey();
            if (CardInfo[CardInfo.Length - 1] == "Aktivt")
            {
                do
                {
                    Console.Write("Vil du spære dit kort? (j/n): ");
                    svar = Console.ReadLine().ToLower();
                    if (svar == "j")
                    {
                        using StreamWriter file = new(CardPath, append: true);
                        file.WriteAsync("\nSpærret");
                        Console.WriteLine("Dit kort er nu spærret");
                        Console.ReadKey(true);
                        return;
                    }
                    else if (svar == "n")
                    {
                        return;
                    }
                    Console.WriteLine("Husk du skal skrive j eller n, prøv igen");
                } while (svar != "j");
            }
            else if (CardInfo[CardInfo.Length - 1] == "Spærret")
            {
                do
                {
                    Console.Write("Vil du genaktivere dit kort? (j/n): ");
                    svar = Console.ReadLine().ToLower();
                    if (svar == "j")
                    {
                        using StreamWriter file = new(CardPath, append: true);
                        file.WriteAsync("\nAktivt");
                        Console.WriteLine("Dit kort er nu aktivt igen");
                        Console.ReadKey(true);
                        return;
                    }
                    else if (svar == "n")
                    {
                        return;
                    }
                    Console.WriteLine("Husk du skal skrive j eller n, prøv igen");
                } while (svar != "j");
            }
        }
    }
}

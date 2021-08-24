using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class LogInd
    {
        // Checks if the new username is valid
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
        // checks if the new password is valid
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

                    if (password.Length >= 6)
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
        // Checks if the login is valid. 
        public static void Logind(string AflæstBruger, string kode)
        {
            string bruger = "";
            int fejl = 0;
            // Reads the file where users and passwords are saved
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Tec\Desktop\_weeks_8_h1\___programming\__1_bank_konti_group_project\KontiOpgave\LogInd\Logind.txt");
            // this do while continues until password and username are approved
            do
            {
                do
                {       
                    // As long as password and username are not approved, the console outputs an error message, and asks for new input
                    if (fejl == 1)
                    {
                        Console.WriteLine("Det ser udtil du har tastet noget forkert, prøv igen");
                        Console.Write("Brugernavn: ");
                        AflæstBruger = Console.ReadLine();
                        Console.Write("Password: ");
                        kode = Console.ReadLine();
                        bruger = AflæstBruger + "|";
                        fejl = 0;
                    }
                    if (bruger == kode)
                    {
                        fejl = 1;
                    }
                }
                while (fejl != 0);

                // We look through each line in the text file. If the username exists, we check if the next word matches the password
                foreach (string line in lines)
                {
                    if (line.Contains(bruger))
                    {
                        fejl = 0;
                        if (line.Contains(kode))
                        {
                            fejl = 0;
                            return;
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
            
        }
    }
}

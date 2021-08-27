using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    public class LogInd
    {
        // this is a class where the user logs in, to get access to the rest of the system
        // Checks if the new username is valid
        // Outcommented because it is not used in this update, but can be used later on if needed.

        //public static void Bruger(string bruger)
        //{
        //    int fejl = 0;
        //    do
        //    {
        //        if (fejl == 1)
        //        {
        //            Console.Write("Du har skrevet et brugernavn som ikke er fuld lowercase, prøv igen: ");
        //            bruger = Console.ReadLine();
        //        }
        //        if (bruger.All(char.IsLower))
        //        {
        //            fejl = 0;
        //        }
        //        else
        //        {
        //            fejl = 1;
        //        }
        //    }
        //    while (fejl != 0);
        //}

        // checks if the new password is valid
        public static string Password(string password)
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
            return password;
        }
        // This method checks if the login is valid. 
        public static string Logind(string bruger, string kode)
        {
            // declares variables
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LogIndPath, testnum;
            LogIndPath = RoamingPath + @"\kontiuser\Logind.txt";
            int fejl = 0, i = 0, tæller = 1;
            // Reads the file where users and passwords are saved
            string[] lines = System.IO.File.ReadAllLines(LogIndPath);
            // this dowhile continues until password and username are approved
            do
            {
                do
                {
                    // As long as password and username are not approved, the console outputs an error message, and asks for new input
                    if (fejl == 1)
                    {
                        Console.WriteLine("Det ser ud til du har tastet noget forkert, prøv igen");
                        Console.Write("Brugernavn: ");
                        bruger = Console.ReadLine();
                        Console.Write("Password: ");
                        kode = Console.ReadLine();
                        fejl = 0;
                        i = 0;
                        tæller++;
                    }
                    if (bruger == kode)
                    {
                        fejl = 1;
                    }
                    if (tæller == 3)
                    {
                        Console.WriteLine("Du har tastet forkert 3 gange. Applicationen lukkes. ");
                        Environment.Exit(0);
                    }
                }
                while (fejl != 0);

                // We look through each line in the Password.txt file, and check if the last word (most recent password) matches the input-password. 
                foreach (string line in lines)
                {
                    i++;
                    if (line == bruger)
                    {
                        fejl = 0;
                        string PasswordPath = RoamingPath + @"\kontiuser\" + i + @"\Password.txt";
                        string[] Pass = System.IO.File.ReadAllLines(PasswordPath);
                        if (kode == Pass[Pass.Length - 1])
                        {
                            fejl = 0;
                            testnum = i.ToString();
                            return testnum;
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
            testnum = i.ToString();
            return testnum;
        }
    }
}

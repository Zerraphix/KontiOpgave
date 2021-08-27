using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class Settings
    {
        // this method allows the user to change their password
        public void PasswordChanger(string s)
        {
            // the user can change their password here
            // declare variables and location of text file
            string aflæstGamlePassword, nytPassword, bekræftetNytPassword, checkedPassword, LogIndPath;
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            LogIndPath = RoamingPath + @"\kontiuser\" + s + @"\Password.txt";
            int tæller = 0;
            bool doesItWork = false;
            // Reads the file where users and passwords are saved
            string[] lines = System.IO.File.ReadAllLines(LogIndPath);

            // this do while continues until password and username are approved
            do
            {
                Console.Write("Indtast dit gamle password: ");
                aflæstGamlePassword = Console.ReadLine();
                tæller++;
                // we go through the file and get the user's old password


                // check if the old password from the file matches the password the user wrote
                if (lines[lines.Length - 1] == aflæstGamlePassword)
                {
                    doesItWork = true;
                }
            } while (doesItWork == false);

            // the do while continues as long as the two new passwords do not match
            do
            {
                Console.WriteLine("Dit nye password skal være på mindst 6 tegn, og indeholde mindst et stort bogstav, et lille bogstav, et tal og et specialt tegn");
                Console.Write("Indtast dit nye password: ");
                nytPassword = Console.ReadLine();
                checkedPassword = LogInd.Password(nytPassword);
                Console.Write("Bekræft dit nye password: ");
                bekræftetNytPassword = Console.ReadLine();

                // check if the two input texts match
                if (checkedPassword == bekræftetNytPassword)
                {
                    // replace the old password with the new
                    using StreamWriter file = new(LogIndPath, append: true);
                    file.WriteLine("\n" + nytPassword);
                    Console.WriteLine("Du har nu skiftet dit password!");
                }
                // if the two instances of the new password do not match, the user is asked to try again
                else
                {
                    Console.WriteLine("De to passwords matchede ikke. Prøv igen!");
                }
            } while (checkedPassword != bekræftetNytPassword);

        }
        // not currently in use
        //public void AdminThingy()
        //{
        //    string workingDirectory = Environment.CurrentDirectory;
        //    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        //    string LogIndPath;
        //    LogIndPath = projectDirectory + @"\LogInd\Logind.txt";
        //    string password = "Password", bruger = "bruger", samletlog;
        //    Console.Write("Indtast et brugernavn: ");
        //    bruger = Console.ReadLine();
        //    LogInd.Bruger(bruger);
        //    Console.Write("Indtast en kode der vil virke: ");
        //    password = Console.ReadLine();
        //    LogInd.Password(password);
        //    Console.ReadKey();

        //    samletlog = bruger + "| " + password;
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(LogIndPath, true))
        //    {
        //        file.WriteLine(samletlog);
        //    }

        //}
    }
}

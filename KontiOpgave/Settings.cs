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

        public void PasswordChanger(string s)
        {
            // the user can change their password here
            // declare variables and location of text file
            string aflæstGamlePassword, nytPassword, bekræftetNytPassword, LogIndPath, gamlePassword = "";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            LogIndPath = projectDirectory + @"\LogInd\Logind.txt";
            string gammeltPassword = "";
            int si = Convert.ToInt32(s);
            int i = si, tæller = 0;
            bool DoItWork = false;
            i = i - 1;
            // Reads the file where users and passwords are saved
            string[] lines = System.IO.File.ReadAllLines(LogIndPath);

            // this do while continues until password and username are approved
            do
            {
                Console.WriteLine("Indtast dit gamle password: ");
                aflæstGamlePassword = Console.ReadLine();
                tæller++;
                // we go through the file and get the user's old password
                int k = 0;
                foreach (string line in lines)
                {
                    k++;
                    if (k == si)
                    {
                        gamlePassword = line.Split(" ")[1];
                    }
                }

                // check if the old password from the file matches the password the user wrote
                if (gamlePassword == aflæstGamlePassword)
                {
                    DoItWork = true;
                }
            } while (DoItWork == false);

            Console.WriteLine("Indtast dit nye password: ");
            nytPassword = Console.ReadLine();
            Console.WriteLine("Bekræft dit nye password: ");
            bekræftetNytPassword = Console.ReadLine();

            // check if the two input texts match

            if (nytPassword == bekræftetNytPassword)
            {
                // replace the old password with the new

                // we go through the file and get the user's old password
                int k = 0;
                foreach (string line in lines)
                {
                    k++;
                    if (k == si)
                    {
                        string username = line.Split(" ")[0];
                        string Whole = username + " " + nytPassword;

                        //string replacedPassword=line.ToString.Replace(gammeltPassword,nytPassword);
                        using StreamWriter file = new(LogIndPath, append: false);
                        file.WriteLine(line.Replace(line, Whole));
                    }
                }






            }
            Console.WriteLine("Du har nu skiftet dit password!");

        }
        public void AdminThingy()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string LogIndPath;
            LogIndPath = projectDirectory + @"\LogInd\Logind.txt";
            string password = "Password", bruger = "bruger", samletlog;
            Console.Write("Indtast et brugernavn: ");
            bruger = Console.ReadLine();
            LogInd.Bruger(bruger);
            Console.Write("Indtast en kode der vil virke: ");
            password = Console.ReadLine();
            LogInd.Password(password);
            Console.ReadKey();

            samletlog = bruger + "| " + password;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(LogIndPath, true))
            {
                file.WriteLine(samletlog);
            }

        }
    }
}

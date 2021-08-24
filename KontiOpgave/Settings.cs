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
        public void PasswordChanger()
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

            samletlog = bruger + " " + password;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(LogIndPath, true))
            {
                file.WriteLine(samletlog);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    class Settings
    {
        public void PasswordChanger()
        {
            string password = "Password", bruger = "bruger", samletlog;
            Console.Write("Indtast et brugernavn: ");
            bruger = Console.ReadLine();
            LogInd.Bruger(bruger);
            Console.Write("Indtast en kode der vil virke: ");
            password = Console.ReadLine();
            LogInd.Password(password);
            Console.ReadKey();

            samletlog = bruger + " " + password;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Skole\Programmering\Konti\KontiOpgave\KontiOpgave\LogInd\Logind.txt", true))
            {
                file.WriteLine(samletlog);
            }
        }
    }
}

using System;

namespace KontiOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            Password();
            static void Password()
            {
                string password = "Password", bruger = "bruger", samletlog, brugerlog, passlog;
                Console.Write("Indtast et brugernavn: ");
                bruger = Console.ReadLine();
                LogInd.Bruger(bruger);
                Console.Write("Indtast en kode der vil virke: ");
                password = Console.ReadLine();
                LogInd.Password(password);
                Console.ReadKey();

                samletlog = bruger + " " + password;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Tec\Desktop\Logind.txt", true))
                {
                    file.WriteLine(samletlog);
                }

                Console.WriteLine("Lad os nu prøve at logge ind med de nylige oprettet bruger navn og password.");
                Console.Write("Brugernavn: ");
                brugerlog = Console.ReadLine();
                Console.Write("Password: ");
                passlog = Console.ReadLine();
                LogInd.Logind(brugerlog, passlog);
                return;
            }
        }
    }
}

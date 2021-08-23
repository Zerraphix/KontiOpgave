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

                Console.WriteLine("Lad os nu prøve at logge ind med de nylige oprettet bruger navn og password.");
                Console.Write("Brugernavn: ");
                brugerlog = Console.ReadLine();
                Console.Write("Password: ");
                passlog = Console.ReadLine();
                LogInd.Logind(brugerlog, passlog);
                return;

                //yOooo, testing that commit push laddie
            }
        }
    }
}

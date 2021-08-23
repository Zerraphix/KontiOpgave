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
                string bruger, brugerlog, passlog;   
                

                Console.WriteLine("Lad os nu prøve at logge ind med de nylige oprettet bruger navn og password.");
                Console.Write("Brugernavn: ");
                bruger = Console.ReadLine();
                Console.Write("Password: ");
                passlog = Console.ReadLine();
                brugerlog = bruger + "|";
                LogInd.Logind(brugerlog, passlog);
                Console.WriteLine("Du er nu logget ind");
                Console.ReadKey();
            }
        }
    }
}

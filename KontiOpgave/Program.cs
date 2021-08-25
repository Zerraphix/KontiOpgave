using System;

namespace KontiOpgave
{
    class Program
    {
        static void Main(string[] args)
        {

            string brugerlog, passlog;


            Console.WriteLine("Log ind.");
            Console.Write("Brugernavn: ");
            brugerlog = Console.ReadLine();
            Console.Write("Password: ");
            passlog = Console.ReadLine();            
            string test = LogInd.Logind(brugerlog, passlog);
            Console.WriteLine("Du er nu logget ind");
            Console.ReadKey();

            // Sending over to menu
            Menu menu = new Menu();
            menu.MenuOversigt(test);

        }
    }
}

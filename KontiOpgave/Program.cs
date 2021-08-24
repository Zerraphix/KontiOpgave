using System;

namespace KontiOpgave
{
    class Program
    {
        static void Main(string[] args)
        {

            string bruger, brugerlog, passlog;

            Console.WindowHeight = 14;
            Console.WindowWidth = 29;
            Console.WriteLine("Log ind.");
            Console.Write("Brugernavn: ");
            bruger = Console.ReadLine();
            Console.Write("Password: ");
            passlog = Console.ReadLine();
            brugerlog = bruger + "|";
            LogInd.Logind(brugerlog, passlog);
            Console.WriteLine("Du er nu logget ind");
            Console.ReadKey();

            // Sending over to menu
            Menu menu = new Menu();
            menu.MenuOversigt();

        }
    }
}

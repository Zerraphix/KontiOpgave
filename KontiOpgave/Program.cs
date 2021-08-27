using System;

namespace KontiOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaring variables
            MakeOurData makeOurData= new MakeOurData();
            makeOurData.DataChecker();

            Start start= new Start();
            start.StartMenu();                                 
        }
        public void StartLogInd()
        {
            // declaring variables
            string brugerlog, passlog;

            // Log in: get inputdata from user
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("    v");
            Console.ResetColor();
            Console.WriteLine("    █████     ██    █    █  █  █");
            Console.WriteLine("    █    █   █  █   ██   █  █ █ ");
            Console.WriteLine("    █████   █    █  █ █  █  ██  ");
            Console.WriteLine("    █    █  ██████  █  █ █  █ █ ");
            Console.WriteLine("    █████  █      █ █   ██  █  █\n");
            Console.WriteLine("        *** Log ind ***\n");
            Console.Write("Brugernavn: ");
            brugerlog = Console.ReadLine().ToLower();
            Console.Write("Password: ");
            passlog = Console.ReadLine();

            // check if the login is valid
            // the method also returns the index i for the users folder, so it can be used later in the code
            string i = LogInd.Logind(brugerlog, passlog);
            Console.WriteLine("Du er nu logget ind");
            Console.ReadKey();

            // Sending over to menu
            Menu menu = new Menu();
            menu.MenuOversigt(i);
        }
    }
}

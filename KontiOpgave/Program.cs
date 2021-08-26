using System;

namespace KontiOpgave
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaring variables
            string brugerlog, passlog;
            MakeOurData makeOurData= new MakeOurData();
            makeOurData.DataCreator();

            // Log in: get inputdata from user 
            Console.WriteLine("*** Log ind ***");
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

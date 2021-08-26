using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class Transaction
    {
        // ask the user what they want to do

        // put money into the main account


        // transfer money to others - show which accounts they can chose from and how much money is on it - and prevent them from taking more money than is on the account
        // tranfer to themselves - from which account to which?
        // take money out of the account

        // read the file - how much money is there? 
        // subtract/add the amount the user input from the first file
        // if it is a transfer to themselves - update the recieving file with the new amount
        // ask the user if they want to return to the main menu or make another transaction

        // Makes a list combining methods.
        public static List<Option> options;
        public void MenuOversigtTransaction(string i)
        {
            //Put inputs into the list of options
            options = new List<Option>
            {
                new Option("Sæt penge ind på din NemKonto", () => StartMenu("SætPengeInd", i)),
                new Option("Overfør penge mellem dine egne konti", () =>  StartMenu("OverførMellemEgne", i)),
                new Option("Overfør penge til en anden konto", () =>  StartMenu("OverførTilAndre", i)),
                new Option("Hæve pænge fra egne konti", () => StartMenu("HævPenge", i)),
                new Option("Tryk 'escape' for at vende tilbage til hovedmenuen", () => StartMenu("Afslut", i)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;


            Console.SetCursorPosition(0, 7);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                // Write the menu out
                WriteMenu(options, options[index]);
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                // Only the up and down arrow keys is assigned to make the switch between options
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
        // Default action of all the options
        static void StartMenu(string message, string i)
        {
            Transaction transaction = new Transaction();
            Console.Clear();
            switch (message)
            {
                case "SætPengeInd":
                    transaction.PutMoneyIntoAccount(i);
                    //her skal den kalde en metode
                    break;
                case "OverførMellemEgne":
                    transaction.TranferMoneyBetweenAccounts(i);
                    //her skal den kalde en metode
                    break;
                case "OverførTilAndre":
                    transaction.TranferMoneyAwayFromAccount(i);
                    break;
                case "HævPenge":
                    transaction.TakeMoneyOutOfTheAccount(i);
                    //her skal den kalde en metode
                    break;
                case "Afslut":

                    break;
                default:
                    break;

            }
        }
        // WriteMenu is the display of each different option which the user can choose between.
        static void WriteMenu(List<Option> options, Option selectedOption)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("    v");
            Console.ResetColor();
            Console.WriteLine("    █████     ██    █    █  █  █");
            Console.WriteLine("    █    █   █  █   ██   █  █ █ ");
            Console.WriteLine("    █████   █    █  █ █  █  ██  ");
            Console.WriteLine("    █    █  ██████  █  █ █  █ █ ");
            Console.WriteLine("    █████  █      █ █   ██  █  █\n");
            Console.WriteLine("*** Indsæt, hæv og lav overførsler ***");

            // This is the "arrow" that symbolizes the selection
            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                // Writes out our class option combination of name and selection
                Console.WriteLine(option.Name);
            }
        }

        public void PutMoneyIntoAccount(string i)
        {
            // get the filepath 
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string NemKontoPath;
            ConsoleKeyInfo exit;
            NemKontoPath = RoamingPath + @"\kontiuser\" + i + @"\konti\NemKonto.txt";

            // declare variables
            string indsættesResult, indsættesString;
            decimal indsættesDecimal;

            // ask the user how much money they want to put into the main account, only allow them to continue if it parses to decimal
            do
            {
                Console.Write("Skriv det beløb du vil indsætte: ");
                exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Escape)
                {
                    return;
                }
                indsættesString = Console.ReadLine();
                char tal = Char.ToLower(exit.KeyChar);
                indsættesResult = Convert.ToString(tal) + indsættesString;

            } while (!decimal.TryParse(indsættesResult, out indsættesDecimal));

            // read the amount on the main account and print the new amount on the account 
            string[] Konti = System.IO.File.ReadAllLines(NemKontoPath);
            string nummer = Konti[Konti.Length - 1];
            decimal nummerDecimal = Convert.ToDecimal(nummer);
            decimal newAmount = nummerDecimal + indsættesDecimal;
            Console.WriteLine("Det nye beløb på din NemKonto er: " + newAmount + "kr.");

            // save the new amount on the persons account
            using StreamWriter file = new(NemKontoPath, append: true);
            file.WriteAsync("\n" + newAmount.ToString());
            Console.ReadKey();

        }
        public void TakeMoneyOutOfTheAccount(string i)
        {
            // declare variable
            string kontoNavnResult, indsættesResult, kontoNavn, indsættesString;
            decimal indsættesDecimal;
            ConsoleKeyInfo exit;
            // get the filepath 
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\";


            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(AccountPath);
            // get the number of .txt. files in the folder
            int numberOfAccounts = accounts.Length;

            int counter = 1;
            foreach (string account in accounts)
            {
                string[] Kontier = System.IO.File.ReadAllLines(account);
                Console.WriteLine("\n" + counter + $". {Kontier[0]}" + ": " + $"{Kontier[Kontier.Length - 1]}" + "kr.");
                counter++;

            }

            // ask the user which account they want to take money from
            int kontoNummer;
            do
            {
                do
                {
                    Console.Write("Hvilken konto vil du hæve fra? Indtast dens nummer:  ");
                    exit = Console.ReadKey();
                    if (exit.Key == ConsoleKey.Escape)
                    {
                        return;
                    }                   
                    kontoNavn = Console.ReadLine();
                    char tal = Char.ToLower(exit.KeyChar);
                    kontoNavnResult = Convert.ToString(tal) + kontoNavn;
                } while (!int.TryParse(kontoNavnResult, out kontoNummer));
            } while (numberOfAccounts < kontoNummer);

            do
            {
                Console.WriteLine("Hvor meget vil du hæve?");
                exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Escape)
                {
                    return;
                }
                indsættesString = Console.ReadLine();
                char tal = Char.ToLower(exit.KeyChar);
                indsættesResult = Convert.ToString(tal) + indsættesString;

            } while (!decimal.TryParse(indsættesResult, out indsættesDecimal));

            // read the amount on the main account and print the new amount on the account 
            string[] Konti = System.IO.File.ReadAllLines(accounts[kontoNummer - 1]);
            string nummer = Konti[Konti.Length - 1];
            decimal nummerDecimal = Convert.ToDecimal(nummer);
            decimal newAmount = nummerDecimal - indsættesDecimal;
            Console.WriteLine($"Du hæver {indsættesDecimal}kr og dit nye beløb på din {Konti[0]} er: " + newAmount + "kr.");

            // save the new amount on the persons account
            using StreamWriter file = new(accounts[kontoNummer - 1], append: true);
            file.WriteAsync("\n" + newAmount.ToString());
            Console.ReadKey();
        }
        public void TranferMoneyAwayFromAccount(string i)
        {
            // declare variable
            string kontoNavn, indsættesString, RecieverResult, Reciever, kontoNavnResult, indsættesResult;
            decimal indsættesDecimal;
            ConsoleKeyInfo exit;
            // get the filepath 
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\";

            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(AccountPath);
            int numberOfAccounts = accounts.Length;
            int counter = 1;
            foreach (string account in accounts)
            {
                string[] Kontier = System.IO.File.ReadAllLines(account);
                Console.WriteLine("\n" + counter + $". {Kontier[0]}" + ": " + $"{Kontier[Kontier.Length - 1]}" + "kr.");
                counter++;

            }

            Console.WriteLine("Hvem vil du gerne sende penge til? ");
            exit = Console.ReadKey();
            if (exit.Key == ConsoleKey.Escape)
            {
                return;
            }           
            Reciever = Console.ReadLine();
            char tal = Char.ToLower(exit.KeyChar);
            RecieverResult = Convert.ToString(tal) + Reciever;

            // ask the user which account they want to take money from
            int kontoNummer;
            do
            {
                do
                {
                    Console.Write("Hvilken konto vil du gerne sende fra? Indtast dens nummer:  ");
                    exit = Console.ReadKey();
                    if (exit.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    kontoNavn = Console.ReadLine();
                    tal = Char.ToLower(exit.KeyChar);
                    kontoNavnResult = Convert.ToString(tal) + kontoNavn;
                } while (!int.TryParse(kontoNavnResult, out kontoNummer));
            } while (numberOfAccounts < kontoNummer);

            do
            {
                Console.WriteLine("Hvor meget vil du hæve?");
                exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Escape)
                {
                    return;
                }
                indsættesString = Console.ReadLine();
                tal = Char.ToLower(exit.KeyChar);
                indsættesResult = Convert.ToString(tal) + indsættesString;

            } while (!decimal.TryParse(indsættesResult, out indsættesDecimal));

            // read the amount on the main account and print the new amount on the account 
            string[] Konti = System.IO.File.ReadAllLines(accounts[kontoNummer - 1]);
            string nummer = Konti[Konti.Length - 1];
            decimal nummerDecimal = Convert.ToDecimal(nummer);
            decimal newAmount = nummerDecimal - indsættesDecimal;
            Console.WriteLine($"Du sender {indsættesDecimal}kr til {RecieverResult} og dit nye beløb på din {Konti[0]} er: " + newAmount + "kr.");

            // save the new amount on the persons account
            using StreamWriter file = new(accounts[kontoNummer - 1], append: true);
            file.WriteAsync("\n" + newAmount.ToString());
            Console.ReadKey();
        }
        public void TranferMoneyBetweenAccounts(string i)
        {
            // declare variable
            string afsenderKonto, indsættesString, modtagerKonto, modtagerKontoResult, afsenderKontoResult, indsættesResult;
            decimal indsættesDecimal;
            ConsoleKeyInfo exit;
            // get the filepath 
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AccountPath;
            AccountPath = RoamingPath + @"\kontiuser\" + i + @"\konti\";

            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(AccountPath);
            int numberOfAccounts = accounts.Length;
            int counter = 1;
            foreach (string account in accounts)
            {
                string[] Kontier = System.IO.File.ReadAllLines(account);
                Console.WriteLine("\n" + counter + $". {Kontier[0]}" + ": " + $"{Kontier[Kontier.Length - 1]}" + "kr.");
                counter++;

            }
            int kontoNummerTil;
            do
            {
                do
                {

                    Console.WriteLine("Hvilken konto vil du overføre til? Indtast dens nummer: ");
                    exit = Console.ReadKey();
                    if (exit.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    modtagerKonto = Console.ReadLine();
                    char tal = Char.ToLower(exit.KeyChar);
                    modtagerKontoResult = Convert.ToString(tal) + modtagerKonto;
                } while (!int.TryParse(modtagerKontoResult, out kontoNummerTil));
            } while (numberOfAccounts < kontoNummerTil);

            // ask the user which account they want to take money from
            int kontoNummerFra;
            do
            {
                do
                {
                    do
                    {
                        Console.Write("Hvilken konto vil du gerne sende fra? Indtast dens nummer:  ");
                        exit = Console.ReadKey();
                        if (exit.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        afsenderKonto = Console.ReadLine();
                        char tal = Char.ToLower(exit.KeyChar);
                        afsenderKontoResult = Convert.ToString(tal) + afsenderKonto;
                    } while (!int.TryParse(afsenderKontoResult, out kontoNummerFra));
                } while (numberOfAccounts < kontoNummerFra);

            } while (kontoNummerFra == kontoNummerTil);
            do
            {
                Console.WriteLine("Hvor meget vil du overføre?");
                exit = Console.ReadKey();
                if (exit.Key == ConsoleKey.Escape)
                {
                    return;
                }
                indsættesString = Console.ReadLine();
                char tal = Char.ToLower(exit.KeyChar);
                indsættesResult = Convert.ToString(tal) + indsættesString;

            } while (!decimal.TryParse(indsættesResult, out indsættesDecimal));

            // read the amount on the main account and print the new amount on the account 
            // Withdraws the money
            string[] fraKonti = System.IO.File.ReadAllLines(accounts[kontoNummerFra - 1]);
            string fraBeløb = fraKonti[fraKonti.Length - 1];
            decimal franummerDecimal = Convert.ToDecimal(fraBeløb);
            decimal franewAmount = franummerDecimal - indsættesDecimal;

            // Adds the money
            string[] tilKonti = System.IO.File.ReadAllLines(accounts[kontoNummerTil - 1]);
            string tilBeløb = tilKonti[tilKonti.Length - 1];
            decimal tilnummerDecimal = Convert.ToDecimal(tilBeløb);
            decimal tilnewAmount = tilnummerDecimal + indsættesDecimal;


            Console.WriteLine($"Du har sat {indsættesDecimal}kr ind på {tilKonti[0]}. Der står nu {tilnewAmount}kr. på din konto. \nDet nye beløb på din {fraKonti[0]} er: " + franewAmount + "kr.");

            // save the new amount on the persons account
            using StreamWriter file = new(accounts[kontoNummerFra - 1], append: true);
            file.WriteAsync("\n" + franewAmount.ToString());

            using StreamWriter file2 = new(accounts[kontoNummerTil - 1], append: true);
            file2.WriteAsync("\n" + tilnewAmount.ToString());
            Console.ReadKey();
        }
    }
}

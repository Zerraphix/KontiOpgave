using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class Menu
    {
        // this method makes a menu so the user can navigate around in the bank system
        // Makes a list combining methods.
        public static List<Option> options;
        public void MenuOversigt(string i)
        {
            //Put inputs into the list of options
            options = new List<Option>
            {
                new Option("Se dine konti", () => StartMenu("SeDineKonti", i)),
                new Option("Lav en overførsel", () =>  StartMenu("LavEnOverførsel", i)),
                new Option("Skift dit password", () =>  StartMenu("Settings", i)),
                new Option("Opret en ny konto", () => StartMenu("LavNyKonto", i)),
                new Option("Log ud", () => Environment.Exit(0)),
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
                // Only the up and down arrow keys are assigned to make the switch between options
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    // if the down arrow is pressed, the index number rises by 1
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                // if the up arrow is pressed, the index number falls by 1
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // If enter is pressed, the menu point is selected
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }
        // The chosen input from the menu/list is sent to this method, where the switch case determines which method to call. 
        static void StartMenu(string message, string i)
        {
            Console.Clear();
            switch (message)
            {
                case "SeDineKonti":
                    Balance balence = new Balance();
                    balence.BalanceMethod(i);
                    
                    break;
                case "LavEnOverførsel":
                    Transaction transaction = new Transaction();
                    transaction.MenuOversigtTransaction(i);
                    
                    break;
                case "LavNyKonto":
                    AccountCreater accountcreater = new AccountCreater();
                    accountcreater.CreateAccount(i);
                    break;
                case "Settings":
                    Settings settings = new Settings();
                    settings.PasswordChanger(i);
                    break;
                default:
                    break;

            }
        }
        // The WriteMenu method displays each of the different options which the user can choose between, with the arrow on the index chosen by the user.
        static void WriteMenu(List<Option> options, Option selectedOption)
        {

            Console.Clear();
            Console.WriteLine("█████     ██    █    █  █  █");
            Console.WriteLine("█    █   █  █   ██   █  █ █ ");
            Console.WriteLine("█████   █    █  █ █  █  ██  ");
            Console.WriteLine("█    █  ██████  █  █ █  █ █ ");
            Console.WriteLine("█████  █      █ █   ██  █  █\n");

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
    }

    // Our list that combines names from the list and selection, to write out in a combined text
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}

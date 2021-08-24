using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class Menu
    {
        // Makes a list combining methods.
        public static List<Option> options;
        public void MenuOversigt()
        {
            //Put inputs into the list of options
            options = new List<Option>
            {
                new Option("Se dine konti", () => StartMenu("SeDineKonti")),
                new Option("Lav en overførsel", () =>  StartMenu("LavEnOverførsel")),
                new Option("Skift dit password", () =>  StartMenu("Settings")),
                new Option("Opret en ny konto", () => StartMenu("LavNyKonto")),
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
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }
        // Default action of all the options
        static void StartMenu(string message)
        {
            Console.Clear();
            switch (message)
            {
                case "SeDineKonti":
                    Balance balence = new Balance();
                    balence.BalanceMethod();
                    //her skal den kalde en metode
                    break;
                case "LavEnOverførsel":

                    //her skal den kalde en metode
                    break;
                case "LavNyKonto":
                    Transaction transaction= new Transaction();
                    transaction.CreateAccount();
                    break;
                case "Settings":
                    //her skal den kalde en metode
                    break;
                default:
                    break;

            }
        }
        // WriteMenu is the display of each different option which the user can choose between.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    public class Menu
    {
        public static List<Option> options;
        public void MenuOversigt()
        {
            options = new List<Option>
            {
                new Option("Se dine konti", () => StartMenu("SeDineKonti")),
                new Option("Lav en overførsel", () =>  StartMenu("LavEnOverførsel")),
                new Option("Skift dit password", () =>  StartMenu("Settings")),
                new Option("Log ud", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            Console.SetCursorPosition(0, 7);
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                WriteMenu(options, options[index]);
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
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
        // Default action of all the options. You can create more methods
        static void StartMenu(string message)
        {
            Console.Clear();
            switch (message)
            {
                case "SeDineKonti":

                    //her skal den kalde en metode
                    break;
                case "LavEnOverførsel":

                    //her skal den kalde en metode
                    break;
                case "Settings":
                    //her skal den kalde en metode
                    break;
                default:
                    break;

            }
        }

        static void WriteMenu(List<Option> options, Option selectedOption)
        {

            Console.Clear();
            Console.WriteLine("█████     ██    █    █  █  █");
            Console.WriteLine("█    █   █  █   ██   █  █ █ ");
            Console.WriteLine("█████   █    █  █ █  █  ██   ");
            Console.WriteLine("█    █  ██████  █  █ █  █ █   ");
            Console.WriteLine("█████  █      █ █   █   █  █\n");

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

                Console.WriteLine(option.Name);
            }
        }
    }


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

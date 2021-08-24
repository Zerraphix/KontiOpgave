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

        public void Money()
        {
            // get the filepath 
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string NemKontoPath;
            NemKontoPath = projectDirectory + @"\kontier\NemKonto.txt";

            // declare variables
            string indsættesString;
            decimal indsættesDecimal;

            // ask the user how much money they want to put into the main account, only allow them to continue if it parses to decimal
            do
            {
                Console.Write("Skriv det beløb du vil indsætte: ");
                indsættesString = Console.ReadLine();

            } while (!decimal.TryParse(indsættesString, out indsættesDecimal));

            // read the amount on the main account and print the new amount on the account 
            string[] line = System.IO.File.ReadAllLines(NemKontoPath);
            string nummer = line[line.Length - 1];
            decimal nummerDecimal = Convert.ToDecimal(nummer);
            decimal newAmount = nummerDecimal + indsættesDecimal;
            Console.WriteLine("Det nye beløb på din NemKonto er: " + newAmount);
            Console.ReadKey();

            // save the new amount on the persons account
            using StreamWriter file = new(NemKontoPath, append: true);
            file.WriteAsync("\n" + newAmount.ToString());

        }
        public void TakeMoneyOutOfTheAccount()
        {
            // declare variable
            string kontoNavn, indsættesString;
            decimal indsættesDecimal, amount;
            // get the filepath 
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string AccountPath;
            AccountPath = projectDirectory + @"\kontier\";

            // Takes all the files from the folder/path "kontier" and puts them into a string array
            string[] accounts = Directory.GetFiles(AccountPath);
            int i = 1;
            foreach (string account in accounts)
            {
                string[] line2 = System.IO.File.ReadAllLines(account);
                Console.WriteLine($"\n" + i + $". {line2[0]}" + ": " + $"{line2[line2.Length - 1]}" + "kr.");
                i++;

            }
            Console.ReadKey();

            // ask the user which account they want to take money from
            int kontoNummer;
            do
            {
                Console.Write("Hvilken konto vil du hæve fra? Indtast dens nummer:  ");
                kontoNavn = Console.ReadLine();
            } while (!int.TryParse(kontoNavn, out kontoNummer));


            do
            {
                Console.WriteLine("Hvor meget vil du hæve?");

                indsættesString = Console.ReadLine();
                // amount =

            } while (!decimal.TryParse(indsættesString, out indsættesDecimal));




        }

    }
}

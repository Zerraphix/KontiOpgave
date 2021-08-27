using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontiOpgave
{
    class Renter
    {
        public void CalculateAndAddInterest()
        {
            //this method is responsible for adding interest to the existing accounts. It runs when the application starts up.
            {
                // declare variable
                string strBeløbFørRente;
                decimal j = 1;
                double rente = 0.0005, intBeløbFørRente, intBeløbEfterRente;
                string AccountPath, kontiuserPath;

                //get the roamingpath
                string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                // get the filepath 
                AccountPath = RoamingPath + @"\kontiuser\" + j + @"\konti\";
                // get the folderpath
                kontiuserPath = RoamingPath + @"\kontiuser\";
                // Takes all the files from the folder/path "kontier" and puts them into a string array
                string[] customers = Directory.GetDirectories(kontiuserPath);

                // foreach customer-folder
                foreach (string folder in customers)
                {
                    string[] accounts = Directory.GetFiles(AccountPath);

                    // for each file in konti
                    foreach (string account in accounts)
                    {
                        // get the current amount in the .txt file and parse it to a double
                        string[] Kontier = File.ReadAllLines(account);
                        strBeløbFørRente = Kontier[Kontier.Length - 1];
                        intBeløbFørRente = Convert.ToDouble(strBeløbFørRente);

                        // add interest
                        intBeløbEfterRente = rente * intBeløbFørRente + intBeløbFørRente;

                        // write the new amount in the .txt file
                        using StreamWriter file = new(account, append: true);
                        file.WriteAsync("\n" + intBeløbEfterRente.ToString());
                    }
                    // change the userpath, so the change will happen in all folders
                    j++;
                    AccountPath = RoamingPath + @"\kontiuser\" + j + @"\konti\";
                }
            }
        }
    }
}

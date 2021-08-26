using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class MakeOurData
    {
        // this method checks if the necessary folders and files exist. If they do not exist, this method creates them
        public void DataCreator()
        {
            // declare variables for folder
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userPath = RoamingPath + @"\kontiuser";
            // checks if the file exists. 
            if (File.Exists(userPath + @"\Logind.txt"))
            {

            }
            // if the file does not exist, it is created with hardcodet data
            else if (!File.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
                using StreamWriter Userfile = new(userPath + @"\Logind.txt", append: false);
                {
                    Userfile.Write("guest\njoey\nmaria\nbenjamin");
                }
                // four folders are created, one for each user - guest, joey, maria, benjamin. 
                // each folder gets a default password and a NemKonto
                for (int i = 1; i < 5; i++)
                {
                    string userMultiplePath = userPath + @"\" + i;
                    if (!File.Exists(userMultiplePath))
                    {
                        Directory.CreateDirectory(userMultiplePath);
                        string kontierPath = userMultiplePath + @"\konti";
                        Directory.CreateDirectory(kontierPath);
                        // default password is set
                        using StreamWriter Passwordfile = new(userMultiplePath + @"\Password.txt", append: false);
                        {
                            Passwordfile.WriteAsync("123456");
                        }
                        // default account is created
                        using StreamWriter NemKontofile = new(kontierPath + @"\NemKonto.txt", append: false);
                        {
                            NemKontofile.WriteAsync("NemKonto\n0");
                        }
                    }
                }
            }
        }
    }
}

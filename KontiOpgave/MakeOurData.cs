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
        public void DataChecker()
        {
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userPath = RoamingPath + @"\kontiuser";

            // checks if the file exists. 
            if (File.Exists(userPath + @"\Logind.txt"))
            {

            }
            // if the file does not exist, it is created with hardcodet data
            else if (!File.Exists(userPath))
            {
                DataCreator();
            }
        }
        // this method checks if the necessary folders and files exist. If they do not exist, this method creates them
        public void DataCreator()
        {
            // declare variables for folder
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userPath = RoamingPath + @"\kontiuser";
            Directory.Delete(userPath, true);

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
            using StreamWriter Profilefile1 = new(userPath + @"\1\Profile.txt", append: false);
            {
                Profilefile1.WriteAsync("Guest\nTest Kunde\n11.11.1111\n+45 xx xx xx xx\nGuest@Test.dk\nTestegade 1\nxxxxxx xxxx");
            }
            using StreamWriter CardInfofile1 = new(userPath + @"\1\CardInfo.txt", append: false);
            {
                CardInfofile1.WriteAsync("xxxx xxxx xxxx 1111\nAktivt");
            }
            using StreamWriter Profilefile2 = new(userPath + @"\2\Profile.txt", append: false);
            {
                Profilefile2.WriteAsync("Joey Knutsson\nUng Kunde\n19.07.1998\n+45 31 25 22 82\njoey.knutsson@rocketmail.com\nPersillehaven 40\n190798 xxxx");
            }
            using StreamWriter CardInfofile2 = new(userPath + @"\2\CardInfo.txt", append: false);
            {
                CardInfofile2.WriteAsync("xxxx xxxx xxxx 6969\nAktivt");
            }
            using StreamWriter Profilefile3 = new(userPath + @"\3\Profile.txt", append: false);
            {
                Profilefile3.WriteAsync("Maria\nUng Kunde\n11.11.1111\n+45 xx xx xx xx\nGuest@Test.dk\nTestegade 1\nxxxxxx xxxx");
            }
            using StreamWriter CardInfofile3 = new(userPath + @"\3\CardInfo.txt", append: false);
            {
                CardInfofile3.WriteAsync("xxxx xxxx xxxx 3333\nAktivt");
            }
            using StreamWriter Profilefile4 = new(userPath + @"\4\Profile.txt", append: false);
            {
                Profilefile4.WriteAsync("Benjamin\nUng Kunde\n11.11.1111\n+45 xx xx xx xx\nGuest@Test.dk\nTestegade 1\nxxxxxx xxxx");
            }
            using StreamWriter CardInfofile4 = new(userPath + @"\4\CardInfo.txt", append: false);
            {
                CardInfofile4.WriteAsync("xxxx xxxx xxxx 4444\nAktivt");
            }
        }
    }
}


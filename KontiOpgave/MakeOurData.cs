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
        public void DataCreator()
        {
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userPath = RoamingPath + @"\kontiuser";
            if (File.Exists(userPath + @"\Logind.txt"))
            {

            }
            else if (!File.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
                using StreamWriter Userfile = new(userPath + @"\Logind.txt", append: false);
                {
                    Userfile.Write("guest\njoey\nmaria\nbenjamin");
                }
                for (int i = 1; i < 5; i++)
                {
                    string userMultiplePath = userPath + @"\" + i;
                    if (!File.Exists(userMultiplePath))
                    {
                        Directory.CreateDirectory(userMultiplePath);
                        string kontierPath = userMultiplePath + @"\konti";
                        Directory.CreateDirectory(kontierPath);
                        using StreamWriter Passwordfile = new(userMultiplePath + @"\Password.txt", append: false);
                        {
                            Passwordfile.WriteAsync("123456");
                        }
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

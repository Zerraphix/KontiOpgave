using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KontiOpgave
{
    class Admin
    {
        // not currently in use
        public void UserCreator()
        {
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LogIndPath, KontiUserPath, NewUserPath, NewUserKontiPath, navn, dato, nummer, email, adresse, cpr, PhoneNumber, ValidEmail, card, SamletProfile, kunde ="";
            string[] year;
            int NewFolder, yearint;
            KontiUserPath = RoamingPath + @"\kontiuser";
            LogIndPath = KontiUserPath + @"\Logind.txt";
            int FolderCount = System.IO.Directory.GetDirectories(KontiUserPath).Length;
            string password = "Password", bruger = "bruger";
            NewFolder = FolderCount + 1;
            NewUserPath = KontiUserPath + @"\" + NewFolder;
            NewUserKontiPath = NewUserPath + @"\konti";
            Console.Write("Indtast et brugernavn: ");
            bruger = Console.ReadLine();
            string ValidBruger = LogInd.Bruger(bruger);
            Console.Write("Indtast en kode der vil virke: ");
            password = Console.ReadLine();
            string ValidPassword = LogInd.Password(password);
            Console.WriteLine("Nu har vi oprettet et logind");
            Console.ReadKey();

            Console.WriteLine("Nu hvor du har et logind, skal vi så oprette din personlige data");
            Console.Write("\nFor at oprette en bruger skal vi bruge telefonnummer, navn, adresse, postnummer, by og email.\n\n");
            Console.Write("Indtast dit fornavn og efternavn: ");
            navn = Console.ReadLine();
            Console.Write("Indtast din fødselsdags dato på denne måde dd.mm.yyyy: ");
            dato = Console.ReadLine();
            year = dato.Split(".");
            Console.Write("Indtast et telefonnummer: ");
            nummer = Console.ReadLine();
            PhoneNumber = PhoneValidator(nummer);
            Console.Write("Indtast din email: ");
            email = Console.ReadLine();
            ValidEmail = EmailValidator(email);
            Console.Write("Indtast din adresse: ");
            adresse = Console.ReadLine();
            Console.Write("Indtast dit cpr nummer: ");
            cpr = Console.ReadLine();

            int randomNumber = new Random().Next(1000, 9999);
            card = "xxxx xxxx xxxx " + randomNumber;

            Console.WriteLine($"\nDit kortnummer er {card} og starter ud som aktivt");

            Directory.CreateDirectory(NewUserPath);
            Directory.CreateDirectory(NewUserKontiPath);

            yearint = Convert.ToInt32(year[2]);
            if (yearint > 2000)
            {
                kunde = "Ung Kunde";
            }
            else if (yearint <=2000 &&  yearint > 1960)
            {
                kunde = "WorkingClass Kunde";
            }
            else
            {
                kunde = "Pension Kunde";
            }
            SamletProfile = navn + "\n" + kunde + "\n" + dato + "\n+45 " + PhoneNumber + "\n" + ValidEmail + "\n" + adresse + "\n" + cpr;
            using StreamWriter file = new(LogIndPath, append: true);
            file.WriteLine("\n" + ValidBruger);

            using StreamWriter Passwordfile = new(NewUserPath + @"\Password.txt", append: false);
            {
                Passwordfile.WriteAsync(ValidPassword);
            }
            using StreamWriter Cardfile = new(NewUserPath + @"\CardInfo.txt", append: false);
            {
                Cardfile.WriteAsync(card + "\nAktivt");
            }
            using StreamWriter Profilefile = new(NewUserPath + @"\Profile.txt", append: false);
            {
                Profilefile.WriteAsync(SamletProfile);
            }

            using StreamWriter NemKontofile = new(NewUserKontiPath + @"\NemKonto.txt", append: false);
            {
                NemKontofile.WriteAsync("NemKonto\n0");
            }
        }
        public string PhoneValidator(string telefonnummer)
        {
            bool IsIt8 = true;
            do
            {
                if (telefonnummer.Length != 8)
                {
                    Console.WriteLine("!! Telefonnummere er på 8 numre !!");
                    Console.WriteLine("Skriv et nyt telefon nummer som er 8 cifre langt");
                    telefonnummer = Console.ReadLine();

                }
                else
                {
                    return telefonnummer;
                }
            }while (IsIt8 == true);
            return telefonnummer;
        }
        public string EmailValidator(string email)
        {
            bool IsItEmail = true;
            do
            {
                if (email.Contains("@"))
                {
                    return email;

                }
                else
                {
                    Console.WriteLine("!! Ugyldig email, alle email's har et [@] !!");
                    Console.WriteLine("Skriv en ny email som er gyldig");
                    email = Console.ReadLine();                   
                }
            } while (IsItEmail == true);
            return email;
        }
    }
}

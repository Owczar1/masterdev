using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;
using static System.Net.Mime.MediaTypeNames;

namespace Zad
{
    internal class Projekt
    {

        public static void zad2()
        {
            int num = 0;
            try
            {
                string txt = System.IO.File.ReadAllText(@"C:\test\test_dan_owc.txt");
                foreach (char c in txt)
                {
                    if (c == 'a' || c == 'A') { num++; }
                }
                Console.WriteLine("Ilość występowania litery a: ");

                Console.WriteLine(num);

                System.Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Masz błąd");
            }


        }

        public static void zad3(){ 
            try
            {
                Console.WriteLine("Please enter the file path: ");

                string path = Console.ReadLine();

                string content = File.ReadAllText(path);

                content = content.Replace("praca", "job");

                DateTime currentDate = DateTime.Now;

                string changedDate = currentDate.Year.ToString() + currentDate.Month.ToString() + currentDate.Day.ToString();

                string newPath = path + "_changed-" + changedDate;

                File.WriteAllText(newPath, content);

                System.Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Masz błąd");
            }
        }

        public static void zad4(){
            
            Random random = new Random();

            int buff;

            int i;

            string line;

            string path2;
            
            line = "Lp, Imie, Nazwisko, Rok_urodzenia \n";

            Console.WriteLine("Ścieżka do zapisania pliku: ");

            path2 = Console.ReadLine();

            path2 = path2 + "/plik.csv";

            using (File.Create(path2))
            {
                string[] names = {"Ania", "Kasia", "Basia", "Zosia"};
                string[] lastNames = {"Kowalska", "Nowak"};

                for (i = 1; i <= 100; i++)
                {
                    buff = random.Next(1, 4);
                    line += i;
                    line += ",";
                    line += names[buff - 1];
                    line += ",";
                    buff = random.Next(1, 100);
                    buff = buff % 2;
                    line += lastNames[buff];
                    line += ",";
                    buff = random.Next(1990, 2000);
                    line += buff;
                    line += "\n";
                }
            }
            File.WriteAllText(path2, line);
        }

                public static void zad5()
        {
            Console.WriteLine("Złote: ");
            double zlote = Convert.ToDouble(Console.ReadLine());

            string link = "http://api.nbp.pl/api/exchangerates/rates/c/usd/today/?format=xml";
            XmlDocument XML = new XmlDocument();
            XML.Load(link);

            XmlNode list = XML.SelectSingleNode("/ExchangeRatesSeries/Rates/Rate/Bid");
            double kurs = Convert.ToDouble(list.InnerText, System.Globalization.CultureInfo.InvariantCulture);
            double wynik = (zlote / kurs);

            Console.Write("USD: ");
            Console.Write(String.Format("{0:N2}", wynik));
            Console.Read();
        }

        static void Main(string[] args)
        {
            zad2();
            zad3();
            zad4();
            zad5();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_Barbara_Friščić
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {           
                Console.WriteLine("Molimo izaberite jednu od ponuđenih opcija:\n1 - PARNOST\n2 - KVADRATNA\n3 - PROSJEK\n4 - ZNAMENKE\n5 - LOTO\n6 - LISTIĆ\n7 - OSOBA\n8 - PDF\nZa izlazak iz aplikacije pritisnite x");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "x")
                {
                    Environment.Exit(0);
                }
                int option = Convert.ToInt32(userInput);
                if(option == 0 || option > 8)
                {
                    Console.WriteLine("Unesite broj od 1 do 8 osvisno o opciji koju želite pokrenuti.");
                    Console.ReadKey();
                }
                
                switch (option)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Unesite broj po želji:");
                            double userNumber = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine(Parnost(userNumber));
                            Console.ReadKey();                           
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");                            
                            Console.ReadKey();                             
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Unesite tri broja za izračun kvadratne jednadžbe:\nPrvi broj:");                 
                            double a = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Drugi broj:");
                            double b = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Treci broj:");
                            double c = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine(Kvadatna((float)a, (float)b, (float)c));
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        try
                        {
                            List<double> ocjene = new List<double>();
                            double unosOcjene;
                            Console.WriteLine("Izabrali ste opciju 3 - PROSJEK\nMolimo unesite ocjene, ocjene su od 1 do 5!");
                            do
                            {
                                unosOcjene = Convert.ToInt32(Console.ReadLine());
                                if(unosOcjene == 0 || unosOcjene > 5)
                                {
                                    break;
                                }
                                ocjene.Add(unosOcjene);
                            }
                            while (unosOcjene != 0 && unosOcjene <= 5);                                                        
                            Console.WriteLine(Prosjek(ocjene));
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        try
                        {
                            int counter = 0;
                            int userN;
                            List<int> userNumbers = new List<int>();
                            Console.WriteLine("Izabrali ste opciju 4 - ZNAMENKE.\nKoliko brojeva želite unijeti?");
                            userN = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Molimo unesite brojeve:");
                            do
                            {
                                int inputNumber = Convert.ToInt32(Console.ReadLine());
                                userNumbers.Add(inputNumber);
                                counter++;

                            } while (counter < userN);
                            Console.WriteLine(Znamenke(userNumbers));
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");
                            Console.ReadKey();
                        }                        
                        break;
                    case 5:
                        Console.WriteLine("Izabrali ste opciju 5 - LOTO\nSlijedi izvlačenje brojeva 7 od 49");
                        Console.ReadKey();
                        Console.WriteLine($"Izvuceni su brojevi: {Loto()}");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Izabrali ste opciju 6 - LISTIC\nKreirat će se listić za loto 6 od 49.");
                        Listic();
                        Console.ReadKey();

                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("Izabrali ste opciju 7 - OSOBA\nMolim unesite podatke za 4 osobe:");
                            Console.ReadKey();
                            List<Osoba> osobe = new List<Osoba>();
                            //CultureInfo provider = CultureInfo.InvariantCulture
                            do
                            {
                                Osoba osoba = new Osoba();
                                Console.WriteLine("Unesite Ime osobe:");
                                osoba.FirstName = Console.ReadLine();
                                Console.WriteLine("Unesite Prezime osobe:");
                                osoba.LastName = Console.ReadLine();
                                Console.WriteLine("Unesite Datum rođenja osobe:");
                                string datumUnos = Console.ReadLine(); 
                                osoba.DOB = Convert.ToDateTime(datumUnos);
                                //bool isSuccessful = DateTime.TryParseExact(Console.ReadLine(), "dd/mm/yyyy", provider, DateTimeStyles.None, out osoba.DOB);                             
                                Console.WriteLine("Unesite: m ukoliko je osoba muško, f za žensko:");
                                osoba.Gender = Console.ReadLine().ToLower();
                                osobe.Add(osoba);
                            } 
                            while (osobe.Count < 4);
                            Console.WriteLine(Osoba(osobe));
                            Console.ReadKey();
                            
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");
                            
                        }
                        break;
                    case 8:
                        Console.WriteLine("Izabrali ste opciju 8 - PDF\nIzgenerirat će se novi dokument s Loto brojevima iz opcije 5.");
                        PdfGenerator(Loto());
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Neispravan unos, pokušajte ponovno.");
                Console.ReadKey();
                Console.Clear();
                Main(args);
            }
            Console.Clear();
            Main(args);


            string Parnost(double userNumber)
            {
                string result;
                result = userNumber % 2 == 0 ? $"Broj {userNumber} je paran broj" : $"Broj {userNumber} nije paran broj";
                return result;
            }

            string Kvadatna(float a, float b, float c)
            {
                double diskriminanta;
                double nazivnik;
                double x1;
                double x2;
                string result = $"Rješenje kvadratne jednadžbe za a={a}, b={b}, c={c} je:\n";
                if (a == 0)
                {
                    x1 = -c / b;
                    return result + $"x = {x1}";
                }
                else
                {
                    diskriminanta = (b * b) - (4 * a * c);
                    nazivnik = 2 * a;
                    if (diskriminanta > 0)
                    {
                        x1 = (-b / nazivnik) + (Math.Sqrt(diskriminanta) / nazivnik);
                        x2 = (-b / nazivnik) - (Math.Sqrt(diskriminanta) / nazivnik);
                        return result + $"x1={x1}, x2={x2}";
                    }
                    else if (diskriminanta == 0)
                    {
                        x1 = -b / nazivnik;
                        return result + $"x1={x1}";
                    }
                    else
                    {
                        x1 = -b / nazivnik;
                        x2 = ((Math.Sqrt(4 * a * c) - (b * b))) / nazivnik;
                        return result + $"prvo rješenje: x1={x1} + +i + x2={x2}\ndrugo rješenje: x1={x1} + -i + x2={x2} ";
                    }
                }
            }

            string Prosjek(List<double> grades)
            {
                double average = Queryable.Average(grades.AsQueryable());
                string opisnaOcjena = average >= 1.5 ? average >= 2.5 ? average >= 3.5 ? average >= 4.5 ? "odličan 5" : "vrlo dobar 4" : "dobar 3" : "dovoljan 2" : "nedovoljan 1";
                return $"Prosjek ocjena je: {average:0.00}, ocjena {opisnaOcjena} ";
            }

            string Znamenke(List<int> numbers)
            {
                List<int> znamenke = new List<int>();
                int znamenkeZbroj = 0;
                foreach (int number in numbers)
                {
                    int posljednjaZnamenka = number % 10;
                    znamenke.Add(posljednjaZnamenka);
                    znamenkeZbroj += posljednjaZnamenka;
                }
                string listaZnamenaka = "";
                foreach (int znamenka in znamenke)
                {
                    listaZnamenaka += znamenka + ", ";
                }
                return $"Posljednje znamenke unesenih brojeva su: {listaZnamenaka}, a njihov zbroj iznosi: {znamenkeZbroj}";
            }

            string Loto()
            {
                List<int> izvuceniBrojevi = new List<int>();
                do
                {
                    int izvuceniBroj = new Random().Next(1, 49);

                    while (NumberInList(izvuceniBrojevi, izvuceniBroj))
                    {
                        izvuceniBroj = new Random().Next(1, 49);
                    }
                    izvuceniBrojevi.Add(izvuceniBroj);

                } while (izvuceniBrojevi.Count < 7);
                string dobitniBrojevi = "";
                foreach (int izvuceniBroj in izvuceniBrojevi)
                {
                    dobitniBrojevi += izvuceniBroj + ", ";
                }
                return dobitniBrojevi;
            }
            bool NumberInList(List<int> numbers, int numberToCheck)
            {
                if (numbers.Contains(numberToCheck))
                {
                    return true;
                }
                return false;
            }

            string Osoba(List<Osoba> osobe)
            {

                Osoba najstarijaOsoba = osobe.OrderByDescending(o => o.DOB).LastOrDefault();
                Osoba najmladjaOsoba = osobe.OrderByDescending(o => o.DOB).FirstOrDefault();
                int brojZena = osobe.Count(o => o.Gender == "f");
                int brojMuskaraca = osobe.Count(o => o.Gender == "m");
                int osobeDvadesetoSt = osobe.Count(o => o.DOB.Year < 2000);

                return $"Najstarija osoba je: {najstarijaOsoba.FirstName} {najstarijaOsoba.LastName}\nnajmlađa osoba je:{najmladjaOsoba.FirstName} {najmladjaOsoba.LastName}\nbroj muškaraca: {brojMuskaraca}\nbroj zena: {brojZena}\n broj osoba rođenih prije 2000. : {osobeDvadesetoSt}";
            }

            void Listic()
            {
                string folderPath = "C:\\Users\\Barbara\\Documents\\C-Ponavljanje-ConsoleApp\\LotoListic";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = "listic.txt";
                string filePath = $"{folderPath}\\{fileName}";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open))
                    {
                        stream.Flush();
                        stream.Close();
                    }
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Loto listic 6 od 49\n");
                        long[,] arrayOfNumbers = new long[7, 7] { { 1, 2, 3, 4, 5, 6, 7 }, { 8, 9, 10, 11, 12, 13, 14 }, { 15, 16, 17, 18, 19, 20, 21 }, { 22, 23, 24, 25, 26, 27, 28 }, { 29, 30, 31, 32, 33, 34, 35 }, { 36, 37, 38, 39, 40, 41, 42 }, { 43, 44, 45, 46, 47, 48, 49 } };
                        int rowLength = arrayOfNumbers.GetLength(0);
                        int columnLength = arrayOfNumbers.GetLength(1);
                        for (int i = 0; i < rowLength; i++)
                        {
                            for (int j = 0; j < columnLength; j++)
                            {
                                writer.Write("{0}\t", arrayOfNumbers[i, j]);
                            }
                            writer.Write(Environment.NewLine + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

            void PdfGenerator(string inputString)
            {

                string folderPath = "C:\\Users\\Barbara\\Documents\\C-Ponavljanje-ConsoleApp\\PDFDocument";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string pdfFileName = "LotoNumbers.pdf";
                string pdfFilePath = $"{folderPath}\\{pdfFileName}";
                PdfService.GenerateNewPdfFileFromString(pdfFilePath, inputString);
            }


        }
        
    }

}

using System;
using System.Threading;

namespace ANapredno
{
    internal class Program
    {
        public delegate void DelegatRecenica(string recenica);



        static void Main(string[] args)
        {
            Zadatak1();

            Zadatak2();

            Zadatak3();
        }

        class Osoba
        {
            public event EventHandler ImePromijenjeno;

            private string ime;

            public string Ime
            {
                get { return ime; }
                set
                {
                    ime = value;
                    ImePromijenjeno?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        class Racun
        {
            public event EventHandler StanjePromijenjeno;

            private double stanje;

            public double Stanje
            {
                get { return stanje; }
                set
                {
                    stanje = value;
                    StanjePromijenjeno?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public class Semafor
        {
            public event Action PaljenjeSvjetla;
            public event Action GasenjeSvjetla;

            public void Paljenje()
            {
                PaljenjeSvjetla?.Invoke();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ZELENO");
                Console.ResetColor();
            }

            public void Gasenje()
            {
                GasenjeSvjetla?.Invoke();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRVENO");
                Console.ResetColor();
            }
        }

        private static void Zadatak1()
        {
            DelegatRecenica del = VelikaSlova;
            del += MalaSlova;
            del += Duljina;

            Console.WriteLine("Upiši jednu rečenicu:");
            string recenica = Console.ReadLine();
            Console.WriteLine("\nUpisali ste: \n" + recenica);

            del(recenica);

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak2()
        {
            Osoba osoba = new Osoba();
            osoba.Ime = "Štef";
            Console.WriteLine($"Početno ime osobe: {osoba.Ime}");

            Racun racun = new Racun();
            racun.Stanje = 0.90;
            Console.WriteLine($"Početno stanje računa: {racun.Stanje}");

            osoba.ImePromijenjeno += (sender, e) =>
            {
                Console.WriteLine($"Ime osobe promijenjeno: {osoba.Ime}");
            };

            racun.StanjePromijenjeno += (sender, e) =>
            {
                Console.WriteLine($"Stanje računa promijenjeno: {racun.Stanje}");
            };

            Console.Write("\nUnesite ime osobe: ");
            string ime = Console.ReadLine();
            osoba.Ime = ime;

            double stanje;
            bool validanUnos = false;

            while (!validanUnos)
            {
                Console.Write("\nUnesite stanje računa: ");
                string unosStanja = Console.ReadLine();

                if (double.TryParse(unosStanja, out stanje))
                {
                    racun.Stanje = stanje;
                    validanUnos = true;
                }
                else
                {
                    Console.WriteLine("Neispravan unos. Molimo unesite decimalni broj.");
                }
            }

            osoba.ImePromijenjeno += (sender, e) =>
            {
                Console.WriteLine($"Ime osobe promijenjeno: {osoba.Ime}");
            };

            racun.StanjePromijenjeno += (sender, e) =>
            {
                Console.WriteLine($"Stanje računa promijenjeno: {racun.Stanje}");
            };

            Console.ReadKey();
            Console.Clear();

        }

        private static void Zadatak3()
        {
            //Semofor 1 i 2 su na pravcu a, a semafor 3 i 4 su na pravcu b!

            Semafor semafor1 = new Semafor();
            Semafor semafor2 = new Semafor();
            Semafor semafor3 = new Semafor();
            Semafor semafor4 = new Semafor();

            semafor1.PaljenjeSvjetla += () => Console.WriteLine("Semafor 1.");
            semafor2.PaljenjeSvjetla += () => Console.WriteLine("Semafor 2.");
            semafor3.PaljenjeSvjetla += () => Console.WriteLine("Semafor 3.");
            semafor4.PaljenjeSvjetla += () => Console.WriteLine("Semafor 4.");
            semafor1.GasenjeSvjetla += () => Console.WriteLine("Semafor 1.");
            semafor2.GasenjeSvjetla += () => Console.WriteLine("Semafor 2.");
            semafor3.GasenjeSvjetla += () => Console.WriteLine("Semafor 3.");
            semafor4.GasenjeSvjetla += () => Console.WriteLine("Semafor 4.");

            Console.WriteLine("Semafor");

            for (int i = 0; i < 10; i++)
            {
                semafor1.Paljenje();
                semafor2.Paljenje();
                semafor3.Gasenje();
                semafor4.Gasenje();

                Console.WriteLine("\n");
                Thread.Sleep(1000);

                semafor1.Gasenje();
                semafor2.Gasenje();
                semafor3.Paljenje();
                semafor4.Paljenje();

                Console.WriteLine("\n");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Kraj.");

            Console.ReadKey();
        }

        static void VelikaSlova(string recenica)
        {
            Console.WriteLine($"\nSve veliko: {recenica.ToUpper()}");
        }

        static void MalaSlova(string recenica)
        {
            Console.WriteLine($"\nSve malo: {recenica.ToLower()}");
        }

        static void Duljina(string recenica)
        {
            Console.WriteLine($"\nBroj znakova: {recenica.Length}");
        }

    }
}
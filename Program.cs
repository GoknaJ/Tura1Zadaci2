using System;
using System.Collections.Generic;
using System.Linq;
using Tura1Zadaci2;

namespace ANapredno
{
    public static class BankovniRacunEkstenzija
    {
        public static void ProvjeraStanja(this double stanje)
        {
            if (stanje < 0)
            {
                throw new InvalidOperationException("Stanje ne može biti manje od 0!");
            }
            else if (stanje == 0)
            {
                Console.WriteLine("Upozorenje: stanje računa je 0.");
            }
            else if (stanje > 0)
            {
                Console.WriteLine("Stanje uredu.");
            }
        }

        public static bool TryXXXProvjeraStanja(this double stanje)
        {
            if (stanje < 0)
            {
                return false;
            }
            else if (stanje == 0)
            {
                Console.WriteLine("Upozorenje: stanje računa je 0.");
            }
            return true;
        }

    }

    internal class Program
    {
        public delegate void AnonimniDelegat(int brojevi);

        static void Main(string[] args)
        {
            //Napisati program koji kreira anonimni tip sastavljen od anonimnih tipova. Ispisati rezultat.
            Zadatak1();

            //Navesti u programu anonimni tip koji gradi listu anonimnih tipova i pretražuje po jednom od kriterija (predikati ili funkcije)
            Zadatak2();

            //Implementirati delegat koji definira anonimnu metodu za ispis brojeva i koja koristi lokalnu varijablu iz pozivne metode.
            Zadatak3();

            //Izraditi lokalnu metodu koja se poziva u rekurziji za ispis obiteljskog stabla(npr. izvor podataka neka bude lista objekata roditelj-dijete).
            Zadatak4();

            //Napisati ektenziju tipa double za provjeru stanja u banci - ukoliko je manji od 0 izbaciti exception, ukoliko je jednak 0 ispisati upozorenje.
            //Dodatno: varijacija metode sa TryXXX  koja izbacuje bool ako je iznos ispod nule.
            Zadatak5();

            //Kreirati ekstenziju tipa string za brojanje riječi u rečenici - metoda treba vratiti rezultat tipa int.
            //Kreirati posebnu datoteku za ekstenzije tog tipa po konvenciji(**Extensions.cs).
            Zadatak6();
        }

        private static void Zadatak1()
        {
            var osoba = new
            {
                Ime = "Pero",
                Prezime = "Perić",
                Adresa = new
                {
                    Ulica = "Glavna cesta 2",
                    Grad = "Zagreb",
                    Drzava = "Hrvatska"
                },
                BrojMobitela = new[]
                            {
                    new
                    {
                        Vrsta = "Privatni",
                        Broj = "095/555 555"
                    },
                    new
                    {
                        Vrsta = "Poslovni",
                        Broj = "091/111 111"
                    }
                },
            };

            Console.WriteLine("Ime: " + osoba.Ime);
            Console.WriteLine("Prezime: " + osoba.Prezime);
            Console.WriteLine("Adresa:");
            Console.WriteLine("\tUlica: " + osoba.Adresa.Ulica + "\n\tGrad: " + osoba.Adresa.Grad + "\n\tDržava: " + osoba.Adresa.Drzava);
            Console.WriteLine("Broja mobitela:");
            foreach (var brojMob in osoba.BrojMobitela)
            {
                Console.WriteLine("\t" + brojMob.Vrsta + ": " + brojMob.Broj);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak2()
        {
            var osobe = new[]
                        {
                new { Ime = "Pero", Dob = 25, Zanimanje = "Dizajner" },
                new { Ime = "Ana", Dob = 30, Zanimanje = "Dizajner" },
                new { Ime = "Marko", Dob = 22, Zanimanje = "Student" },
                new { Ime = "Ivan", Dob = 20, Zanimanje = "Student" },
                new { Ime = "Ratko", Dob = 40, Zanimanje = "Profesor" }
            };

            Console.WriteLine("Ispis svih osoba:");

            foreach (var osoba in osobe)
            {                
                Console.WriteLine($"\t{osoba.Ime} ({osoba.Dob}) - {osoba.Zanimanje}");
            }

            var starost = osobe.Where(godine => godine.Dob > 30);

            Console.WriteLine("\nIspis svih osoba starijih od 30:");
            foreach (var osoba in starost)
            {
                Console.WriteLine($"\t{osoba.Ime} ({osoba.Dob}) - {osoba.Zanimanje}");
            }

            var okupacija = osobe.Where(student => student.Zanimanje == "Student");

            Console.WriteLine("\nIspis svih studenta:");
            foreach (var osoba in okupacija)
            {
                Console.WriteLine($"\t{osoba.Ime} ({osoba.Dob}) - {osoba.Zanimanje}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak3()
        {
            int broj = 5;

            Console.WriteLine("Delegat s anonimnom metodom ispisa brojeva preko lokalne varijable iz pozivne metode:");

            AnonimniDelegat anonimniDelegat = delegate (int brojevi)
            {
                Console.WriteLine($"{brojevi} od {broj}");
            };

            for (int i = 0; i <= broj; i++)
            {
                anonimniDelegat(i);
            }

            Console.ReadKey();
            Console.Clear();
        }

        public class Roditelj
        {
            public string Ime { get; set; }
            public List<Roditelj> Dijete { get; set; }

            public Roditelj(string ime)
            {
                Ime = ime;
                Dijete = new List<Roditelj>();
            }
        }

        private static void Zadatak4()
        {
            Console.WriteLine("Ispis obitelskog staba roditelj - dijete:\n");

            List<Roditelj> obitelj = new List<Roditelj>
            {
                new Roditelj("Pero")
                {                    
                        Dijete = new List<Roditelj>
                            {
                                new Roditelj("Marko"),
                                new Roditelj("Ana")
                            }
                },
                new Roditelj("Ivana")
                {
                    Dijete = new List<Roditelj>
                    {
                        new Roditelj("Ena"),
                        new Roditelj("Igor")
                    }
                }
            };

            IspisiObiteljskoStablo(obitelj, 0);

            Console.ReadKey();
            Console.Clear();
        }

        private static void IspisiObiteljskoStablo(List<Roditelj> osobe, int dijete)
        {
            foreach (var osoba in osobe)
            {
                IspisiRazinu(dijete);
                Console.WriteLine(osoba.Ime);

                if (osoba.Dijete != null && osoba.Dijete.Count > 0)
                {
                    IspisiObiteljskoStablo(osoba.Dijete, dijete + 1);
                }
            }
        }

        private static void IspisiRazinu(int razina)
        {
            for (int i = 0; i < razina; i++)
            {
                Console.Write("  ");
            }
        }

        private static void Zadatak5()
        {
            Console.WriteLine("Unesi stanje računa: ");
            double stanje = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nTry Catch provjera.");

            try
            {
                Console.WriteLine("Iznos u redu.");
                stanje.TryXXXProvjeraStanja();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Greška: {ex.Message}");
            }

            Console.WriteLine("\nProvjera stanja preko ektenzije.");

            stanje.ProvjeraStanja();

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak6()
        {
            Console.Write("Upiši rečenicu: ");
            string recenica = Console.ReadLine();

            int brojRijeci = recenica.BrojiRijeci();

            Console.WriteLine($"Rečenica sadrži {brojRijeci} riječi.");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace ANapredno
{
    internal class Program
    {
        public delegate bool DelegatOsoba(Osoba osoba);

        static void Main(string[] args)
        {
            //Poigrati se sa pozivnim metodama nad nizovima teksta i brojeva na način da se koriste parametri u vidu delegata.
            //Primjeri: int.Select(), string.FindAll().
            Zadatak1();

            //Kreirati objekt tipa List<T>, gdje je T neka klasa osobe koja ima svojsta po kojim se može pretraživati.
            //Potrebno je pretražiti po jednom kriteriju te sortirati podatke po svim svojstvima.
            Zadatak2();

            //Napraviti jednu akciju (Action) i funkciju (Func) te ih pozvati iz pozivne klase.
            Zadatak3();
        }

        private static void Zadatak1()
        {
            int[] brojevi = { 1, 2, 3, 4, 5 };

            var brojeviNa2 = brojevi.Select(x => x * x);

            Console.WriteLine("Brojevi na kvadrat:");
            foreach (int broj in brojeviNa2)
            {
                Console.WriteLine(broj);
            }

            string[] rijeci = { "pozdrav", "bok", "dobar dan", "dobro jutro", "dobra večer", "laku noć", "ciao", "hello" };

            string[] rijeciSaa = Array.FindAll(rijeci, s => s.Contains("a"));

            Console.WriteLine("\nRiječi s 'a':");
            foreach (string rijec in rijeciSaa)
            {
                Console.WriteLine(rijec);
            }

            Console.ReadKey();
            Console.Clear();
        }
        public class Osoba
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
        }

        private static void Zadatak2()
        {
            List<Osoba> osobe = new List<Osoba>
            {
                new Osoba { Ime = "Ana", Prezime = "Anić" },
                new Osoba { Ime = "Ivan", Prezime = "Ivić" },
                new Osoba { Ime = "Pero", Prezime = "Perić" },
                new Osoba { Ime = "Ivo", Prezime = "Ivić" },
                new Osoba { Ime = "Jana", Prezime = "Ivić" },
                new Osoba { Ime = "Marko", Prezime = "Ivanović" },
                new Osoba { Ime = "Josip", Prezime = "Ivanić" }
            };

            DelegatOsoba slovoPrezimena = osoba => osoba.Prezime.StartsWith("I");

            List<Osoba> filtrirajOsobe = new List<Osoba>();
            foreach (var osoba in osobe)
            {
                if (slovoPrezimena(osoba))
                {
                    filtrirajOsobe.Add(osoba);
                }
            }

            for (int i = 0; i <= filtrirajOsobe.Count; i++)
            {
                for (int j = i + 1; j < filtrirajOsobe.Count; j++)
                {
                    if (string.Compare(filtrirajOsobe[i].Ime, filtrirajOsobe[j].Ime) > 0)
                    {
                        var x = filtrirajOsobe[i];
                        filtrirajOsobe[i] = filtrirajOsobe[j];
                        filtrirajOsobe[j] = x;
                    }
                }
            }

            Console.WriteLine("Filtrirane i sortirane osobe:");
            foreach (var osoba in filtrirajOsobe)
            {
                Console.WriteLine($"{osoba.Ime} {osoba.Prezime}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak3()
        {
            Akcija();

            int broj = 8;
            bool rezultat = Funkcija(broj);
            Console.WriteLine($"Pozvana funkcija za provjeru parnosti broja {broj}: {rezultat}");

            Console.ResetColor();
            Console.ReadKey();
        }

        public static void Akcija()
        {
            Console.WriteLine("Pozvana je akcija za bojanje teksta!");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static bool Funkcija(int broj)
        {
            return broj % 2 == 0;
        }
    }
}
using System;
using System.Collections.Generic;

namespace ANapredno
{
    internal class Program
    {
        public delegate bool DelegatOsoba(Osoba osoba);

        static void Main(string[] args)
        {
            Zadatak1();

            Zadatak2();

            Zadatak3();
        }

        public class Osoba
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
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

        private static void Zadatak1()
        {
            int[] brojevi = { 1, 2, 3, 4, 5 };

            int[] brojeviNa2 = Array.ConvertAll<int, int>(brojevi, x => x * x);

            Console.WriteLine("Brojevi na kvadrat:");
            foreach (int broj in brojeviNa2)
            {
                Console.WriteLine(broj);
            }

            // Create an array of strings
            string[] rijeci = { "pozdrav", "bok", "dobar dan", "dobro jutro", "dobra večer", "laku noć", "ciao", "hello" };

            // Use a lambda expression to find all strings that contain the substring "o"
            string[] wordsWithO = Array.FindAll(rijeci, s => s.Contains("a"));

            Console.WriteLine("\nRiječi s 'a':");
            foreach (string word in wordsWithO)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
            Console.Clear();
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
    }
}
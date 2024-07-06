using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ANapredno
{
    class MojaIznimka : Exception
    {
        public MojaIznimka(string poruka) : base(poruka)
        {
            // kod...
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            //Učiniti program robustnijim s obzirom na operaciju dijeljena s nulom
            //Zadatak1();

            //Reproducirati jednu grešku koju treba razriješiti sa hvatanjem bar 3 različita tipa iznimka (npr. otvaranje datoteke, inicijalizacija tipova i sl.)
            Zadatak2();

            //Napisati klasu koja hvata sve poznate (i nepoznate) iznimke te baca svoji vlastiti tip iznimke
            //Zadatak3();
        }

        private static void Zadatak1()
        {
            int broj = 10;
            int nula = 0;

            try
            {
                int rezultat = broj / nula;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Greška: {ex.Message}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak2()
        {
            try
            {
                using (var fileStream = new FileStream("NepostojeciTekst.txt", FileMode.Open))
                {
                    // Kod...
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Greška pri otvaranju datoteke: {ex.Message}");
            }

            Console.ReadKey();

            try
            {
                string ime = null;
                int duzinaImena = ime.Length;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"\nGreška pri inicijalizaciji tipa: {ex.Message}");
            }

            Console.ReadKey();

            try
            {
                throw new Exception("Ovo je opća iznimka.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOpća iznimka: {ex.Message}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private static void Zadatak3()
        {
            try
            {
                throw new Exception("Ovo je testna iznimka!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uhvaćena iznimka: {ex.Message}");

                try
                {
                    throw new MojaIznimka("Moja vlastita iznimka!");
                }
                catch (MojaIznimka mojaEx)
                {
                    Console.WriteLine($"Uhvaćena moja iznimka: {mojaEx.Message}");
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
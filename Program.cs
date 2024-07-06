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
            Zadatak1();

            //Reproducirati jednu grešku koju treba razriješiti sa hvatanjem bar 3 različita tipa iznimka (npr. otvaranje datoteke, inicijalizacija tipova i sl.)
            //Zadatak2();

            //Napisati klasu koja hvata sve poznate (i nepoznate) iznimke te baca svoji vlastiti tip iznimke
            Zadatak3();
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
            List<string> lista = new List<string>
                {
                    "Pero",
                    "Iva",
                    "Marko"
                };

            try
            {
                string nepostojecaDatoteka = "ne_postoji.txt";
                File.OpenRead(nepostojecaDatoteka);

                Console.WriteLine(lista[3]);

                int broj = 0;
                int rezultat = 10 / broj;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Datoteka nije pronađena: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Greška: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greška aritmetičke operacije: " + ex.Message);
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tura1Zadaci2;

namespace ANapredno
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Zadatak1();

            //Zadatak2();

            //Zadatak3();

            //Zadatak4();

            Zadatak5();
        }

        private static void Zadatak5()
        {
            Dictionary<string, int> rijecnik = new Dictionary<string, int>();

            rijecnik.Add("Pero" ,1);
            rijecnik.Add("Marko", 2);
            rijecnik.Add("Iva", 3);
            rijecnik.Add("Lana", 4);
            rijecnik.Add("Miro", 5);
            rijecnik.Add("Ivo", 6);

            foreach (var osoba in rijecnik)
            {
                Console.WriteLine($"Ključ: {osoba.Key}, Vrijednost: {osoba.Value}");
            }

            Console.ReadKey();
        }

        private static void Zadatak4()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("\n");
            builder.Append("Dobra večer! ");
            builder.AppendFormat("Ovo je {0} primer {1} StringBuilder-a.", "jednostavan", "klase");
            builder.AppendLine();
            builder.AppendLine("Ovo je novi redak.");
            builder.Append("Ovo je još jedan tekst koji se dodaje na kraj.");
            builder.Insert(0, " Poštovani, \n");
            builder.Replace("primer", "primjer");
            builder.AppendLine("\n");
            builder.Append("\t\t\t\tOvo je potpis.");

            Console.WriteLine(builder.ToString());

            Console.ReadKey();
        }

        private static void Zadatak3()
        {
            //Queue<T>
            Queue<string> red = new Queue<string>();

            red.Enqueue("Jabuka");
            red.Enqueue("Kruška");
            red.Enqueue("Šljiva");

            Console.WriteLine("Jabuka, Kruška, Šljiva");

            string prviElement = red.Dequeue();
            Console.WriteLine($"Prvi red: {prviElement}");

            string sljedećiElement = red.Peek();
            Console.WriteLine($"Sljedeći red: {sljedećiElement}");

            //Stack<T>
            Stack<string> stog = new Stack<string>();

            stog.Push("1. mjesto");
            stog.Push("2. mjesto");
            stog.Push("3. mjesto");

            Console.WriteLine("\n1, 2, 3. mjesto");

            string zadnjiElement = stog.Pop();
            Console.WriteLine($"Zadnji stog: {zadnjiElement}");

            string prethodniElement = stog.Peek();
            Console.WriteLine($"Prethodni stog: {prethodniElement}");

            Console.ReadKey();
        }

        private static void Zadatak2()
        {
            Osoba[] osobe = new Osoba[]
                        {
                new Osoba { Dob = 30 },
                new Osoba { Dob = 25 },
                new Osoba { Dob = 40 }
                        };

            Array.Sort(osobe);

            foreach (var osoba in osobe)
            {
                Console.WriteLine($"Dob: {osoba.Dob}");
            }

            Console.ReadKey();
        }

        private static void Zadatak1()
        {
            var osoba1 = new Osoba
            {
                Dob = 20
            };

            var osoba2 = new Osoba
            {
                Dob = 20
            };

            Console.WriteLine($"Jesu li osobe jednake(Equals)? {osoba1.Equals(osoba2)}");

            Console.WriteLine($"Jesu li osobe jednake(==)? {osoba1 == osoba2}");

            Console.ReadKey();
        }
    }
}
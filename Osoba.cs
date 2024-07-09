using System;

namespace Tura1Zadaci2
{
    public class Osoba : IEquatable<Osoba>, IComparable<Osoba>
    {
        public int Dob {  get; set; }

        public int CompareTo(Osoba other)
        {
            if (other == null) return 1;
            return Dob.CompareTo(other.Dob);
        }

        public bool Equals(Osoba other)
        {
            if (other == null) return false;
            return Dob == other.Dob;
        }

        public static bool operator ==(Osoba osoba1, Osoba osoba2)
        {
            if (((object)osoba1) == null || ((object)osoba2) == null)
                return Equals(osoba1, osoba2);

            return osoba1.Equals(osoba2);
        }

        public static bool operator !=(Osoba osoba1, Osoba osoba2)
        {
            if (((object)osoba1) == null || ((object)osoba2) == null)
                return !Equals(osoba1, osoba2);

            return !(osoba1 == osoba2);
        }
    }
}

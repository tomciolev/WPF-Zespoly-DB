using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public abstract class Osoba
    {
        public enum Plcie { K, M }

        private string imie;
        private string nazwisko;
        private DateTime dataUrodzenia;
        private string pesel;
        private Plcie plec;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public Plcie Plec { get => plec; set => plec = value; }

        public Osoba()
        {
            Pesel = new string('0', 11);
        }
        public Osoba(string imie, string nazwisko) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec)
            : this(imie, nazwisko)
        {
            DateTime date;
            if (DateTime.TryParseExact(dataUrodzenia, new string[] { "dd/MM/yyyy", "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd" }, null, DateTimeStyles.None, out date))
                DataUrodzenia = date;
            Pesel = pesel;
            Plec = plec;
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(Imie).Append(" ").Append(Nazwisko).Append(" ").Append(DataUrodzenia.ToString("dd.MM.yyyy")).Append(" ").Append(Pesel).Append(" ").Append(Plec).Append(" ");
            return info.ToString();
        }
    }
}

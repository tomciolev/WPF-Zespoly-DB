using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public class CzlonekZespolu : Osoba
    {
        DateTime dataZapisu;
        string funkcja;

        public DateTime DataZapisu { get => dataZapisu; set => dataZapisu = value; }
        public string Funkcja { get => funkcja; set => funkcja = value; }

        public CzlonekZespolu() : base() { }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, string dataZapisu, string funkcja) 
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DateTime date;
            if (DateTime.TryParseExact(dataZapisu, new string[] { "dd/MM/yyyy", "dd.MM.yyyy", "dd-MM-yyyy", "dd-MMM-yyyy", "dd.MMM.yyyy", "dd/MMM/yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd" }, null, DateTimeStyles.None, out date))
                DataZapisu = date;
            Funkcja = funkcja;
        }
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(Imie).Append(" ").Append(Nazwisko).Append(" ").Append(DataUrodzenia.ToString("dd.MM.yyyy")).Append(" ").Append(Pesel).Append(" ").Append(Plec).Append(" ").Append(DataZapisu.ToString("dd.MM.yyyy")).Append(" ").Append(Funkcja);
            return info.ToString();
        }
    }
}

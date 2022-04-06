using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public class KierownikZespolu : Osoba
    {
        int doswiadczenie;

        public int Doswiadczenie { get => doswiadczenie; set => doswiadczenie = value; }

        public KierownikZespolu() : base() { }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, Plcie plec, int doswiadczenie) 
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            Doswiadczenie = doswiadczenie;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(Imie).Append(" ").Append(Nazwisko).Append(" ").Append(DataUrodzenia.ToString("dd.MM.yyyy")).Append(" ").Append(Pesel).Append(" ").Append(Plec).Append(" ").Append(doswiadczenie);
            return info.ToString();
        }
    }
}

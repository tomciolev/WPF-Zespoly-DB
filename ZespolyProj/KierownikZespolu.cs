using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public class KierownikZespolu : Osoba
    {
        int doswiadczenie;

        [Key]
        public int KierownikId { get; set; }
        public int Doswiadczenie { get => doswiadczenie; set => doswiadczenie = value; }
        public Zespol Zespol { get; set; }
        public int ZespolId { get; set; }

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


        private static ZespolContext _context = new ZespolContext();
        public static void dodajKierownika(KierownikZespolu kierownik)
        {
            _context.Kierownik.Add(kierownik);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public class Zespol
    {
        int liczbaCzlonkow;
        string nazwa;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        [Key]
        public int ZespolId { get; set; }
        public int LiczbaCzlonkow { get => liczbaCzlonkow; set => liczbaCzlonkow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }

        public Zespol()
        {
            Nazwa = null;
            Kierownik = null;
            LiczbaCzlonkow = 0;
            Czlonkowie = new List<CzlonekZespolu>();
        }
        public Zespol(string nazwa, KierownikZespolu kierownik) : this()
        {
            this.Nazwa = nazwa;
            this.Kierownik = kierownik;
        }
        private static ZespolContext _context = new ZespolContext();

        public static void dodajZespol(string nazwa, KierownikZespolu kierownik)
        {
            _context.Zespoly.Add(new Zespol(nazwa, kierownik));
            _context.SaveChanges();
        }
        public static void dodajCzlonka(CzlonekZespolu czlonek, int id)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.ZespolId == id);
            zespol.Czlonkowie.Add(czlonek);
            zespol.liczbaCzlonkow++;
            _context.SaveChanges();
        }
        public static void usunCzlonka(CzlonekZespolu czlonek, int id)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.ZespolId == id);
            zespol.liczbaCzlonkow--;
            _context.Czlonkowie.Remove(czlonek);
            _context.SaveChanges();
        }

    }
}

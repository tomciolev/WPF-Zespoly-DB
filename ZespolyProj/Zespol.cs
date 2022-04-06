using Microsoft.EntityFrameworkCore;
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
        public static void dodajCzlonka(string PESEL, string nazwa)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == nazwa);
            zespol.Czlonkowie.Add(_context.Czlonkowie.SingleOrDefault(x => x.Pesel == PESEL));
            zespol.liczbaCzlonkow++;
            _context.SaveChanges();
        }
        public static void usunCzlonka(CzlonekZespolu czlonek, string nazwa)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == nazwa);
            zespol.liczbaCzlonkow--;
            _context.Czlonkowie.Remove(czlonek);
            _context.SaveChanges();
        }
        public static void usunCzlonka(string PESEL, string nazwa)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == nazwa);
            zespol.liczbaCzlonkow--;
            _context.Czlonkowie.Remove(_context.Czlonkowie.SingleOrDefault(x => x.Pesel == PESEL));
            _context.SaveChanges();
        }
        public static void usunWszystkichCzlonkow(string nazwa)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == nazwa);
            zespol.liczbaCzlonkow = 0;
            foreach(CzlonekZespolu czlonek in _context.Czlonkowie.Where(x => x.Zespol.Nazwa == nazwa))
            {
                _context.Czlonkowie.Remove(czlonek);
            }
            _context.SaveChanges();
        }
        public static List<CzlonekZespolu> zwrocCzlonkowZespolu(string nazwa)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == nazwa);
            return zespol.Czlonkowie;
        }
        public static List<string> zwrocNazwyZespolow()
        {
            return _context.Zespoly.Select(x => x.Nazwa).ToList();
        }
        public static Zespol zwrocCalyZespol(string nazwa)
        {
            return _context.Zespoly.Where(z => z.Nazwa == nazwa).Include(zespol => zespol.Kierownik).Include(zespol =>
               zespol.Czlonkowie).FirstOrDefault();
        }
    }
}

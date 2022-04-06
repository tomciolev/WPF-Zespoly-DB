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
        public void dodajCzlonka(CzlonekZespolu czlonek)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == this.Nazwa);
            zespol.Czlonkowie.Add(czlonek);
            zespol.liczbaCzlonkow++;
            _context.SaveChanges();
        }
        public void usunCzlonka(CzlonekZespolu czlonek)
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == this.Nazwa);
            zespol.liczbaCzlonkow--;
            _context.Czlonkowie.Remove(czlonek);
            _context.SaveChanges();
        }
        public void usunWszystkichCzlonkow()
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == this.Nazwa);
            zespol.liczbaCzlonkow = 0;
            foreach(CzlonekZespolu czlonek in _context.Czlonkowie.Where(x => x.Zespol.Nazwa == this.Nazwa))
            {
                _context.Czlonkowie.Remove(czlonek);
            }
            _context.SaveChanges();
        }
        public List<CzlonekZespolu> zwrocCzlonkowZespolu()
        {
            var zespol = _context.Zespoly.SingleOrDefault(x => x.Nazwa == this.Nazwa);
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
        public void zapiszKierownika()
        {
            _context.SaveChanges();
        }
    }
}

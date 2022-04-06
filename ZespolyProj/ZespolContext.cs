using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolyProj
{
    public class ZespolContext : DbContext
    {
        public DbSet<CzlonekZespolu> Czlonkowie { get; set; }
        public DbSet<KierownikZespolu> Kierownik { get; set; }
        public DbSet<Zespol> Zespoly { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=ZespolyDataBase;Integrated Security=True");
        }
    }
}

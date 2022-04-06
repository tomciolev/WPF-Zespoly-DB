using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZespolyProj;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        Osoba osoba;
        public OsobaWindow()
        {
            InitializeComponent();
            txtFunkcja.IsEnabled = false;
            txtDoswiadczenie.IsEnabled = false;
        }
        public OsobaWindow(Osoba os) : this()
        {
            osoba = os;
            if(osoba is KierownikZespolu kierownik)
            {
                txtDoswiadczenie.IsEnabled = true;
                txtPesel.Text = kierownik.Pesel;
                txtImie.Text = kierownik.Imie;
                txtNazwisko.Text = kierownik.Nazwisko;
                txtDataUr.Text = $"{kierownik.DataUrodzenia:dd-MMM-yyyy}";
                txtDoswiadczenie.Text = kierownik.Doswiadczenie.ToString();
                cmbPlec.Text = (kierownik.Plec == Osoba.Plcie.K) ? "Kobieta" : "Mężczyzna";
            }
            else
            {
                txtFunkcja.IsEnabled = true;
            }
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (osoba is KierownikZespolu)
            {
                ((KierownikZespolu)osoba).Doswiadczenie = int.Parse(txtDoswiadczenie.Text);
            }
            if (osoba is CzlonekZespolu)
            {
                ((CzlonekZespolu)osoba).Funkcja = txtFunkcja.Text;
            }
            osoba.Pesel = txtPesel.Text;
            osoba.Imie = txtImie.Text;
            osoba.Nazwisko = txtNazwisko.Text;
            DateTime.TryParseExact(txtDataUr.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
            osoba.DataUrodzenia = date;
            if (cmbPlec.Text == "Kobieta")
                osoba.Plec = Osoba.Plcie.K;
            else
                osoba.Plec = Osoba.Plcie.M;
            DialogResult = true; 
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

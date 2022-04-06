using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy ZespolWindow.xaml
    /// </summary>
    public partial class ZespolWindow : Window
    {
        Zespol zespol;
        public ZespolWindow()
        {
            InitializeComponent();
            txtKierownikZespolu.IsEnabled = false;
        }
        public ZespolWindow(Zespol z) : this()
        {
            zespol = z;
        }

        private void btnDodajKierownika_Click(object sender, RoutedEventArgs e)
        {
            KierownikZespolu kierownik = new KierownikZespolu();
            OsobaWindow osobaWindow = new OsobaWindow(kierownik);
            bool? result = osobaWindow.ShowDialog();
            if (result == true)
            {
                zespol.Kierownik = kierownik;
                zespol.zapiszKierownika();
                txtKierownikZespolu.Text = zespol.Kierownik.ToString();
            }
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            zespol.Nazwa = txtNazwaZespolu.Text;
            DialogResult = true;
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZespolyProj;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Zespol zespol;
        public MainWindow()
        {
            InitializeComponent();
            cmbNazwy.ItemsSource = Zespol.zwrocNazwyZespolow();
        }

        private void lstNazwy_DropDownClosed(object sender, EventArgs e)
        {
            zespol = Zespol.zwrocCalyZespol(cmbNazwy.Text);
            if(zespol is object)
            {
                txtKierownik.Text = zespol.Kierownik.ToString();
                dataGrid1.ItemsSource = Zespol.zwrocCzlonkowZespolu(cmbNazwy.Text);     
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow osobaWindow = new OsobaWindow(cz);
            bool? result = osobaWindow.ShowDialog();
            if (result == true)
            {
                Zespol.dodajCzlonka(cz, 1);
                dataGrid1.ItemsSource = Zespol.zwrocCzlonkowZespolu(cmbNazwy.Text);
                dataGrid1.Items.Refresh();
            }
        }
    }
}

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
                dataGrid1.ItemsSource = zespol.zwrocCzlonkowZespolu();     
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow osobaWindow = new OsobaWindow(cz);
            bool? result = osobaWindow.ShowDialog();
            if (result == true)
            {
                zespol = Zespol.zwrocCalyZespol(cmbNazwy.Text);
                zespol.dodajCzlonka(cz);
                dataGrid1.ItemsSource = zespol.zwrocCzlonkowZespolu();
                dataGrid1.Items.Refresh();
            }
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex > -1)
            {
                for (int i = 0; i <= dataGrid1.SelectedItems.Count; i++)
                {
                    zespol.usunCzlonka((CzlonekZespolu)(dataGrid1.SelectedItem));
                    dataGrid1.ItemsSource = zespol.zwrocCzlonkowZespolu();
                    dataGrid1.Items.Refresh();
                }
            }
        }

        private void btnEdytuj_Click(object sender, RoutedEventArgs e)
        {
            zespol = Zespol.zwrocCalyZespol(cmbNazwy.Text);
            if(zespol is object)
            {
                OsobaWindow osobaWindow = new OsobaWindow(zespol.Kierownik);
                bool? result = osobaWindow.ShowDialog();
                if (result == true)
                {
                    zespol.zapiszKierownika();
                    txtKierownik.Text = zespol.Kierownik.ToString();
                }
            }
            
        }

        private void btnUsunWszystkich_Click(object sender, RoutedEventArgs e)
        {
            zespol.usunWszystkichCzlonkow();
            dataGrid1.ItemsSource = zespol.zwrocCzlonkowZespolu();
            dataGrid1.Items.Refresh();
        }

        private void btnDodajZespol_Click(object sender, RoutedEventArgs e)
        {
            Zespol zespol = new Zespol();
            ZespolWindow zespolWindow = new ZespolWindow(zespol);
            bool? result = zespolWindow.ShowDialog();
            if(result == true)
            {
                Zespol.dodajZespol(zespol);
                dataGrid1.ItemsSource = zespol.zwrocCzlonkowZespolu();
                dataGrid1.Items.Refresh(); 
            }
        }
    }
}

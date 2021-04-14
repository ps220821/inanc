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

namespace Fietswinkel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
          

        }
        private void btnbestel_Click(object sender, RoutedEventArgs e)
        {
            // haalt de combobox fiets op
            ComboBoxItem selected1 = fietsen.SelectedItem as ComboBoxItem;
         
            // haalt de combobox verzekeringen op
            ComboBoxItem selected2 = verzekeringen.SelectedItem as ComboBoxItem;

            // haalt de combobox services op
            ComboBoxItem selected3 = services.SelectedItem as ComboBoxItem;
          
            //haalt de aantal van de dagen op
            string antl = aantal.Text.ToString();
            int getal = Convert.ToInt32(antl);

            string pric = bedrag.Text.ToString();
            double plus = double.Parse(pric);

            if (selected1 != null)
            {
                string fiets = selected1.Content.ToString();
                string[] split = fiets.Split(' ');
                double number = double.Parse(split[2]);
                double optel = number * getal;
                double uitkomst = optel += plus;
                string price = Convert.ToString(uitkomst);
                bedrag.Text = price;

                
                lijst.Items.Add(fiets+" "+antl);
                verzekeringen.IsEnabled = true;
                services.IsEnabled = true;
                fietsen.SelectedIndex = -1;
                aantal.Text = "1";
            }
            else if (selected2 != null)
            {
                string verzekering = selected2.Content.ToString();
                string[] split2 = verzekering.Split(' ');
                double number2 = double.Parse(split2[2]);
                double optel2 = number2 * getal;
                double uitkomst2 = optel2 += plus;
                string price = Convert.ToString(uitkomst2);
                bedrag.Text = price;

                lijst.Items.Add(verzekering + " " + antl);
                fietsen.IsEnabled = true;
                services.IsEnabled = true;
                verzekeringen.SelectedIndex = -1;
                aantal.Text = "1";
            }
            else if (selected3 != null)
            {
                string service = selected3.Content.ToString();
                string[] split3 = service.Split(' ');
                double number3 = double.Parse(split3[2]);
                double optel3 = number3 * getal;
                double uitkomst3 = optel3 += plus;
                string price = Convert.ToString(uitkomst3);
                bedrag.Text = price;

                lijst.Items.Add(service + " " + antl);
                fietsen.IsEnabled = true;
                verzekeringen.IsEnabled = true;
                services.SelectedIndex = -1;
                aantal.Text = "1";
            }
         
        }

        private void fietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //de geslecteerde item word opgelsagen en word omgezet naar een string
            ComboBoxItem selected1 = fietsen.SelectedItem as ComboBoxItem;
            string value= aantal.Text.ToString();
            if (selected1 != null)
            {
                verzekeringen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void verzekeringen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selected2 = verzekeringen.SelectedItem as ComboBoxItem;
            if (selected2 != null)
            {
                fietsen.IsEnabled = false;
                services.IsEnabled = false;
            }
        }

        private void services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selected3 = services.SelectedItem as ComboBoxItem;
            if (selected3 != null)
            {
                fietsen.IsEnabled = false;
                verzekeringen.IsEnabled = false;
            }
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
           string pak = lijst.SelectedItem.ToString();
            string[] split = pak.Split(' ');
            double number = double.Parse(split[2]) * double.Parse(split[5]);

            string antl = bedrag.Text.ToString();
            int getal = Convert.ToInt32(antl);

            var result = MessageBox.Show("weet je zeker dat je de bestelling wilt verwijderen", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                double reken = getal - number;
                string uitkokmst = reken.ToString();
                bedrag.Text = uitkokmst;
                lijst.Items.Remove(pak); // verwijderd de selected item
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            int count = lijst.Items.Count;
            if (count >= 1)
            {
                var result = MessageBox.Show("is de bestelling al betaald?", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    lijst.Items.Clear();
                    bedrag.Text = "0,00";
                    fietsen.SelectedIndex = -1;
                    verzekeringen.SelectedIndex = -1;
                    services.SelectedIndex = -1;
                }
            }

        }
    }
}

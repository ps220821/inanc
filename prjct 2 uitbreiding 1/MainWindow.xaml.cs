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

namespace prjct_2_uitbreiding_1
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

        private void toevoegen_Click(object sender, RoutedEventArgs e)
        {
            string antl = dagen.Text.ToString();
            int getal = Convert.ToInt32(antl);
            string days = "dag";

            if (getal > 1)
            {
                days = "dagen";
            }
            double ttlbdrg = Convert.ToDouble(tbbedrag.Text);

            ComboBoxItem selected1 = fiets.SelectedItem as ComboBoxItem;
            ComboBoxItem selected2 = verzekering.SelectedItem as ComboBoxItem;
            ComboBoxItem selected3 = service.SelectedItem as ComboBoxItem;

            if (selected1 != null)
            {
                string fietsen = selected1.Content.ToString();

                string[] split = fietsen.Split(' ');
                double number = double.Parse(split[2]);
                double optel = number * getal;
                string price = Convert.ToString(optel);

                double uitkomst = optel += ttlbdrg;
                string totaal = Convert.ToString(uitkomst);
                tbbedrag.Text = totaal + ",00";

                
                items1.Items.Add(fietsen + " " + dagen.Text + " " + days + " €" + price + ",00");
            }

            else if (selected2 != null)
            {
                string verzekeringen = selected2.Content.ToString();

                string[] split = verzekeringen.Split(' ');
                double number2 = double.Parse(split[2]);
                double optel2 = number2 * getal;
                string price2 = Convert.ToString(optel2);

                double uitkomst2 = optel2 += ttlbdrg;
                string totaal2 = Convert.ToString(uitkomst2);
                tbbedrag.Text = totaal2 + ",00";

                items1.Items.Add(verzekeringen + " " + dagen.Text + " " + days + " €" + price2 + ",00");
            }
            else if(selected3 != null)
            {
                string servicen = selected3.Content.ToString();

                string[] split = servicen.Split(' ');
                double number3 = double.Parse(split[2]);
                double optel3 = number3 * getal;
                string price3 = Convert.ToString(optel3);

                double uitkomst3 = optel3 += ttlbdrg;
                string totaal3 = Convert.ToString(uitkomst3);
                tbbedrag.Text = totaal3+",00";

                items1.Items.Add(servicen + " " + dagen.Text + " " + days + " €" + price3 + ",00");
            }
        }
        
        private void euro1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int[] eu ={Convert.ToInt32(euro1.Text),
                Convert.ToInt32(euro2.Text),
                Convert.ToInt32(euro3.Text),
                Convert.ToInt32(euro4.Text),
                Convert.ToInt32(euro5.Text),
                Convert.ToInt32(euro6.Text),
                Convert.ToInt32(euro7.Text),
                Convert.ToInt32(euro8.Text),
                Convert.ToInt32(euro9.Text),
                Convert.ToInt32(euro10.Text),
                Convert.ToInt32(euro11.Text),
                Convert.ToInt32(euro12.Text)
                };
            double[] betalen = { 0.01, 0.10, 0.20, 0.50, 1, 2, 5, 10, 20, 50, 100, 200 };

            for (int x = 1; x < eu.Length; x++)
            {
                if (eu[x] >= 1)
                {
                    double uitkomst = Convert.ToDouble(eu[x]) * betalen[x];
                    string answer = Convert.ToString(uitkomst);
                    MessageBox.Show(answer);
                }
            }
        }


    }
}

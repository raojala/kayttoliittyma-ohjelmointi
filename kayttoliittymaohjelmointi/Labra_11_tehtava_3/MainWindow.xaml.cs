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

namespace Labra_11_tehtava_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Henkilo> tyontekijat;

        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        void InitMyStuff()
        {
            tyontekijat = new List<Henkilo>();
            tyontekijat.Add(new OsaAikainen(1, "Jaakko", "Teppo", new DateTime(1988, 7, 6), "pirttiorja", DateTime.Now, 20f, 160));
            tyontekijat.Add(new OsaAikainen(2, "Majra", "SDF", new DateTime(1820, 3, 2), "Siivoaja", DateTime.Now, 11f, 200));
            tyontekijat.Add(new OsaAikainen(3, "asdfaf", "cvbncvbn", new DateTime(1527, 12, 1), "Lihanleikkaaja", DateTime.Now, 13f, 132));
            tyontekijat.Add(new OsaAikainen(4, "ab", "a", new DateTime(2000, 2, 12), "Suoliliimaaja", DateTime.Now, 45f, 20));

            tyontekijat.Add(new Vakituinen(5, "Isomies", "Pomo", new DateTime(1988, 1, 2), "CEO", DateTime.Now, 2900f));
            tyontekijat.Add(new Vakituinen(6, "Big", "Foot", new DateTime(1414, 2, 3), "COCEO", DateTime.Now, 3000f));
            tyontekijat.Add(new Vakituinen(7, "Jaska", "Jokunen", new DateTime(2424, 4, 8), "COCOCEO", DateTime.Now, 4000f));
            tyontekijat.Add(new Vakituinen(8, "Donald", "Trump", new DateTime(6565, 3, 7), "Illuminati lähettiläs", DateTime.Now, 5000f));
        }

        private void btnHaeTyontekijat_Click(object sender, RoutedEventArgs e)
        {
            lstNimet.ItemsSource = tyontekijat;
        }

        private void btnTyhjenna_Click(object sender, RoutedEventArgs e)
        {
            lstNimet.ItemsSource = null;
        }

        private void lstNimet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstNimet.ItemsSource != null)
            {
                Tyontekija henkilo = (Tyontekija)lstNimet.SelectedItem;
                txtEtunimi.Text = henkilo.Etunimi;
                txtSukunimi.Text = henkilo.Sukunimi;
                txtTTNro.Text = henkilo.SOTU;
                txtTitteli.Text = henkilo.Nimike;
                txtPalkka.Text = henkilo.Palkka.ToString();

                if (henkilo.GetType() == typeof(OsaAikainen))
                {
                    rdbOsaAikainen.IsChecked = true;
                }
                else
                {
                    rdbVakituinen.IsChecked = true;
                }

            }
        }
    }
}

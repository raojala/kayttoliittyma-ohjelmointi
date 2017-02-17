using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using JAMK.ICT;


namespace WPFDataBindingDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // koska useampi metodi = tapahtumankäsittelija tulee käyttämään näitä muttujia niin
        // määritellään luokan tasolle luokan jäsenmuuttujiksi
        HockeyLeague liiga;
        ObservableCollection<HockeyTeam> joukkueet;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            List<string> muuvit = new List<string>();
            muuvit.Add("Halloween");
            muuvit.Add("Jaws");
            muuvit.Add("Star Wars");
            muuvit.Add("Pahat pojat");
            cmbMovies.ItemsSource = muuvit;

            // haetaan smliiga-joukkueet
            liiga = new HockeyLeague();
            joukkueet = liiga.GetTeams();
            cmbTeams.ItemsSource = joukkueet;


        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            // määritellään stackpanelin DataContext
            // Demo1: Datacontekstina on olio
            //  HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //  spRight.DataContext = tiimi;

            //demo2: kytketään olio-kokoelman 1. olioon
            spRight.DataContext = joukkueet[counter];
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                btnBind_Click(sender, e);
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (counter < joukkueet.Count-1)
            {
                counter++;
                btnBind_Click(sender, e);
            }
        }
    }
}

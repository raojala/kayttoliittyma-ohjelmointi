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

namespace Labra_10_Tehtava_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        kiuas Kiuas;
        string s = "";
        double temp, humi;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void customClick(object sender, RoutedEventArgs e)
        {
            s += sender.ToString().Substring(sender.ToString().Length-1, 1);
            txtResult.Text = s;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (rdbHumidity.IsChecked == true)
            {
                float f;
                float.TryParse(s, out f);
                Kiuas.SetHumid(f);
                lblHumidity.Content = Kiuas.Humid;

            }
            else if (rdbTemperature.IsChecked == true)
            {
                float f;
                float.TryParse(s, out f);
                Kiuas.SetTemp(f);
                lblTemperature.Content = Kiuas.Temp;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Kiuas = new kiuas();
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            // tee tarkastus että pyyhkiminen ei voi mennä negatiiviseks
            s = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            txtResult.Text = s;
        }
    }
}


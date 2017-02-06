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

namespace Labra_9_tehtava_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int trucks = 0, cars = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_car_Click(object sender, RoutedEventArgs e)
        {
            cars++;
            lbl_cars.Content = cars;
        }

        private void btn_trucks_Click(object sender, RoutedEventArgs e)
        {
            trucks++;
            lbl_trucks.Content = trucks;
        }
    }
}

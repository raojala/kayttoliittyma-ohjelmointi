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

namespace Labra_10_tehtava_3
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

        /// <summary>
        /// Load default's here
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // get gametypes from game enumeration and set the default gametype to first gametype (Lotto
                cmbGameType.ItemsSource = Enum.GetNames(typeof(Game.GameTypes));
                cmbGameType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Exception in Window_Loaded");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txbRows.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Exception in btnClear_Click");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // reverse the combobox item to enumeration, and set the type for the new game
                int i = int.Parse(txtRows.Text);
                Game.GameTypes gt = (Game.GameTypes)Enum.Parse(typeof(Game.GameTypes), cmbGameType.Text);
                Game game = new Game(gt, i);

                // input numbers to textbox
                txbRows.Text = " ";
                foreach (Row row in game.Rows)
                {
                    foreach (int number in row.Numbers)
                    {
                        txbRows.Text += number + " ";
                    }
                    txbRows.Text += "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex, "Exception in btnCreate_Click");
            }
        }
    }
}

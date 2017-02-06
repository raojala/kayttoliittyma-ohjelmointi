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

namespace Labra_9_Tehtava_3
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

        private void btn_Laske_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float ikkunaW, ikkunaH, karmiLeveys;

                if (!float.TryParse(txt_ikkunaHeight.Text, out ikkunaH))
                {
                    txt_ikkunaHeight.Text = "";
                }
                if (!float.TryParse(txt_ikkunaWidth.Text, out ikkunaW))
                {
                    txt_ikkunaWidth.Text = "";
                }
                if (!float.TryParse(txt_karmiWidth.Text, out karmiLeveys))
                {
                    txt_karmiWidth.Text = "";
                }

                txt_ikkunanAla.Text = ((ikkunaW * ikkunaH) / 10).ToString() + "m^2";
                txt_lasinAla.Text = (((ikkunaW - 2 * karmiLeveys) * (ikkunaH - 2 * karmiLeveys))/10).ToString() + "m^2";

                txt_karminPiiri.Text = ((ikkunaW + ikkunaH) * 2 / 10).ToString() + "m^2";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR PUGIPUGI");
                throw ex;
            }
        }
    }
}

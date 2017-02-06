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

namespace Labra_9_Tehtava_2
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

        float eurtofim = 5.9457f;
        float fimtoeur = 0.1682f;

        private void txt_eur_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_eur.IsFocused)
            {
                float value;
                txt_eur.Text = txt_eur.Text.Replace(".", ",");
                txt_eur.SelectionStart = txt_eur.Text.Length;
                try
                {
                    if (float.TryParse(txt_eur.Text, out value))
                    {
                        txt_fim.Text = (value * eurtofim).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR TILT PUGIPUGI");
                    throw ex;
                }
            }
        }

        private void txt_fim_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_fim.IsFocused)
            {
                float value;
                txt_fim.Text = txt_fim.Text.Replace(".", ",");
                txt_fim.SelectionStart = txt_fim.Text.Length;
                try
                {
                    if (float.TryParse(txt_fim.Text, out value))
                    {
                        txt_eur.Text = (value * fimtoeur).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR TILT PUGIPUGI");
                    throw ex;
                }
            }
        }
    }
}

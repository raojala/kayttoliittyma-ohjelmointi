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

namespace Labra_10_Tehtava_1
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

        List<CheckBox> chkList = new List<CheckBox>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Itemi> ostosLista = new List<Itemi>();
                ostosLista.Add(new Itemi("Milk"));
                ostosLista.Add(new Itemi("Butter"));
                ostosLista.Add(new Itemi("Beer"));
                ostosLista.Add(new Itemi("Chicken"));
                ostosLista.Add(new Itemi("Lemonade"));

                foreach (Itemi i in ostosLista)
                {
                    CheckBox newCheckBox = new CheckBox();
                    newCheckBox.Content = i.Nimi;
                    newCheckBox.Name = "chk" + i.Nimi;

                    spMain.Children.Add(newCheckBox);
                    chkList.Add(newCheckBox);
                }

                wndMain.SizeToContent = SizeToContent.WidthAndHeight;

                Button newBtn = new Button();
                newBtn.Content = "Buy";
                newBtn.Name = "btnBuy";
                spMain.Children.Add(newBtn);
                newBtn.Click += new RoutedEventHandler(BuyItems);

                Label newLbl = new Label();
                newLbl.Content = "Shopping List";
                newLbl.Name = "lblShoppingList";
                spMain.Children.Add(newLbl);

                TextBlock newTxb = new TextBlock();
                newTxb.Name = "txbShoppingList";
                spMain.Children.Add(newTxb);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void BuyItems (object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (object obj in spMain.Children)
                {
                    if (obj is TextBlock)
                    {
                        TextBlock chk = (TextBlock)obj;
                        if (chk.Name == "txbShoppingList")
                        {
                            string s = "";
                            foreach (CheckBox chkBox in chkList)
                            {
                                if (chkBox.IsChecked == true)
                                {
                                    s += chkBox.Content + "\n";
                                }
                            }
                            chk.Text = s;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

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
using System.Windows.Shapes;

namespace WPFDataBindingDemo3_labra_12.View
{
    /// <summary>
    /// Interaction logic for testmysql.xaml
    /// </summary>
    public partial class testmysql : Window
    {
        public testmysql()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.StudentViewModel svmo = new ViewModel.StudentViewModel();
                svmo.LoadStudentsFromMySql();
                dgStudents.DataContext = svmo.Students;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + " \n " + ex.Message, "ERROR");
            }
            
        }
    }
}

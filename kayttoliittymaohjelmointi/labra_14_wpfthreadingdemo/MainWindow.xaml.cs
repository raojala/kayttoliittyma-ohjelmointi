using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace labra_14_wpfthreadingdemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #region METHODS
        void InitializeMyStuff ()
        {
            btnFire.IsEnabled = false;
        }
        void UpdateMessage (string msg)
        {
            txtMessage.Text = msg;
        }
        void UpdateMessageAsync(string msg)
        {
            Action action = () =>
            {
                txtMessage.Text = msg;
                btnFire.IsEnabled = false;
            };
            // suorittaa annetun delegaatin asynkroonisesti siinä säikeessä mihin dispatcheri liittyy
            Dispatcher.BeginInvoke(action);
        }

        void DoWork ()
        {
            // käynnistetään pitkäkestoinen tapahtuma
            Thread.Sleep(5000);
            UpdateMessageAsync("the work is done and answer comes now!");
        }
        #endregion

        #region EVENTHANDLERS
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateMessage("Fire #" + count.ToString());
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            btnFire.IsEnabled = true;
            // V1 normaalisti tämä toimisi mutta nyt metodin pitkän keston takia ei kerkiä päivittymään.
            // UpdateMessage("a looooooong work started, please wait.");
            // DoWork();

            // v2. säikeeseen
            UpdateMessage("a looooooong work started, please wait.");
            new Thread(DoWork).Start();

        }
        #endregion
    }
}

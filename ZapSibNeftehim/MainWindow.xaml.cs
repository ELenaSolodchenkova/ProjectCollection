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
using System.Windows.Threading;

using ZapSibNeftehim.Pages;

namespace ZapSibNeftehim
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Image imgLink { get; set; }
        public DispatcherTimer timerSession;
        public DispatcherTimer timerUnban;
        public static string userInfo;

        private int sessionShutDown;
        private int unbanShutDown;

        public bool unbanEnabled;
        public MainWindow()
        {
            InitializeComponent();
            imgLink = imgUser;
           // userInfo = tbUserInfo.Text;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
           if(e.Content is LoginPage)
            {
                btnExit.Visibility = Visibility.Collapsed;
                contUserInfo.Visibility = Visibility.Collapsed;
            }
           if(e.Content is UserPage)
            {
                btnExit.Visibility = Visibility.Visible;
               contUserInfo.Visibility = Visibility.Visible;
             
                TimerSession();
            }
            if (unbanEnabled)
            {
                TimerUnban();
            }
        }
        public void TimerSession()
        {
            sessionShutDown = (int)TimeSpan.FromSeconds(10).TotalSeconds;

            timerSession = new DispatcherTimer();
            timerSession.Interval = TimeSpan.FromSeconds(1);
            timerSession.Tick += TimerSessionTick;
            timerSession.Start();
        }
        public void TimerUnban()
        {
            unbanShutDown = (int)TimeSpan.FromSeconds(3).TotalSeconds;

            timerUnban = new DispatcherTimer();
            timerUnban.Interval = TimeSpan.FromSeconds(1);
            timerUnban.Tick += TimerUnbanTick;
            timerUnban.Start();
        }
        private void TimerUnbanTick(object sender, EventArgs e)
        {
            unbanShutDown--;

            if (unbanShutDown <= 0)
            {
                this.IsEnabled = true;
                unbanEnabled = true;
            }
        }
        private void TimerSessionTick(object sender, EventArgs e)
        {
            sessionShutDown--;

            if(sessionShutDown == 5)
            {
                MessageBox.Show("Осталось 5 секунд");
            }
            if(sessionShutDown == 0)
            {
                this.IsEnabled = false;
                timerSession.Stop();
                App.MainFrame.Navigate(new LoginPage());
                unbanEnabled = true;
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            imgLink = null;
            App.MainFrame.Navigate(new LoginPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainFrame = this.MainFrame;
            App.MainFrame.Navigate(new Pages.LoginPage());
        }

       
    }
}

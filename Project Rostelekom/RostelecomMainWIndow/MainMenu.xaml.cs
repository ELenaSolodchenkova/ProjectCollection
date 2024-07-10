using RostelecomMainWIndow.Resources;
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

namespace RostelecomMainWIndow
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().ShowDialog();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Clients().ShowDialog();
        }

        private void btnCLientsSE_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new CliSE().ShowDialog();
        }

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new SerList().ShowDialog();
        }

        private void btnEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new EqList().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var authorization = new MainWindow();
                var allusersList = DB.db.AllUsers.FirstOrDefault(x => x.Login == authorization.uLogin);
                string name = allusersList.FirstName + " " + allusersList.Patronymic;
                welcomeLabel.Content = "Добро пожаловать, " + name + "!";
            }
            catch { }
           
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RostelecomMainWIndow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public string uLogin;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbPassword.Text.Length == 0 || tbUsername.Text.Length == 0)
                {
                    if (tbUsername == null)
                        MessageBox.Show("Введите логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    uLogin = tbUsername.Text;
                    string inPassword = tbPassword.Text;
                    var allusersList = DB.db.AllUsers.FirstOrDefault(x => x.Login == uLogin);
                    if (allusersList.Login != uLogin || allusersList.Password != inPassword)
                    {
                        if (allusersList.Login != uLogin)
                        {
                            MessageBox.Show("Неверный логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (allusersList.Password != inPassword)
                        {
                            MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                        this.Hide();
                        new MainMenu().ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Повторно введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
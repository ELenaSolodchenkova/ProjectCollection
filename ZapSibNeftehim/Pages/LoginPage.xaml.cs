using System;
using System.Collections.Generic;
using System.IO;
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
using ZapSibNeftehim.Models;

namespace ZapSibNeftehim.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public bool eyeClicked;
        public bool capShow;

        public string capText;
        public string capInput;
        public string password;
        public string login;
        public LoginPage()
        {
            InitializeComponent();
            if (!capShow)
                contCap.Visibility = Visibility.Collapsed;
            

        }

        private void btnEye_Click(object sender, RoutedEventArgs e)
        {
            if (eyeClicked)
            {
                tbPassword.Visibility = Visibility.Visible;
                pbPassword.Visibility = Visibility.Collapsed;
                password = tbPassword.Text;
                tbPassword.Text = pbPassword.Password;
                btnEye.Content = "--";
                eyeClicked = false;
                return;
            }
            pbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
            password = pbPassword.Password;
            btnEye.Content = "👁";
            eyeClicked = true;
        }
        private void btnCap_Click(object sender, RoutedEventArgs e)
        {
            if (capInput == capText)
                CapHide();
            if (string.IsNullOrWhiteSpace(capInput))
            {
                MessageBox.Show("Введите капчу");
                return;
            }
            if(capInput != capText)
            {
                MessageBox.Show("Неправильно введена капча");
                GenerateCap();
                return;
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (eyeClicked)
            {
                login = tbLogin.Text;
                password = tbPassword.Text;
            }
            if (!eyeClicked)
            {
                login = tbLogin.Text;
                password = pbPassword.Password;
            }
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все данные");
                return;
            }
            if (capShow)
            {
                MessageBox.Show("Введите капчу");
                return;
            }
            if(FindEmployee(login,password)is null)
            {
                MessageBox.Show("Неправильно введены данные");
                WrongLogin();
                CapShow();
                return;
            }
            else
            {
                App.CurrentEmployee = FindEmployee(login, password);
                if(App.CurrentEmployee.positionID == 2)
                App.MainFrame.Navigate(new UserPage());
                if (App.CurrentEmployee.positionID == 3)
                    App.MainFrame.Navigate(new Laborant());
            }

                var ms = new MemoryStream(App.CurrentEmployee.photo);
                var bitmapImage = new BitmapImage();

                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                MainWindow.imgLink.Source = bitmapImage;



        }

        private void WrongLogin()
        {
            try
            {
                var historyLoginFind = App.ZSNdb.Employees.FirstOrDefault(x => x.login == tbLogin.Text);
                var historyLoginNew = new Employee
                {
                    firstName = historyLoginFind.firstName,
                    lastName = historyLoginFind.lastName,
                    patronymic = historyLoginFind.patronymic,
                    ID = 101,
                    lastenter = DateTime.Now,
                    
                };
                App.ZSNdb.Employees.Add(historyLoginNew);
                App.ZSNdb.SaveChanges();

            }
            catch(Exception ex) { }
         
        }

        private void CapShow()
        {
            capShow = true;
            tbCap.Text = "";
            contCap.Visibility = Visibility.Visible;
            GenerateCap();
        }
        private void CapHide()
        {
            capShow = false;
            contCap.Visibility = Visibility.Collapsed;
        }
        private void GenerateCap()
        {
            capText = "";

            var rand = new Random();
            var symbols = "123abc";
            for(int i = 0; i<4; i++)
            {
                var index = rand.Next(0, symbols.Length);
                capText += symbols[index];
            }
            lCapLetterOne.Content = capText[0];
            lCapLetterTwo.Content = capText[1];
            lCapLetterThree.Content = capText[2];
            lCapLetterFour.Content = capText[3];
        }

        private Employee FindEmployee(string login, string password)
        {
            return App.ZSNdb.Employees.FirstOrDefault(x => x.login == login && x.password == password);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

          
        }

        private void tbCap_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = e.Source as TextBox;
            capInput = textBox.Text;        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = e.Source as TextBox;
            login = textBox.Text;
        }

        private void tbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var textBox = e.Source as TextBox;
                password = textBox.Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                var textBox = e.Source as TextBox;
                password = textBox.Text;
            }
           catch(Exception ex)
            {

            }
        }
    }
}

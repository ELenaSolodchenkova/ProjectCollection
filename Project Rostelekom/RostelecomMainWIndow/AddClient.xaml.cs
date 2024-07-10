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
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public int clientId;
        public AddClient()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnBacks_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Clients().ShowDialog();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                if (string.IsNullOrEmpty(tbPhone.Text))
                {
                    MessageBox.Show("Электронная почта и телефонный номер обязательно должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (clientId != 0)
            {
                var clientList = DB.db.Clients.FirstOrDefault(x => x.IdClient == clientId);
                clientList.LastName = tbLastName.Text;
                clientList.Patronymic = tbPatronymic.Text;
                clientList.Phone = long.Parse(tbPhone.Text);
                clientList.FirstName = tbName.Text;
                clientList.Email = tbEmail.Text;
                DB.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (clientId == 0)
            {
                Client add = new Client
                {
                    FirstName = tbName.Text,
                    Patronymic = tbPatronymic.Text,
                    LastName = tbLastName.Text,
                    Phone = long.Parse(tbPhone.Text),
                    Email = tbEmail.Text
                };
                DB.db.Clients.Add(add);
                try { DB.db.SaveChanges(); } 
                catch { }
                MessageBox.Show("Новый клиент добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Hide();
            new Clients().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (clientId != 0)
            {
                var clientList = DB.db.Clients.FirstOrDefault(x => x.IdClient == clientId);
                tbEmail.Text = clientList.Email;
                tbName.Text = clientList.FirstName;
                tbLastName.Text = clientList.LastName;
                tbPatronymic.Text = clientList.Patronymic;
                tbPhone.Text = Convert.ToString(clientList.Phone);
            }
        }
    }
}

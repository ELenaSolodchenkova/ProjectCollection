using RostelecomMainWIndow.Resources;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        int idClient = 0;
        public Clients()
        {
            InitializeComponent();
            
        }

        private void dgvClients_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Client row = dgvClientList.SelectedItem as Client;
                idClient = row.IdClient;

            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AddClient().ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (idClient == 0)
            {
                MessageBox.Show("Для редактирование необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new AddClient();
            edit.clientId = idClient;
            edit.ShowDialog();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string s1 = tbFindLastName.Text,s2;
            int count;
            List<Client> listClient = new List<Client>();
            var listFind = DB.db.Clients.Select(x => x.LastName).ToList();
            for (int i = 0; i < listFind.Count; i++)
            {
                s2 = Convert.ToString(listFind[i]);
                count = FuzzySearch.Levenshtain(s1, s2);
                if (count <= 3)
                {
                    foreach (var list in DB.db.Clients.Where(x => x.LastName == s2))
                    {
                        listClient.Add(list);
                    }
                }
            }
            dgvClientList.ItemsSource = listClient;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgvClientList.ItemsSource = DB.db.Clients.ToList();
        }

        private void btnBacks_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainMenu().ShowDialog();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idClient == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Client delClient = DB.db.Clients.Where(x => x.IdClient == idClient).FirstOrDefault();
                    DB.db.Clients.Remove(delClient);
                    DB.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvClientList.ItemsSource = DB.db.Clients.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvClientList.CanUserAddRows = false;
            dgvClientList.ItemsSource = DB.db.Clients.ToList();
        }
    }
}

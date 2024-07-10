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
    /// Interaction logic for ServicesList.xaml
    /// </summary>
    public partial class ServicesList : Window
    {
        int serviceId;
        public ServicesList()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string s1 = tbFindSerName.Text,
                s2;
            int count;
            List<ServicesList> listServices = new List<ServicesList>();
            var listFind = DB.db.ServicesLists.Select(x => x.Name).ToList();
            for (int i = 0; i < listFind.Count; i++)
            {
                s2 = Convert.ToString(listFind[i]);
                count = FuzzySearch.Levenshtain(s1, s2);
                if (count <= 3)
                {
                    foreach (var list in DB.db.ServicesLists.Where(x => x.Name == s2))
                    {
                        listServices.Add(list);
                    }
                }
            }
            dgvSer.ItemsSource = listServices;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgvSer.ItemsSource = DB.db.ServicesLists.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AddService().ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (serviceId == 0)
            {
                MessageBox.Show("Для редактирование необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new AddService();
            edit.addServiceId = IdService;
            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serviceId == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ServicesList delSer = DB.db.ServicesLists.Where(x => x.serviceId == IdService).FirstOrDefault();
                    DB.db.ServicesLists.Remove(delSer);
                    DB.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvSer.ItemsSource = DB.db.ServicesLists.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}

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
    /// Interaction logic for InstalledSerAdd.xaml
    /// </summary>
    public partial class InstalledSerAdd : Window
    {
        public int inSerAddID;
        public InstalledSerAdd()
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
            new Services().ShowDialog();
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
            if (string.IsNullOrEmpty(tbClientId.Text))
            {
                if (string.IsNullOrEmpty(tbSerId.Text))
                {
                    MessageBox.Show("Поля ID клиента и ID услуги должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (inSerAddID != 0)
            {
                var inserList = DB.db.InstalledServices.FirstOrDefault(x => x.IdES == inSerAddID);
                inserList.Date = Convert.ToDateTime(tbDate.Text);
                inserList.IdClient = Convert.ToInt32(tbClientId.Text);
                inserList.IdService = Convert.ToInt32(tbSerId.Text);
                DB.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (inSerAddID == 0)
            {
                InstalledService add = new InstalledService
                {
                    IdClient = Convert.ToInt32(tbClientId.Text),
                    IdService = Convert.ToInt32(tbSerId.Text),
                    Date = Convert.ToDateTime(tbDate.Text)
                };
                DB.db.InstalledServices.Add(add);
                DB.db.SaveChanges();
                MessageBox.Show("Новый клиент добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Hide();
            new Services().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (inSerAddID != 0)
            {
                var inserList = DB.db.InstalledServices.FirstOrDefault(x => x.IdES == inSerAddID);
                tbClientId.Text = Convert.ToString(inserList.IdClient);
                tbSerId.Text = Convert.ToString(inserList.IdService);
                tbDate.Text = Convert.ToString(inserList.Date);
            }
        }
    }
}

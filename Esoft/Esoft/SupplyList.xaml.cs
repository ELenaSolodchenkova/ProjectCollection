using Esoft.Resourse;
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

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для SupplyList.xaml
    /// </summary>
    public partial class SupplyList : Window
    {
        int supperId;

        public SupplyList()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvSupplyList.CanUserAddRows = false;
            dgvSupplyList.ItemsSource = Setting.db.Supply.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new SupplyEdit().ShowDialog();
        }

        private void dgvSupplyList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Supply row = dgvSupplyList.SelectedItem as Supply;
                supperId = row.IdSupply;
            }
            catch { MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(supperId == 0)
            {
                MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new SupplyEdit();
            edit.idSup = supperId;
            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (supperId == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var deal = Setting.db.Deal.Where(x => x.IdSupply == supperId).ToList();
                if(deal.Count != 0)
                {
                    MessageBox.Show("Невозможно удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if(MessageBox.Show("Вы действительно хотите удалить запись? ","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Supply delSup = Setting.db.Supply.FirstOrDefault(x => x.IdSupply == supperId);
                    Setting.db.Supply.Remove(delSup);
                    Setting.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvSupplyList.ItemsSource = Setting.db.Supply.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

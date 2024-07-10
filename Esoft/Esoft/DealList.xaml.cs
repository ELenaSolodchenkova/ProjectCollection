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
    /// Логика взаимодействия для DealList.xaml
    /// </summary>
    public partial class DealList : Window
    {
        double price;
        int dealId;

        public DealList()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDeal.CanUserAddRows = false;
            dgvDeal.ItemsSource = Setting.db.Deal.ToList();
        }

        private void dgvDeal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Deal row = dgvDeal.SelectedItem as Deal;
                dealId = row.IdDeal;
                price = Convert.ToDouble(row.Supply.Price);
                var type = row.Supply.RealEstate.Type;

                switch (type)//услуга продавца
                {
                    case 1:
                        Lbl1.Content = 0.01 * price + 30000;
                        break;
                    case 2:
                        Lbl1.Content = 0.01 * price + 36000;
                        break;
                    case 3:
                        Lbl1.Content = 0.02 * price + 30000;
                        break;
                }

                var agentSup = row.Supply.Agent.DealShare;
                if (agentSup == null)
                {
                    agentSup = 45;
                }
                Lbl2.Content = agentSup * Convert.ToDouble(Lbl1.Content) / 100.0;//риэлтор продаца

                Lbl3.Content = price * 0.03; //услуга покупателя

                var agentDem = row.Demand.Agent.DealShare;
                if (agentDem == null)
                {
                    agentDem = 45;

                }
                Lbl4.Content = agentDem * Convert.ToDouble(Lbl3.Content) / 100.0;//риэлтир покупателя

                Lbl5.Content = Convert.ToDouble(Lbl1.Content) - Convert.ToDouble(Lbl2.Content) + Convert.ToDouble(Lbl3.Content) - Convert.ToDouble(Lbl4.Content);
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку","Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DealEdit().ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dealId == 0)
            {
                MessageBox.Show("Выберите нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new DealEdit();
            edit.dealId = dealId;
            edit.role = "edit";
            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотьте удалить запись? ", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Deal del = Setting.db.Deal.FirstOrDefault(x => x.IdDeal == dealId);
                    Setting.db.Deal.Remove(del);
                    Setting.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvDeal.ItemsSource = Setting.db.Deal.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

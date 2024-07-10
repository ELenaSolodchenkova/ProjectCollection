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
    /// Логика взаимодействия для DemandList.xaml
    /// </summary>
    public partial class DemandList : Window
    {
        int demandId, type;

        public DemandList()
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
            dgvDemand.CanUserAddRows = false;
            dgvDemand.ItemsSource = Setting.db.Demand.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(demandId == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var deal = Setting.db.Deal.Where(x => x.IdDemand == demandId).ToList();
                if(deal.Count != 0)
                {
                    MessageBox.Show("Невозможно удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (MessageBox.Show("Вы действительно хотите удалить запись","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    switch (type)
                    {
                        case 1:
                            HouseFilter del1 = Setting.db.HouseFilter.FirstOrDefault(x => x.IdHouseFilter == demandId);
                            Setting.db.HouseFilter.Remove(del1);
                            break;
                        case 2:
                            ApartmentFilter del2 = Setting.db.ApartmentFilter.FirstOrDefault(x => x.IdApartmentFilter == demandId);
                            Setting.db.ApartmentFilter.Remove(del2);
                            break;
                        case 3:
                            LandFilter del3 = Setting.db.LandFilter.FirstOrDefault(x => x.IdLaneFilter == demandId);
                            Setting.db.LandFilter.Remove(del3);
                            break;
                    }

                    RealEstateFilter delFilter = Setting.db.RealEstateFilter.FirstOrDefault(x => x.IdRealEstateFilter == demandId);
                    Setting.db.RealEstateFilter.Remove(delFilter);

                    Demand delDemand = Setting.db.Demand.FirstOrDefault(x => x.IdDemand == demandId);
                    Setting.db.Demand.Remove(delDemand);
                    Setting.db.SaveChanges();

                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvDemand.ItemsSource = Setting.db.Demand.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgvDemand_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Demand row = dgvDemand.SelectedItem as Demand;
                demandId = row.IdDemand;
                type = Convert.ToInt32(row.RealEstateFilter.Type);
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DemandEdit().ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (demandId == 0)
            {
                MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new DemandEdit();
            edit.idObjectFilter = demandId;
            edit.role = "edit";
            edit.typeEstate = type;
            edit.ShowDialog();


        }
    }
}

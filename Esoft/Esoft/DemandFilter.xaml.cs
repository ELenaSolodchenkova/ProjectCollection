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
    /// Логика взаимодействия для DemandFilter.xaml
    /// </summary>
    public partial class DemandFilter : Window
    {
        public string role;
        public int idPeople;

        public DemandFilter()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDemand.CanUserAddRows = false;
            if (role == "client")
            {
                dgvDemand.ItemsSource = Setting.db.Demand.Where(x => x.IdClient == idPeople).ToList();
            }
            else
            {
                dgvDemand.ItemsSource = Setting.db.Demand.Where(x => x.IdAgent == idPeople).ToList();
            }

            if (dgvDemand.Items.Count == 0)
            {
                MessageBox.Show("Нет потребностей", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
            }
        }
    }
}

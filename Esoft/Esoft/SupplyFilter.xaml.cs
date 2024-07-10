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
    /// Логика взаимодействия для SupplyFilter.xaml
    /// </summary>
    public partial class SupplyFilter : Window
    {
        public string role;
        public int idPeople;

        public SupplyFilter()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            dgvSupply.CanUserAddRows = false;
            if (role == "client")
            {
                dgvSupply.ItemsSource = Setting.db.Supply.Where(x => x.IdClient == idPeople).ToList();
            }
            else
            {
                dgvSupply.ItemsSource = Setting.db.Supply.Where(x => x.IdAgent == idPeople).ToList();
            }

            if(dgvSupply.Items.Count ==  0)
            {
                MessageBox.Show("Нет предложений", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
            }
        }
    }
}

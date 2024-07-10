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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseEnter( object sender, MouseEventArgs e )
        {
            ( sender as Button ).Background = new SolidColorBrush( Color.FromRgb( 0, 0, 0 ) );
        }

        private void Rectangle_MouseLeave( object sender, MouseEventArgs e )
        {
            (sender as Button).Background  = new SolidColorBrush( Color.FromRgb( 4, 160, 255 ) );
        }

        private void btnClient_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new ClientWindow().ShowDialog();
        }

        private void BtnAgent_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new AgentList().ShowDialog();
        }

        private void BtnEstate_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new RealEstateList().ShowDialog();
        }

        private void btnSupply_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new SupplyList().ShowDialog();
        }

        private void btnDemand_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DemandList().ShowDialog();
        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DealList().ShowDialog();
        }
    }
}

using Esoft.Resourse;
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

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        int idClient = 0;

        public ClientWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            dgvClientList.CanUserAddRows = false;
            dgvClientList.ItemsSource = Setting.db.Client.ToList();
        }

        private void BtnAdd_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new ClientEdit().ShowDialog();
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
             this.Hide();
             new MainWindow().ShowDialog();     
        }

        private void DgvClientList_MouseUp( object sender, MouseButtonEventArgs e )
        {
            try
            {
                Client row = dgvClientList.SelectedItem as Client;
                idClient = row.IdClient;
                
            }
            catch
            {
                MessageBox.Show( "Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void BtnEdit_Click( object sender, RoutedEventArgs e )
        {
            if ( idClient == 0 )
            {
                MessageBox.Show( "Для редактирование необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            this.Hide();
            var edit = new ClientEdit();
            edit.clientId = idClient;
            edit.ShowDialog();

        }

       

        private void BtnFind_Click( object sender, RoutedEventArgs e )
        {
            string s1 = tbFindFirstName.Text,
                s2;
            int count;
            List<Client> listClient = new List<Client>();
            var listFind = Setting.db.Client.Select( x => x.FirstName  ).ToList();
            for ( int i = 0; i < listFind.Count; i++ ) 
            {
                s2 = Convert.ToString( listFind[i] );
                count = FuzzySearch.Levenshtain( s1, s2 );
                if(count <=3 )
                {
                    foreach ( var list in Setting.db.Client.Where( x => x.FirstName == s2 ) )
                    {
                        listClient.Add( list );
                    }
                }
            }
            dgvClientList.ItemsSource = listClient;
             /*List<Client> listClient = new List<Client>();
             string s1 = tbFind.Text,
                s2;
              int count;
              for ( int i = 0; i < dgvClientList.Items.Count; i++ )
              {
                DataGridRow row = (DataGridRow)dgvClientList.ItemContainerGenerator.ContainerFromIndex( i );
                //s3 = row.Item.ToString();
                s2 = ( dgvClientList.Columns[1].GetCellContent( row.Item ) as TextBlock ).Text;
               
                 count = FuzzySearch.Levenshtain( s1, s2 );
                if ( count <= 3 )
                {
                   string numId = ( dgvClientList.Columns[0].GetCellContent( row.Item ) as TextBlock ).Text;
                   //string numId = dgvClientList.Columns[0].GetCellContent( row ).ToString();
                   int num = Convert.ToInt32( numId );
                    foreach(var list in Setting.db.Client.Where( x => x.IdClient == num )){
                        listClient.Add( list );
                    }
                }
                dgvClientList.ItemsSource = listClient;
            }*/
        }

        private void BtnUpdate_Click( object sender, RoutedEventArgs e )
        {
            dgvClientList.ItemsSource = Setting.db.Client.ToList();
        }

        private void BtnDelete_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                if ( idClient == 0 )
                {
                    MessageBox.Show( "Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }
                var demand = Setting.db.Demand.Where( x => x.IdClient == idClient ).ToList();
                var supply = Setting.db.Supply.Where( x => x.IdClient == idClient ).ToList();
                if(demand.Count != 0 || supply.Count != 0 )
                {
                    MessageBox.Show( "Невозможно удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }

                if(MessageBox.Show("Вы действительно хотите удалить запись?","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes )
                {
                    Client delClient = Setting.db.Client.Where( x => x.IdClient == idClient ).FirstOrDefault();
                    Setting.db.Client.Remove( delClient );
                    Setting.db.SaveChanges();
                    MessageBox.Show( "Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
                    dgvClientList.ItemsSource = Setting.db.Client.ToList();
                }
            }
            catch
            {
                MessageBox.Show( "Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void BtnSupply_Click( object sender, RoutedEventArgs e )
        {
            if ( idClient == 0 )
            {
                MessageBox.Show( "Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            var supply = new SupplyFilter();
            supply.role = "client";
            supply.idPeople = idClient;
            supply.ShowDialog();
        }

        private void btnDemand_Click(object sender, RoutedEventArgs e)
        {
            if (idClient == 0)
            {
                MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var demand = new DemandFilter();
            demand.role = "client";
            demand.idPeople = idClient;
            demand.ShowDialog();
        }
    }
}

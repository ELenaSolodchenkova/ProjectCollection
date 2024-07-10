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
    /// Логика взаимодействия для RealEstateList.xaml
    /// </summary>
    public partial class RealEstateList : Window
    {
        int idObject, type;

        public RealEstateList()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            dgvRealEstateList.CanUserAddRows = false;
            dgvRealEstateList.ItemsSource = Setting.db.RealEstate.ToList();
        }

        private void btnEdit_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                RealEstate row = dgvRealEstateList.SelectedItem as RealEstate;
                idObject = row.IdRealEstate;
                type = Convert.ToInt32(row.Type);
                this.Hide();
                var edit = new RealEstateEdit();
                edit.role = "edit";
                edit.idObjectEdit = idObject;
                edit.typeEstate = type;
                edit.ShowDialog();
            }
            catch
            {
                MessageBox.Show( "Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e )
        {
            try
            {
                RealEstate row = dgvRealEstateList.SelectedItem as RealEstate;
                idObject = row.IdRealEstate;
                type = Convert.ToInt32( row.Type );
                var supply = Setting.db.Supply.Where( x => x.IdRealEstate == idObject ).ToList();
                if(supply.Count != 0 )
                {
                    MessageBox.Show( "Невозможно удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }

                if(MessageBox.Show("Вы дествителтно хотите удалить запись? ","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes )
                {
                    switch ( type )
                    {
                        case 1:
                        House delHouse = Setting.db.House.Where( x => x.IdHouse == idObject ).FirstOrDefault();
                        Setting.db.House.Remove( delHouse );
                        Setting.db.SaveChanges();
                        break;

                        case 2:
                        Apartment delApartment = Setting.db.Apartment.Where( x => x.IdApartment == idObject ).FirstOrDefault();
                        Setting.db.Apartment.Remove( delApartment );
                        Setting.db.SaveChanges();
                        break;

                        case 3:
                        Land delLand = Setting.db.Land.Where( x => x.IdLand == idObject ).FirstOrDefault();
                        Setting.db.Land.Remove( delLand );
                        Setting.db.SaveChanges();
                        break;
                    }

                    RealEstate delObject = Setting.db.RealEstate.Where( x => x.IdRealEstate == idObject ).FirstOrDefault();
                    Setting.db.RealEstate.Remove( delObject );
                    Setting.db.SaveChanges();
                    MessageBox.Show( "Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
                    dgvRealEstateList.ItemsSource = Setting.db.RealEstate.ToList();
                }
            }
            catch
            {
                MessageBox.Show( "Повторино выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

         private void BtnEdit_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new RealEstateEdit().ShowDialog();
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new MainWindow().ShowDialog();
        }

        private void BtnUpdate_Click( object sender, RoutedEventArgs e )
        {
            dgvRealEstateList.ItemsSource = Setting.db.RealEstate.ToList();
        }

        private void CmbType_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            int type;
            type = cmbType.SelectedIndex + 1;
            var objectList = Setting.db.RealEstate.Where( x => x.Type == type ).ToList();
            dgvRealEstateList.ItemsSource = objectList;
        }

        private void BtnAdd_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new RealEstateEdit().ShowDialog();
        }

        
    }
}

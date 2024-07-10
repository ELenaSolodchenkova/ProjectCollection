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
    /// Логика взаимодействия для RealEstateEdit.xaml
    /// </summary>
    public partial class RealEstateEdit : Window
    {
        int id;
        public string role;
        public int idObjectEdit, typeEstate = 0;

        public RealEstateEdit()
        {
            InitializeComponent();
        }

        private void FormStyle()
        {
            row1.Height = new GridLength( 0 );
            row2.Height = new GridLength( 0 );
            row3.Height = new GridLength( 0 );
            lblFloor.Content = "Этаж";
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Height = 481;
        }
                

        private void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            
            switch ( cmbType.SelectedIndex )
            {                
                case 0://дом
                this.FormStyle();
                row1.Height = new GridLength( 40 );
                row2.Height = new GridLength( 40 );
                row3.Height = new GridLength( 40 );
                lblFloor.Content = "Этажность";
                Application.Current.MainWindow.Height = 587.211;
                typeEstate = 1;
                break;
                case 1://квартира
                this.FormStyle();
                row1.Height = new GridLength( 40 );
                row2.Height = new GridLength( 40 );
                row3.Height = new GridLength( 40 );
                Application.Current.MainWindow.Height = 587.211;
                typeEstate = 2;
                break;
                case 2://участок
                this.FormStyle();
                row1.Height = new GridLength( 40 );
                Application.Current.MainWindow.Height = 500;
                typeEstate = 3;
                break;
            }
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            this.FormStyle();

            if(role == "edit" )
            {
                cmbType.IsEnabled = false;

                var estateList = Setting.db.RealEstate.FirstOrDefault(x=>x.IdRealEstate == idObjectEdit);
                tbCity.Text = estateList.AddressCity;
                tbStreet.Text = estateList.AddressStreet;
                tbHouse.Text = estateList.AddressHouse;
                tbNumber.Text = estateList.AddressNumder;
                tbCoordinateLatitude.Text = estateList.CoordinateLatitude.ToString();
                tbCoordinateLongitude.Text = estateList.CoordinateLongitude.ToString();

                switch ( typeEstate )
                {
                    case 1://дом
                    this.FormStyle();
                    row1.Height = new GridLength( 40 );
                    row2.Height = new GridLength( 40 );
                    row3.Height = new GridLength( 40 );
                    lblFloor.Content = "Этажность";
                    Application.Current.MainWindow.Height = 587.211;
                    typeEstate = 1;

                    var houseList = Setting.db.House.FirstOrDefault( x => x.IdHouse == idObjectEdit );
                    tbArea.Text = houseList.TotalArea.ToString(); 
                    tbFloor.Text = houseList.TotalFloors.ToString();
                    tbRoom.Text = houseList.TotalRooms.ToString();
                    break;

                    case 2://квартира
                    this.FormStyle();
                    row1.Height = new GridLength( 40 );
                    row2.Height = new GridLength( 40 );
                    row3.Height = new GridLength( 40 );
                    Application.Current.MainWindow.Height = 587.211;
                    typeEstate = 2;

                    var apartList = Setting.db.Apartment.FirstOrDefault( x => x.IdApartment == idObjectEdit );
                    tbArea.Text = apartList.TotalArea.ToString(); 
                    tbFloor.Text = apartList.Floor.ToString();
                    tbRoom.Text = apartList.Rooms.ToString();
                    break;

                    case 3://участок
                    this.FormStyle();
                    row1.Height = new GridLength( 40 );
                    Application.Current.MainWindow.Height = 500;
                    typeEstate = 3;

                    var landList = Setting.db.Land.FirstOrDefault( x => x.IdLand == idObjectEdit );
                    tbArea.Text = landList.TotalArea.ToString();
                    break;
                }
            }
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new RealEstateList().ShowDialog();
        }

        private void TbCity_PreviewTextInput( object sender, TextCompositionEventArgs e )
        {
            bool city = tbCity.Text.Any( Char.IsNumber );
            if ( city == true )
            {
                MessageBox.Show( "Поле город не может содержать числовые значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                tbCity.Text = "";
            } 
        }
        

        private void BtnOk_Click( object sender, RoutedEventArgs e )
        {
            if ( role == "edit" )
            {
                var estateList = Setting.db.RealEstate.FirstOrDefault( x => x.IdRealEstate == idObjectEdit );
                estateList.AddressCity = tbCity.Text;
                estateList.AddressHouse = tbHouse.Text;
                estateList.AddressNumder = tbNumber.Text;
                estateList.AddressStreet = tbStreet.Text;
                estateList.CoordinateLatitude = ( tbCoordinateLatitude.Text == "" ) ? 0 : Convert.ToDouble( tbCoordinateLatitude.Text);
                estateList.CoordinateLongitude = (tbCoordinateLongitude.Text == "") ? 0 : Convert.ToDouble( tbCoordinateLongitude.Text);

                switch ( typeEstate )
                {
                    case 1://дом
                    var houseList = Setting.db.House.FirstOrDefault( x => x.IdHouse == idObjectEdit );
                    houseList.TotalArea = Convert.ToDouble(tbArea.Text);
                    houseList.TotalFloors = Convert.ToInt32(tbFloor.Text);
                    houseList.TotalRooms = Convert.ToInt32(tbRoom.Text);
                    break;

                    case 2://квартира
                    var apartList = Setting.db.Apartment.FirstOrDefault( x => x.IdApartment == idObjectEdit );
                    apartList.TotalArea = Convert.ToDouble( tbArea.Text );
                    apartList.Floor = Convert.ToInt32( tbFloor.Text );
                    apartList.Rooms = Convert.ToInt32( tbRoom.Text );
                    break;

                    case 3://участок
                    var landList = Setting.db.Land.FirstOrDefault( x => x.IdLand == idObjectEdit );
                    landList.TotalArea = Convert.ToDouble(tbArea.Text);
                    break;
                }

                Setting.db.SaveChanges();
                MessageBox.Show( "Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            else
            {
                //добавление
                if(typeEstate == 0 )
                {
                    MessageBox.Show( "Выберите тип объекта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }

                RealEstate add = new RealEstate
                {
                    AddressCity = tbCity.Text,
                    AddressHouse = tbHouse.Text,
                    AddressNumder = tbNumber.Text,
                    AddressStreet = ( tbStreet.Text == "" ) ? "" : tbStreet.Text,
                    CoordinateLatitude = ( tbCoordinateLatitude.Text == "" ) ? 0 : Convert.ToDouble( tbCoordinateLatitude.Text ),
                    CoordinateLongitude = ( tbCoordinateLongitude.Text == "" ) ? 0 : Convert.ToDouble( tbCoordinateLongitude.Text ),
                    Type = typeEstate
                };
                Setting.db.RealEstate.Add( add );
                Setting.db.SaveChanges();

                id = Convert.ToInt32( Setting.db.RealEstate.Max( x => x.IdRealEstate ).ToString() );
                

                switch ( typeEstate )
                {
                    case 1:
                    House addHouse = new House
                    {
                        IdHouse = id,
                        TotalArea = ( tbArea.Text == "" ) ? 0 : Convert.ToDouble( tbArea.Text ),
                        TotalFloors = ( tbFloor.Text == "" ) ? 0 : Convert.ToInt32( tbFloor.Text ),
                        TotalRooms = ( tbRoom.Text == "" ) ? 0 : Convert.ToInt32( tbRoom.Text )
                    };
                    Setting.db.House.Add( addHouse );
                    break;
                    case 2:
                    Apartment addApartment = new Apartment()
                    {
                        IdApartment = id,
                        TotalArea = ( tbArea.Text == "" ) ? 0 :  Convert.ToDouble( tbArea.Text ),
                        Rooms = ( tbRoom.Text == "" ) ? 0 : Convert.ToInt32( tbRoom.Text ),
                        Floor = ( tbFloor.Text == "" ) ? 0 : Convert.ToInt32( tbFloor.Text )
                    };
                    Setting.db.Apartment.Add( addApartment );
                    break;
                    case 3:
                    Land addLand = new Land
                    {
                        IdLand = id,
                        TotalArea = Convert.ToDouble( tbArea.Text ),
                    };
                    Setting.db.Land.Add( addLand );
                    break;

                }
                Setting.db.SaveChanges();
                MessageBox.Show( "Новый объект добавлени в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            this.Hide();
            new RealEstateList().ShowDialog();
        }
    }
}

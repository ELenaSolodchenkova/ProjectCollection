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
    /// Логика взаимодействия для DemandEdit.xaml
    /// </summary>
    public partial class DemandEdit : Window
    {
        int id;
        public string role;
        public int idObjectFilter, typeEstate = 0;

        public DemandEdit()
        {
            InitializeComponent();
        }

        private void FormStyle()
        {
            row2.Height = new GridLength(0);
            row3.Height = new GridLength(0);
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Height = 545;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbType.SelectedIndex)
            {
                case 0:
                    this.FormStyle();
                    row2.Height = new GridLength(40);
                    row3.Height = new GridLength(40);
                    Application.Current.MainWindow.Height = 637.963;
                    typeEstate = 1;
                    break;
                case 1:
                    this.FormStyle();
                    row2.Height = new GridLength(40);
                    row3.Height = new GridLength(40);
                    Application.Current.MainWindow.Height = 637.963;
                    typeEstate = 2;
                    break;
                case 2:
                    this.FormStyle();
                    typeEstate = 3;
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DemandList().ShowDialog();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cmbAgent.Text) || string.IsNullOrWhiteSpace(cmbClient.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if(role == "edit")
            {
                var filterList = Setting.db.Demand.FirstOrDefault(x => x.IdDemand == idObjectFilter);
                filterList.AddressCity = (tbCity.Text == "") ? "" : tbCity.Text;
                filterList.AddressHouse = (tbHouse.Text == "") ? "" : tbHouse.Text;
                filterList.AddressNumber = (tbNumber.Text == "") ? "" : tbNumber.Text;
                filterList.AddressStreet = (tbStreet.Text == "") ? "" : tbStreet.Text;
                filterList.MinPrice = (tbMinPrice.Text == "") ? 0 : Convert.ToInt32(tbMinPrice.Text);
                filterList.MaxPrice = (tbMaxPrice.Text == "") ? 0 : Convert.ToInt32(tbMaxPrice.Text);
                filterList.IdAgent = Convert.ToInt32(cmbAgent.SelectedValue);
                filterList.IdClient = Convert.ToInt32(cmbClient.SelectedValue);

                switch (typeEstate)
                {
                    case 1:
                        filterList.RealEstateFilter.HouseFilter.MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text);
                        filterList.RealEstateFilter.HouseFilter.MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text);
                        filterList.RealEstateFilter.HouseFilter.MinFloors = (tbMinFloor.Text == "") ? 0 : Convert.ToInt32(tbMinFloor.Text);
                        filterList.RealEstateFilter.HouseFilter.MaxFloors = (tbMaxFloor.Text == "") ? 0 : Convert.ToInt32(tbMaxFloor.Text);
                        filterList.RealEstateFilter.HouseFilter.MinRooms = (tbMinRoom.Text == "") ? 0 : Convert.ToInt32(tbMinRoom.Text);
                        filterList.RealEstateFilter.HouseFilter.MaxRooms = (tbMaxRoom.Text == "") ? 0 : Convert.ToInt32(tbMaxRoom.Text);
                        break;
                    case 2:
                        filterList.RealEstateFilter.ApartmentFilter.MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text);
                        filterList.RealEstateFilter.ApartmentFilter.MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text);
                        filterList.RealEstateFilter.ApartmentFilter.MinFloor = (tbMinFloor.Text == "") ? 0 : Convert.ToInt32(tbMinFloor.Text);
                        filterList.RealEstateFilter.ApartmentFilter.MaxFloor = (tbMaxFloor.Text == "") ? 0 : Convert.ToInt32(tbMaxFloor.Text);
                        filterList.RealEstateFilter.ApartmentFilter.MinRooms = (tbMinRoom.Text == "") ? 0 : Convert.ToInt32(tbMinRoom.Text);
                        filterList.RealEstateFilter.ApartmentFilter.MaxRooms = (tbMaxRoom.Text == "") ? 0 : Convert.ToInt32(tbMaxRoom.Text);
                        break;
                    case 3:
                        filterList.RealEstateFilter.LandFilter.MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text);
                        filterList.RealEstateFilter.LandFilter.MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text);
                        break;
                }

                Setting.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if(typeEstate == 0)
                {
                    MessageBox.Show("Выберите тип объекта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Demand addDemand = new Demand
                {
                    AddressCity = (tbCity.Text == "") ? "" : tbCity.Text,
                    AddressHouse = (tbHouse.Text == "") ? "" : tbHouse.Text,
                    AddressNumber = (tbNumber.Text == "") ? "" : tbNumber.Text,
                    AddressStreet = (tbStreet.Text == "") ? "" : tbStreet.Text,
                    MinPrice = (tbMinPrice.Text == "") ? 0 : Convert.ToInt32(tbMinPrice.Text),
                    MaxPrice = (tbMaxPrice.Text == "") ? 0 : Convert.ToInt32(tbMaxPrice.Text),
                    IdAgent = Convert.ToInt32(cmbAgent.SelectedValue),
                    IdClient = Convert.ToInt32(cmbClient.SelectedValue)
                };
                Setting.db.Demand.Add(addDemand);
                Setting.db.SaveChanges();

                id = Convert.ToInt32(Setting.db.Demand.Max(x => x.IdDemand).ToString());
                
                RealEstateFilter addFilter = new RealEstateFilter
                {
                    IdRealEstateFilter = id,
                    Type = typeEstate
                };
                Setting.db.RealEstateFilter.Add(addFilter);
                
                switch (typeEstate)
                {
                    case 1:
                        HouseFilter addHouse = new HouseFilter
                        {
                            IdHouseFilter = id,
                            MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text),
                            MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text),
                            MinFloors = (tbMinFloor.Text == "") ? 0 : Convert.ToInt32(tbMinFloor.Text),
                            MaxFloors = (tbMaxFloor.Text == "") ? 0 : Convert.ToInt32(tbMaxFloor.Text),
                            MinRooms = (tbMinRoom.Text == "") ? 0 : Convert.ToInt32(tbMinRoom.Text),
                            MaxRooms = (tbMaxRoom.Text == "") ? 0 : Convert.ToInt32(tbMaxRoom.Text),
                        };
                        Setting.db.HouseFilter.Add(addHouse);
                        break;
                    case 2:
                        ApartmentFilter addApart = new ApartmentFilter
                        {
                            IdApartmentFilter = id,
                            MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text),
                            MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text),
                            MinFloor = (tbMinFloor.Text == "") ? 0 : Convert.ToInt32(tbMinFloor.Text),
                            MaxFloor = (tbMaxFloor.Text == "") ? 0 : Convert.ToInt32(tbMaxFloor.Text),
                            MinRooms = (tbMinRoom.Text == "") ? 0 : Convert.ToInt32(tbMinRoom.Text),
                            MaxRooms = (tbMaxRoom.Text == "") ? 0 : Convert.ToInt32(tbMaxRoom.Text),
                        };
                        Setting.db.ApartmentFilter.Add(addApart);
                        break;
                    case 3:
                        LandFilter addLand = new LandFilter
                        {
                            IdLaneFilter = id,
                            MinArea = (tbMinArea.Text == "") ? 0 : Convert.ToDouble(tbMinArea.Text),
                            MaxArea = (tbMaxArea.Text == "") ? 0 : Convert.ToDouble(tbMaxArea.Text)
                        };
                        Setting.db.LandFilter.Add(addLand);
                        break;
                }
                Setting.db.SaveChanges();
                MessageBox.Show("Новый объект добавлени в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            this.Hide();
            new DemandList().ShowDialog();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            this.FormStyle();

            var agentList = Setting.db.Agent.ToList();
            cmbAgent.ItemsSource = agentList;
            cmbAgent.DisplayMemberPath = "Name";
            cmbAgent.SelectedValuePath = "IdAgent";

            var clientList = Setting.db.Client.ToList();
            cmbClient.ItemsSource = clientList;
            cmbClient.DisplayMemberPath = "Name";
            cmbClient.SelectedValuePath = "IdClient";

            if (role == "edit")
            {
                cmbType.IsEnabled = false;

                var filterList = Setting.db.Demand.FirstOrDefault(x => x.IdDemand == idObjectFilter);
                tbCity.Text = filterList.AddressCity;
                tbHouse.Text = filterList.AddressHouse;
                tbNumber.Text = filterList.AddressNumber;
                tbStreet.Text = filterList.AddressStreet;
                tbMaxPrice.Text = filterList.MaxPrice.ToString();
                tbMinPrice.Text = filterList.MinPrice.ToString();
                cmbAgent.SelectedValue = filterList.IdAgent;
                cmbClient.SelectedValue = filterList.IdClient;

                switch (typeEstate)
                {
                    case 1:
                        this.FormStyle();
                        row2.Height = new GridLength(40);
                        row3.Height = new GridLength(40);
                        Application.Current.MainWindow.Height = 637.963;

                        tbMaxArea.Text = filterList.RealEstateFilter.HouseFilter.MaxArea.ToString();
                        tbMinArea.Text = filterList.RealEstateFilter.HouseFilter.MinArea.ToString();
                        tbMaxFloor.Text = filterList.RealEstateFilter.HouseFilter.MaxFloors.ToString();
                        tbMinFloor.Text = filterList.RealEstateFilter.HouseFilter.MinFloors.ToString();
                        tbMaxRoom.Text = filterList.RealEstateFilter.HouseFilter.MaxRooms.ToString();
                        tbMinRoom.Text = filterList.RealEstateFilter.HouseFilter.MinRooms.ToString();

                        break;
                    case 2:
                        this.FormStyle();
                        row2.Height = new GridLength(40);
                        row3.Height = new GridLength(40);
                        Application.Current.MainWindow.Height = 637.963;

                        tbMaxArea.Text = filterList.RealEstateFilter.ApartmentFilter.MaxArea.ToString();
                        tbMinArea.Text = filterList.RealEstateFilter.ApartmentFilter.MinArea.ToString();
                        tbMaxFloor.Text = filterList.RealEstateFilter.ApartmentFilter.MaxFloor.ToString();
                        tbMinFloor.Text = filterList.RealEstateFilter.ApartmentFilter.MinFloor.ToString();
                        tbMaxRoom.Text = filterList.RealEstateFilter.ApartmentFilter.MaxRooms.ToString();
                        tbMinRoom.Text = filterList.RealEstateFilter.ApartmentFilter.MinRooms.ToString();

                        break;
                    case 3:
                        this.FormStyle();
                        
                        tbMaxArea.Text = filterList.RealEstateFilter.LandFilter.MaxArea.ToString();
                        tbMinArea.Text = filterList.RealEstateFilter.LandFilter.MinArea.ToString();
                        break;
                }
            }
                
        }
    }
}

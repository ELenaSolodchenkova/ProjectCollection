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
    /// Логика взаимодействия для SupplyEdit.xaml
    /// </summary>
    public partial class SupplyEdit : Window
    {
        public int idSup = 0;
        public SupplyEdit()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new SupplyList().ShowDialog();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            var agentList = Setting.db.Agent.ToList();
            cmbAgent.ItemsSource = agentList;
            cmbAgent.DisplayMemberPath = "Name";
            cmbAgent.SelectedValuePath = "IdAgent";

            var clientList = Setting.db.Client.ToList();
            cmbClient.ItemsSource = clientList;
            cmbClient.DisplayMemberPath = "Name";
            cmbClient.SelectedValuePath = "IdClient";

            foreach(var id in Setting.db.RealEstate.Select(x => x.IdRealEstate))
            {
                cmbObject.Items.Add(id);
            }

            if (idSup != 0)
            {
                var supList = Setting.db.Supply.FirstOrDefault(x => x.IdSupply == idSup);
                tbPrice.Text = supList.Price.ToString();
                cmbAgent.SelectedValue = supList.IdAgent;
                cmbObject.SelectedItem = supList.IdRealEstate;
                cmbClient.SelectedValue = supList.IdClient;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbPrice.Text) || string.IsNullOrWhiteSpace(cmbAgent.Text) || string.IsNullOrWhiteSpace(cmbClient.Text) || string.IsNullOrWhiteSpace(cmbObject.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (idSup == 0)
            {
                Supply addSup = new Supply
                {
                    IdAgent = Convert.ToInt32(cmbAgent.SelectedValue),
                    IdClient = Convert.ToInt32(cmbClient.SelectedValue),
                    IdRealEstate = Convert.ToInt32(cmbObject.SelectedValue),
                    Price = Convert.ToInt32(tbPrice.Text)
                };
                Setting.db.Supply.Add(addSup);
            }
            else
            {
                var supList = Setting.db.Supply.FirstOrDefault(x => x.IdSupply == idSup);
                supList.IdAgent = Convert.ToInt32(cmbAgent.SelectedValue);
                supList.IdClient = Convert.ToInt32(cmbClient.SelectedValue);
                supList.IdRealEstate = Convert.ToInt32(cmbObject.SelectedValue);
                supList.Price = Convert.ToInt32(tbPrice.Text);
            }
            Setting.db.SaveChanges();
            MessageBox.Show("Опреция завершина", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Hide();
            new SupplyList().ShowDialog();
        }
    }
}

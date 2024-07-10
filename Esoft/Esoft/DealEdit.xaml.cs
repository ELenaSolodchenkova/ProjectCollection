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
    /// Логика взаимодействия для DealEdit.xaml
    /// </summary>
    public partial class DealEdit : Window
    {
        List<int> listDemand = new List<int>();
        List<int> listSupply = new List<int>();

        public int dealId;
        public string role;

        public DealEdit()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new DealList().ShowDialog();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            var demList = Setting.db.Deal.Select(x => x.IdDemand).ToList();
            var supList = Setting.db.Deal.Select(x => x.IdSupply).ToList();

            //потребность
            foreach (var demand in Setting.db.Demand.Select(x => x.IdDemand))
            {
                if (!demList.Contains(demand))
                {
                    listDemand.Add(demand);
                }
            }
            foreach (var item in listDemand)
            {
                cmbDemand.Items.Add(item);
            }
           
            //предложение
            foreach(var supply in Setting.db.Supply.Select(x => x.IdSupply))
            {
                if (!supList.Contains(supply))
                {
                    listSupply.Add(supply);
                }
            }
            foreach (var item in listSupply)
            {
                cmbSupply.Items.Add(item);
            }

            if(role == "edit")
            {
                var deal = Setting.db.Deal.FirstOrDefault(x => x.IdDeal == dealId);
                foreach (var item in Setting.db.Deal.Where(x => x.IdDeal == dealId))
                {
                    cmbDemand.Items.Add(item.IdDemand);
                    cmbSupply.Items.Add(item.IdSupply);
                }
                cmbDemand.SelectedValue = deal.IdDemand;
                cmbSupply.SelectedValue = deal.IdSupply;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cmbSupply.Text) || string.IsNullOrWhiteSpace(cmbDemand.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (role == "edit")
            {
                var edit = Setting.db.Deal.FirstOrDefault(x => x.IdDeal == dealId);
                edit.IdDemand = Convert.ToInt32(cmbDemand.SelectedValue);
                edit.IdSupply = Convert.ToInt32(cmbSupply.SelectedValue);
                MessageBox.Show("Данные изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                Deal add = new Deal
                {
                    IdDemand = Convert.ToInt32(cmbDemand.SelectedValue),
                    IdSupply = Convert.ToInt32(cmbSupply.SelectedValue)
                };
                Setting.db.Deal.Add(add);
                MessageBox.Show("Сделка оформлена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Setting.db.SaveChanges();            
            this.Hide();
            new DealList().ShowDialog();
        }
    }
}

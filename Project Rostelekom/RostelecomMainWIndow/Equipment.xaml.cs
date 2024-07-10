using RostelecomMainWIndow.Resources;
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

namespace RostelecomMainWIndow
{
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        int inEqId;
        public Equipment()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnBacks_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new CliSE().ShowDialog();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

     /*   private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string s1 = tbFindInEqName.Text, s2;
            int count;
            List<InstalledEquipment> listInEq = new List<InstalledEquipment>();
            var listFind = DB.db.EquipmentLists.Select(x => x.Name).ToList();
            for (int i = 0; i < listFind.Count; i++)
            {
                s2 = Convert.ToString(listFind[i]);
                count = FuzzySearch.Levenshtain(s1, s2);

                if (count <= 3)
                {
                    foreach (var list in DB.db.EquipmentLists.Where(x => x.Name == s2))
                    {
                        if()
                        listInEq.Add(list);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgvEqPurchases.ItemsSource = DB.db.InstalledEquipments.ToList();
        }*/


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (inEqId == 0)
            {
                MessageBox.Show("Для редактирования необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new InstalledEqAdd();
            edit.idce = inEqId;
            edit.ShowDialog();
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (inEqId == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    InstalledEquipment delInEq = DB.db.InstalledEquipments.Where(x => x.IdCE == inEqId).FirstOrDefault();
                    DB.db.InstalledEquipments.Remove(delInEq);
                    DB.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvEqPurchases.ItemsSource = DB.db.InstalledEquipments.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new InstalledEqAdd().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvEqPurchases.CanUserAddRows = false;
            dgvEqPurchases.ItemsSource = DB.db.InstalledEquipments.ToList();
        }

        private void dgvEqPurchases_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                InstalledEquipment row = dgvEqPurchases.SelectedItem as InstalledEquipment;
                inEqId = row.IdCE;

            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Interaction logic for EqList.xaml
    /// </summary>
    public partial class EqList : Window
    {
        int idEq;
        public EqList()
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
            new MainMenu().ShowDialog();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idEq == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    EquipmentList delEq = DB.db.EquipmentLists.Where(x => x.IdEquipment == idEq).FirstOrDefault();
                    DB.db.EquipmentLists.Remove(delEq);
                    DB.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgvEq.ItemsSource = DB.db.EquipmentLists.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (idEq == 0)
            {
                MessageBox.Show("Для редактирование необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.Hide();
            var edit = new AddEqu();
            edit.addEqId = idEq;
            edit.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AddEqu().ShowDialog();
        }

        private void dgvEq_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EquipmentList row = dgvEq.SelectedItem as EquipmentList;
                idEq = row.IdEquipment;

            }
            catch
            {
                MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string s1 = tbFindNameEq.Text,s2;
            int count;
            List<EquipmentList> listEqu = new List<EquipmentList>();
            var listFind = DB.db.EquipmentLists.Select(x => x.Name).ToList();
            for (int i = 0; i < listFind.Count; i++)
            {
                s2 = Convert.ToString(listFind[i]);
                count = FuzzySearch.Levenshtain(s1, s2);
                if (count <= 3)
                {
                    foreach (var list in DB.db.EquipmentLists.Where(x => x.Name == s2))
                    {
                        listEqu.Add(list);
                    }
                }
            }
            dgvEq.ItemsSource = listEqu;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            dgvEq.ItemsSource = DB.db.EquipmentLists.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvEq.CanUserAddRows = false;
            dgvEq.ItemsSource = DB.db.EquipmentLists.ToList();
        }

        /*  private void btnFind_Click(object sender, RoutedEventArgs e)
          {
              string s1 = tbFindNameEq.Text,s2;
              int count;
              List<EquipmentList> listClient = new List<EquipmentList>();
              var listFind = DB.db.EquipmentLists.Select(x => x.Name).ToList();
              for (int i = 0; i < listFind.Count; i++)
              {
                  s2 = Convert.ToString(listFind[i]);
                  count = FuzzySearch.Levenshtain(s1, s2);
                  if (count <= 3)
                  {
                      foreach (var list in DB.db.EquipmentLists.Where(x => x.Name == s2))
                      {
                          listClient.Add(list);
                      }
                  }
              }
              dgvEq.ItemsSource = listClient;
          }

          private void btnUpdate_Click(object sender, RoutedEventArgs e)
          {
              dgvEq.ItemsSource = DB.db.EquipmentLists.ToList();
          }

          private void btnAdd_Click(object sender, RoutedEventArgs e)
          {
              this.Hide();
              new AddEqu().ShowDialog();
          }

          private void btnEdit_Click(object sender, RoutedEventArgs e)
          {
              if (idEq == 0)
              {
                  MessageBox.Show("Для редактирование необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                  return;
              }
              this.Hide();
              var edit = new AddEqu();
              edit.addEqId = idEq;
              edit.ShowDialog();
          }

          private void btnDelete_Click(object sender, RoutedEventArgs e)
          {
              try
              {
                  if (idEq == 0)
                  {
                      MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                      return;
                  }

                  if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                  {
                      EquipmentList delEq = DB.db.EquipmentLists.Where(x => x.IdEquipment == idEq).FirstOrDefault();
                      DB.db.EquipmentLists.Remove(delEq);
                      DB.db.SaveChanges();
                      MessageBox.Show("Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                      dgvEq.ItemsSource = DB.db.EquipmentLists.ToList();
                  }
              }
              catch
              {
                  MessageBox.Show("Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
              }
          }*/
    }
}
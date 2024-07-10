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
    /// Interaction logic for AddEqu.xaml
    /// </summary>
    public partial class AddEqu : Window
    {
        public int addEqId;
        public AddEqu()
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (addEqId != 0)
            {
                var eqList = DB.db.EquipmentLists.FirstOrDefault(x => x.IdEquipment == addEqId);
                tbNameEq.Text = eqList.Name;
                tbDescription.Text = eqList.Description;
                tbPrice.Text = Convert.ToString(eqList.Price);
                DB.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (addEqId == 0)
            {
                EquipmentList add = new EquipmentList
                {
                    Name = tbNameEq.Text,
                    Description = tbDescription.Text,
                    Price = Convert.ToDecimal(tbPrice.Text)
                };
                DB.db.EquipmentLists.Add(add);
                DB.db.SaveChanges();
                MessageBox.Show("Новый товар добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Hide();
            new EqList().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (addEqId != 0)
            {
                var eqList = DB.db.EquipmentLists.FirstOrDefault(x => x.IdEquipment == addEqId);
                tbNameEq.Text = eqList.Name;
                tbDescription.Text = eqList.Description;
                tbPrice.Text = Convert.ToString(eqList.Price);
            }
        }
    }
}

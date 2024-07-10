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
    /// Interaction logic for InstalledEqAdd.xaml
    /// </summary>
    public partial class InstalledEqAdd : Window
    {
        public int idce;
        public InstalledEqAdd()
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
            new Equipment().ShowDialog();
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
            if (string.IsNullOrEmpty(tbClientId.Text))
            {
                if (string.IsNullOrEmpty(tbEqId.Text))
                {
                    MessageBox.Show("Поля ID клиента и ID товара должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (idce != 0)
            {
                    var ineqList = DB.db.InstalledEquipments.FirstOrDefault(x => x.IdCE == idce);
                    ineqList.IdClient = Convert.ToInt32(tbClientId.Text);
                    ineqList.IdEquipment = Convert.ToInt32(tbEqId.Text);
                    ineqList.Date = Convert.ToDateTime(tbDate.Text);
                    DB.db.SaveChanges();
                    MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }

            if (idce == 0)
            {
                InstalledEquipment add = new InstalledEquipment
                {
                    Date = Convert.ToDateTime(tbDate.Text),
                    IdClient = Convert.ToInt32(tbClientId.Text),
                    IdEquipment = Convert.ToInt32(tbEqId.Text)
                    
                };
                DB.db.InstalledEquipments.Add(add);
                DB.db.SaveChanges();
                MessageBox.Show("Новый клиент добавлен в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Hide();
            new Equipment().ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (idce != 0)
            {
                    var ineqList = DB.db.InstalledEquipments.FirstOrDefault(x => x.IdCE == idce);
                    tbEqId.Text = Convert.ToString(ineqList.IdEquipment);
                    tbClientId.Text = Convert.ToString(ineqList.IdClient);
                    tbDate.Text = Convert.ToString(ineqList.Date);
                
            }
        }
    }
}

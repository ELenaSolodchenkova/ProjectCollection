using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ZapSibNeftehim.Models;

using MessageBox = System.Windows.Forms.MessageBox;

namespace ZapSibNeftehim.Pages
{
    /// <summary>
    /// Логика взаимодействия для Laborant.xaml
    /// </summary>
    public partial class Laborant : Page
    {
        public Laborant()
        {
            InitializeComponent();
            if (DateTime.Now.Hour <= 6 && DateTime.Now.Hour >= 00)
                tbUserInfo.Text = $"Доброй ночи, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <= 15 && DateTime.Now.Hour > 6)
                tbUserInfo.Text = $"Добрый день, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <= 21 && DateTime.Now.Hour > 12)
                tbUserInfo.Text = $"Добрый вечер, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <= 23 && DateTime.Now.Hour > 21)
                tbUserInfo.Text = $"Доброй ночи, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";

        }

        private void lvEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            lvEmployees.ItemsSource = App.ZSNdb.Employees.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var employeeChosen = (Employee)lvEmployees.SelectedItem;
           if (lvEmployees.SelectedItem == null)
            {
                MessageBox.Show("select");
                return;
            }
            var editWind = new Windows.EmployeesEdit(employeeChosen);
            editWind.ShowDialog();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            var employeeChosen = (Employee)lvEmployees.SelectedItem;

            if (employeeChosen == null)
                return;
            var deletEmployee = App.ZSNdb.Employees.Find(employeeChosen.ID);
            App.ZSNdb.Employees.Remove(deletEmployee);
        }
    }
}

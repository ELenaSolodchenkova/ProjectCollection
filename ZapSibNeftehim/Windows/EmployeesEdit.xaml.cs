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
using ZapSibNeftehim.Models;

namespace ZapSibNeftehim.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeesEdit.xaml
    /// </summary>
    public partial class EmployeesEdit : Window
    {
       public Employee employee {  get; set; }
      
        public EmployeesEdit(Employee emp = null)
        {
            employee = emp ?? new Employee();
          
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstNameTextBox.Text = employee.firstName;
            LastNameTextBox.Text = employee.lastName;

            var emPosition = App.ZSNdb.Positions.ToList();
            TypeUserComboBox.ItemsSource = emPosition;

            if (employee.ID > 0)
                TypeUserComboBox.SelectedIndex = emPosition.IndexOf(emPosition.First(x => x.ID == employee.ID));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee.firstName = FirstNameTextBox.Text;
            employee.lastName = LastNameTextBox.Text;

            employee.positionID = ((Position)TypeUserComboBox.SelectedItem).ID;
        }
    }
}

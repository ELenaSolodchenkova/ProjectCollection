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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZapSibNeftehim.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(DateTime.Now.Hour <= 6 && DateTime.Now.Hour >= 00)
            tbUserInfo.Text = $"Доброй ночи, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <=15  && DateTime.Now.Hour > 6)
                tbUserInfo.Text = $"Добрый день, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <= 21 && DateTime.Now.Hour > 12)
                tbUserInfo.Text = $"Добрый вечер, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";
            if (DateTime.Now.Hour <=23  && DateTime.Now.Hour > 21)
                tbUserInfo.Text = $"Доброй ночи, {App.CurrentEmployee.lastName} {App.CurrentEmployee.firstName}, {App.CurrentEmployee.Position.name}";

          
        }

        private void dgLoginHistory_Loaded(object sender, RoutedEventArgs e)
        {
            dgLoginHistory.ItemsSource = App.ZSNdb.LoginHistories.ToList();
         
        }
    }
}

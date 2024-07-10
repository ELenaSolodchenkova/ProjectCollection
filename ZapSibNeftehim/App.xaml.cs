using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using ZapSibNeftehim.Models;

namespace ZapSibNeftehim
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ZSNEntities ZSNdb {  get; set; }
        public static Employee CurrentEmployee { get; set; }
        public static Frame MainFrame { get; set; }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "Ошибка подключения к базе данных", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                ZSNdb = new ZSNEntities();
                ZSNdb.Database.Connection.Open();
                ZSNdb.Clients.ToList();
                ZSNdb.Companies.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK);
            }
            base.OnStartup(e);
        }
    }
}

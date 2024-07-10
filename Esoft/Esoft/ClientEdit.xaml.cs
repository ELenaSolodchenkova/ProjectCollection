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
    /// Логика взаимодействия для ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : Window
    {
        public int clientId;

        public ClientEdit()
        {
            InitializeComponent();
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new ClientWindow().ShowDialog();
        }

        private void BtnOk_Click( object sender, RoutedEventArgs e )
        {
            if ( string.IsNullOrEmpty( tbEmail.Text ) )
            {
                if ( string.IsNullOrEmpty( tbPhone.Text ) )
                {
                    MessageBox.Show( "Одно из полей электронная почта или телефонный номер обязаательно должно быть заполнено!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }
            }

            if ( clientId != 0 ) {
                var clientList = Setting.db.Client.FirstOrDefault( x => x.IdClient == clientId );
                clientList.LastName = tbLastName.Text;
                clientList.MiddleName = tbMiddleName.Text;
                clientList.Phone = tbPhone.Text;
                clientList.FirstName = tbFirstName.Text;
                clientList.Email = tbEmail.Text;              
                Setting.db.SaveChanges();
                MessageBox.Show( "Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
            }

            if ( clientId == 0 )
            {
                Client add = new Client
                {
                    FirstName = tbFirstName.Text,
                    MiddleName = tbMiddleName.Text,
                    LastName = tbLastName.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text
                };
                Setting.db.Client.Add( add );
                Setting.db.SaveChanges();
                MessageBox.Show( "Новый клиент добавлени в базу", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
            }

            this.Hide();
            new ClientWindow().ShowDialog();

        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            if ( clientId != 0 )
            {
                var clientList = Setting.db.Client.FirstOrDefault( x => x.IdClient == clientId );
                tbEmail.Text = clientList.Email;
                tbFirstName.Text = clientList.FirstName;
                tbLastName.Text = clientList.LastName;
                tbMiddleName.Text = clientList.MiddleName;
                tbPhone.Text = clientList.Phone;
            }
        }
    }
}

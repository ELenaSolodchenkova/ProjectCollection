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
    /// Логика взаимодействия для AgentEdit.xaml
    /// </summary>
    public partial class AgentEdit : Window
    {
        public int agentId;

        public AgentEdit()
        {
            InitializeComponent();
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new AgentList().ShowDialog();
        }

        private void BtnOk_Click( object sender, RoutedEventArgs e )
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                MessageBox.Show( "ФИО поля обязательные к заполнению", "Информация", MessageBoxButton.OK, MessageBoxImage.Information );
                return;
            }

            if(Convert.ToInt32(tbDealShare.Text) < 0 || Convert.ToInt32( tbDealShare.Text ) > 100 )
            {
                MessageBox.Show( "Поле может принимать значение от 0 до 100", "Информация", MessageBoxButton.OK, MessageBoxImage.Information );
                return;
            }

            if(agentId != 0 )
            {
                var agentList = Setting.db.Agent.FirstOrDefault( x => x.IdAgent == agentId );
                agentList.FirstName = tbFirstName.Text;
                agentList.MiddleName = tbMiddleName.Text;
                agentList.LastName = tbLastName.Text;
                agentList.DealShare = Convert.ToInt32(tbDealShare.Text);
                Setting.db.SaveChanges();
                MessageBox.Show( "Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
            }

            if(agentId == 0 )
            {
                Agent addAgent = new Agent
                {
                    FirstName = tbFirstName.Text,
                    MiddleName = tbMiddleName.Text,
                    LastName = tbLastName.Text,
                    DealShare = Convert.ToInt32( tbDealShare.Text )
                };
                Setting.db.Agent.Add( addAgent );
                Setting.db.SaveChanges();
                MessageBox.Show( "Новый риэлтор добавлен в базу", "Информация", MessageBoxButton.OK, MessageBoxImage.Information );
            }
            this.Hide();
            new AgentList().ShowDialog();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            if(agentId != 0 )
            {
                var agentList = Setting.db.Agent.FirstOrDefault(x=>x.IdAgent==agentId);
                tbDealShare.Text = agentList.DealShare.ToString();
                tbFirstName.Text = agentList.FirstName;
                tbLastName.Text = agentList.LastName;
                tbMiddleName.Text = agentList.MiddleName;
            }
        }
    }
}

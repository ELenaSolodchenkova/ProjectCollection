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
    /// Логика взаимодействия для AgentList.xaml
    /// </summary>
    public partial class AgentList : Window
    {
        int agentId;

        public AgentList()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            dgvAgentList.ItemsSource = Setting.db.Agent.ToList();
        }

        private void BtnBack_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new MainWindow().ShowDialog();
        }

        private void BtnAdd_Click( object sender, RoutedEventArgs e )
        {
            this.Hide();
            new AgentEdit().ShowDialog();
        }

        private void DgvAgentList_MouseUp( object sender, MouseEventArgs e )
        {
            try
            {
                Agent row = dgvAgentList.SelectedItem as Agent;
                agentId = row.IdAgent;
            }
            catch
            {
                MessageBox.Show( "Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void BtnEdit_Click( object sender, RoutedEventArgs e )
        {
            if(agentId == 0 )
            {
                MessageBox.Show( "Для редактирования необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            this.Hide();
            var edit = new AgentEdit();
            edit.agentId = agentId;
            edit.ShowDialog();
        }

        private void BtnUpdate_Click( object sender, RoutedEventArgs e )
        {
            dgvAgentList.ItemsSource = Setting.db.Agent.ToList();
        }

        private void BtnFind_Click( object sender, RoutedEventArgs e )
        {
            string s1 = $"{tbFindFirstName.Text}{tbFindMiddleName.Text}{tbFindLastName.Text}",
                s2;
            int count;
            List<Agent> listAgent = new List<Agent>();           
            var listFind = Setting.db.Agent.Select( x => x.FirstName + x.MiddleName + x.LastName ).ToList();
            for (int i = 0; i<listFind.Count;i++ )
            {
                s2 = Convert.ToString( listFind[i] );
                count = FuzzySearch.Levenshtain( s1, s2 );
                if(count <= 3 )
                {
                    
                    foreach(var list in Setting.db.Agent.Where( x => x.FirstName + x.MiddleName + x.LastName == s2 ) )
                    {
                        listAgent.Add( list );
                    }
                }
            }
            dgvAgentList.ItemsSource = listAgent;
        }

        private void BtnDelete_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                if (agentId == 0)
                {
                    MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var demand = Setting.db.Demand.Where( x => x.IdAgent == agentId ).ToList();
                var supply = Setting.db.Supply.Where( x => x.IdAgent == agentId ).ToList();
                if ( demand.Count != 0 || supply.Count != 0 ) 
                {
                    MessageBox.Show( "Невозможно удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
                    return;
                }
                
                if( MessageBox.Show( "Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question ) == MessageBoxResult.Yes)
                {
                    Agent delAgent = Setting.db.Agent.Where( x => x.IdAgent == agentId ).FirstOrDefault();
                    Setting.db.Agent.Remove( delAgent );
                    Setting.db.SaveChanges();
                    MessageBox.Show( "Запись удалена", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
                    dgvAgentList.ItemsSource = Setting.db.Agent.ToList();
                }
            }
            catch
            {
                MessageBox.Show( "Повторно выберите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void btnSupply_Click(object sender, RoutedEventArgs e)
        {
            if (agentId == 0)
            {
                MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var supply = new SupplyFilter();
            supply.role = "agent";
            supply.idPeople = agentId;
            supply.ShowDialog();
        }

        private void btnDemand_Click(object sender, RoutedEventArgs e)
        {
            if (agentId == 0)
            {
                MessageBox.Show("Необходимо выделить нужную запись в таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var demand = new DemandFilter();
            demand.role = "agent";
            demand.idPeople = agentId;
            demand.ShowDialog();
        }
    }
}

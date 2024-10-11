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

namespace session1.agentpages
{
    /// <summary>
    /// Логика взаимодействия для agents.xaml
    /// </summary>
    public partial class agents : Page
    {
        public agents()
        {
            InitializeComponent();
            List<Agent> agentslist = AppConect.agentmod.Agent.ToList();
            List<Agent> limitag = agentslist.Take(10).ToList();
            listagents.Items.Clear();
            listagents.ItemsSource = limitag;
            
            Combosort.Items.Add("по возрастанию приоритета");
            Combosort.Items.Add("по уменьшению приоритета");
            Combosort.Items.Add("по имени от А-Я");
            Combosort.Items.Add("по имени от Я-А");
            //Combosort.Items.Add("по возрастанию скидки");
            //Combosort.Items.Add("по уменьшению скидки");
            Combofilter.Items.Add("все типы");
            var filter = Entities1.GetContext().AgentType.Select(x => x.Title).ToList();
            filter.Insert(0, "все типы");
            Combofilter.Items.Clear();
            Combofilter.ItemsSource = filter;

        }

        Agent[] findagents()
        {
            List<Agent> agents = AppConect.agentmod.Agent.ToList();
            var agentstall = agents;
            var filter = Entities1.GetContext().AgentType.Select(x => x.Title).ToList();
            if (searctb != null)
            {
                agents = agents.Where(x => x.Title.ToLower().Contains(searctb.Text.ToLower())|| x.Phone.Contains(searctb.Text)).ToList();
            }
            if(Combofilter.SelectedIndex >= 0)
            {
                switch(Combofilter.SelectedIndex)
                {
                    case 0:
                        
                        break;
                    case 1:
                        agents = agents.Where(x => x.AgentTypeID == 1).ToList();
                        break;
                    case 2:
                        agents = agents.Where(x => x.AgentTypeID == 2).ToList();
                        break;
                    case 3:
                        agents = agents.Where(x => x.AgentTypeID == 3).ToList();
                        break;
                    case 4:
                        agents = agents.Where(x => x.AgentTypeID == 4).ToList();
                        break;
                    case 5:
                        agents = agents.Where(x => x.AgentTypeID == 5).ToList();
                        break;
                    case 6:
                        agents = agents.Where(x => x.AgentTypeID == 6).ToList();
                        break;
                }
            }
            if(Combosort.SelectedIndex >= 0)
            {
                switch (Combosort.SelectedIndex)
                {
                    case 0:
                        agents = agents.OrderBy(x => x.Priority).ToList();
                    break;
                    case 1:
                        agents = agents.OrderByDescending(x => x.Priority).ToList();
                        break;
                    case 2:
                        agents = agents.OrderBy(x => x.Title).ToList();
                        break;
                    case 3:
                        agents = agents.OrderByDescending(x => x.Title).ToList();
                        break;
                    //case 4:
                    //    agents = agents.OrderBy(x => x.Title).ToList();
                    //    break;
                    //case 5:
                    //    agents = agents.OrderByDescending(x => x.Title).ToList();
                    //    break;
                }
            }
            listagents.ItemsSource = agents;
            return agents.ToArray();

        }

        private void searctb_KeyDown(object sender, KeyEventArgs e)
        {

                List<Agent> agents = AppConect.agentmod.Agent.ToList();
                var agentsall = agents;
            findagents();
            agents = agents.Where(x => x.Title.ToLower().Contains(searctb.Text.ToLower())).ToList();
            agents = agents.Where(x => x.Phone.Contains(searctb.Text)).ToList();
            
        }

        private void Combosort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            findagents();
        }

        private void Combofilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            findagents();
        }
    }
}

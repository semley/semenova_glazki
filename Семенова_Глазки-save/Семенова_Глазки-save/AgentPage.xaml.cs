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

namespace Семенова_Глазки_save
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            var currentAgent = Семенова_ГлазкиEntities.GetContext().Agent.ToList();

            AgentListView.ItemsSource = currentAgent;
            AgentListView.ItemsSource = currentAgent;
            UpdateServices();
            //Sort.SelectedIndex = 0;
        }

        private void UpdateServices()
        {
            var currentAgent = Семенова_ГлазкиEntities.GetContext().Agent.ToList();

            if (TypeCombo.SelectedIndex == 0)
            {
                currentAgent = currentAgent.ToList();
            }

            if (TypeCombo.SelectedIndex==1)
            {
                currentAgent=currentAgent.Where(p => (p.AgentTypeString == "МФО")).ToList();
            }
            if (TypeCombo.SelectedIndex == 2)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeString == "ООО")).ToList();
            }
            if (TypeCombo.SelectedIndex == 3)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeString == "ЗАО")).ToList();
            }
            if (TypeCombo.SelectedIndex == 4)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeString == "МКК")).ToList();
            }
            if (TypeCombo.SelectedIndex == 5)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeString == "ОАО")).ToList();
            }
            if (TypeCombo.SelectedIndex == 6)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeString == "ПАО")).ToList();
            }
            

            currentAgent = currentAgent.Where(p => p.Title.ToLower().Contains(TBSearch.Text.ToLower()) || p.Phone.Replace("(","").Replace(")", "").Replace(" ", "").Replace("-", "").ToLower().Contains(TBSearch.Text.ToLower()) || p.Email.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            
            if(Sort.SelectedIndex==0)
            {
                currentAgent = currentAgent.OrderBy(p => p.Title).ToList();
            }
            if (Sort.SelectedIndex == 1)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Title).ToList();
            }
            if (Sort.SelectedIndex == 2)
            {
                currentAgent = currentAgent.OrderBy(p => p.Priority).ToList();
            }
            if (Sort.SelectedIndex == 3)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Priority).ToList();
            }
            AgentListView.ItemsSource = currentAgent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }
    }
}

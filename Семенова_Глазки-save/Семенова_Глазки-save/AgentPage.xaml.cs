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
        int CountRecords;
        int CountPage;
        int CurrentPage;
        List<Agent> CurrentPageList = new List<Agent>();
        List<Agent> TableList;
        public ServicePage()
        {
            InitializeComponent();
            var currentAgent = Семенова_ГлазкиEntities.GetContext().Agent.ToList();

            AgentListView.ItemsSource = currentAgent;
            AgentListView.ItemsSource = currentAgent;
            UpdateServices();
            AgentListView.ItemsSource = currentAgent;
            TableList = currentAgent;
            ChangePage(0, 0);
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

        private void ChangePage(int direction, int? selectedPage)
        {
            CurrentPageList.Clear();
            CountRecords = TableList.Count;
            if (CountRecords % 10 > 0)
            {
                CountPage = CountRecords / 10 + 1;
            }
            else
            {
                CountPage = CountRecords / 10;
            }
            Boolean Ifupdate = true;

            int min;

            if (selectedPage.HasValue)
            {
                if (selectedPage >= 0 && selectedPage <= CountPage)
                {
                    CurrentPage = (int)selectedPage;
                    min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                    for (int i = CurrentPage * 10; i < min; i++)
                    {
                        CurrentPageList.Add(TableList[i]);
                    }
                }
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        if (CurrentPage > 0)
                        {
                            CurrentPage--;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {
                                CurrentPageList.Add(TableList[i]);
                            }
                        }
                        else
                        {
                            Ifupdate = false;
                        }
                        break;

                    case 2:
                        if (CurrentPage < CountPage - 1)
                        {
                            CurrentPage++;
                            min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                            for (int i = CurrentPage * 10; i < min; i++)
                            {
                                CurrentPageList.Add(TableList[i]);
                            }
                        }
                        else
                        {
                            Ifupdate = false;
                        }
                        break;


                }

            }
            if (Ifupdate)
            {
                PageListBox.Items.Clear();
                for (int i = 1; i <= CountPage; i++)
                {
                    PageListBox.Items.Add(i);

                }
                PageListBox.SelectedIndex = CurrentPage;

                min = CurrentPage * 10 + 10 < CountRecords ? CurrentPage * 10 + 10 : CountRecords;
                TBCount.Text = min.ToString();
                TBAllRecords.Text = " из " + CountRecords.ToString();

                AgentListView.ItemsSource = CurrentPageList;
                AgentListView.Items.Refresh();
            }
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

        private void LeftDirbutton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1, null);
        }

        private void RightDirButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(2, null);
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, Convert.ToInt32(PageListBox.SelectedItem.ToString())-1);
            
        }
    }
}

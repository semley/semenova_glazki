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
    /// Логика взаимодействия для ProdajiPage.xaml
    /// </summary>
    public partial class ProdajiPage : Page
    {
        
        private Agent currentAgent = new Agent();
        public ProdajiPage(Agent agent)
        {
            InitializeComponent();
            currentAgent = agent;
            var currentSales = Семенова_ГлазкиEntities.GetContext().ProductSale.ToList();
            currentSales = currentSales.Where(p => p.AgentID == currentAgent.ID).ToList();
            AgentSaleListView.ItemsSource = currentSales;
            UpdateSales();
        }

        public void UpdateSales()
        {
            var currentProduct = Семенова_ГлазкиEntities.GetContext().ProductSale.ToList();
            AgentSaleListView.ItemsSource = currentProduct.Where(p => p.AgentID == currentAgent.ID);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new addPage(currentAgent as Agent));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var currentSale = (sender as Button).DataContext as ProductSale;
            var currentSalesList = Семенова_ГлазкиEntities.GetContext().ProductSale.ToList();
            currentSalesList = currentSalesList.Where(p => p.ID == currentSale.ID).ToList();
            if (currentSalesList.Count != 0)
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Семенова_ГлазкиEntities.GetContext().ProductSale.Remove(currentSale);
                        Семенова_ГлазкиEntities.GetContext().SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            UpdateSales();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateSales();
        }
    }
}

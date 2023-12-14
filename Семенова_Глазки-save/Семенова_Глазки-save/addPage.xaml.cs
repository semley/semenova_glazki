﻿using System;
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
    /// Логика взаимодействия для addPage.xaml
    /// </summary>
    public partial class addPage : Page
    {
        private ProductSale currentProductSale = new ProductSale();
        private List<Product> currentProduct;
        private Agent currentAgent = new Agent();
        public addPage(Agent agent)
        {
            InitializeComponent();
            currentAgent = agent;
            currentProduct = Семенова_ГлазкиEntities.GetContext().Product.ToList();
            ComboProduct.ItemsSource = currentProduct;

            DataContext = currentProductSale;
        }

        private void AddProdHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentProductSale.ID == 0)
            {
                Семенова_ГлазкиEntities.GetContext().ProductSale.Add(currentProductSale);
            }
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ProdCount.Text))
            {
                errors.AppendLine("Укажите количество");
            }
            else
            {
                int c = Convert.ToInt32(ProdCount.Text);
                if (c < 1)
                    errors.AppendLine("Укажите количество");
            }
            if (StartDate.Text == "")
                errors.AppendLine("Укажите дату");
            if (ComboProduct.SelectedItem == null)
                errors.AppendLine("Укажите наименование продукта");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            currentProductSale.ProductID = ComboProduct.SelectedIndex + 1;
            currentProductSale.AgentID = currentAgent.ID;
            currentProductSale.ProductCount = Convert.ToInt32(ProdCount.Text);
            currentProductSale.SaleDate = Convert.ToDateTime(StartDate.Text);


            if (currentProductSale.ID == 0)
            {
                Семенова_ГлазкиEntities.GetContext().ProductSale.Add(currentProductSale);
            }




            try
            {
                Семенова_ГлазкиEntities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

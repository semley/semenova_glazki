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

namespace Семенова_Глазки_save
{
    /// <summary>
    /// Логика взаимодействия для EditPriorityWindow.xaml
    /// </summary>
    public partial class EditPriorityWindow : Window
    {
        public EditPriorityWindow(int max)
        {
            InitializeComponent();
            PriorityText.Text = max.ToString();
        }

        private void EditPriority_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PriorityText.Text))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Введите приоритет агентов");
            }
        }

        private void BackPriority_Click(object sender, RoutedEventArgs e)
        {
            PriorityText.Text = "";
            Close();
        }
    }
}

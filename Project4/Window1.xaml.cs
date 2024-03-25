using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
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

namespace Project4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            label4.Visibility = Visibility.Hidden;
            RadioText.Visibility = Visibility.Hidden;
        }

        Product product = null;

        private void book_Clicked(object sender, RoutedEventArgs e)
        {
            label4.Visibility = Visibility.Visible;   
            label4.Content = "Author: ";
            RadioText.Visibility= Visibility.Visible;
        }

        private void software_Clicked(object sender, RoutedEventArgs e)
        {
            label4.Visibility = Visibility.Visible;
            label4.Content = "Version: ";
            RadioText.Visibility= Visibility.Visible;
        }

        public void save_Clicked(object sender, RoutedEventArgs e)
        {
            if ((bool)Book.IsChecked)
            {
                product = new Book(RadioText.Text, CodeText.Text, DescripText.Text, PriceText.Text);
            }

            if ((bool)Software.IsChecked)
            {
                product = new Software(RadioText.Text, CodeText.Text, DescripText.Text, PriceText.Text);
            }

            this.Close();

        }

        public Product GetNewProduct()
        {
            this.ShowDialog();
            return product;
        }

        private void cancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

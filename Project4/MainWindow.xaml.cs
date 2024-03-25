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

namespace Project4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private ProductList products = new ProductList();

        private void win_Main_Loaded(object sender, RoutedEventArgs e)
        {
            ProductDB.GetProducts();
            FillProductListBox();

        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Window1 newProductForm = new Window1();
            Product product = newProductForm.GetNewProduct();

            if (product != null)
            {
                products.Add(product);
                ProductDB.SaveProducts(products);
                FillProductListBox();
            }

            return;
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            int i = lst_product.SelectedIndex;
            if (i != -1)
            {
                Product p = products[i];
                string message = $"Are you sure you want to delete {p.Code} {p.Description} {p.Price}?";

                MessageBoxResult button =
                    MessageBox.Show(message, "Confirm Delete", MessageBoxButton.YesNo);

                if (button == MessageBoxResult.Yes)
                {
                    products.Remove(p);
                    FillProductListBox();
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FillProductListBox()
        {

            lst_product.Items.Clear();
            foreach (Product p in products)
            {
                lst_product.Items.Add(p.GetDisplayText("\t"));
            }
        }


    }
}

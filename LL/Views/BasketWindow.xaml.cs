using System;
using System.Windows;

using LL.Services;

namespace LL.Views
{
    /// <summary>
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        public BasketWindow()
        {
            InitializeComponent();
            foreach(var product in Basket.Products)
            {
                ProductElement prel = new ProductElement();
                //prel.ImageSource.Source = product.Image;
                prel.FullNames.Text = product.FullName;
                prel.Price.Text = Convert.ToString(product.Price);
                prel.Sizer.Text = Convert.ToString(product.SizeStr);
                WrapMenu.Children.Add(prel);
            }
        }
        private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}

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

namespace LL.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();
        }
        public void CreatePr(object sender, RoutedEventArgs e)
        {
            Block_Of_Clothes blck = new Block_Of_Clothes();
            var uriSource = new Uri("C:\\Studing\\Курсовой проект\\LL\\LL\\Images\\heart2.png");
            blck.PhotoPr.Source = new BitmapImage(uriSource);
            blck.Price.Text = "22,00";
            blck.Company.Text = "Adidas";
            blck.Size.Text = "39";
            blck.Height = 400;
            blck.Width = 300;
            Catalogs.Children.Add(blck);
        }
    }
}

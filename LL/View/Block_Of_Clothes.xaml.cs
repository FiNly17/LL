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
    /// Логика взаимодействия для Block_Of_Clothes.xaml
    /// </summary>
    public partial class Block_Of_Clothes : UserControl
    {
        public Block_Of_Clothes()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var img = sender as Image;
            var uriSource = new Uri("C:\\Studing\\Курсовой проект\\LL\\LL\\Images\\heart2.png");
            if (img != null) img.Source = new BitmapImage(uriSource);
        }
    }
}

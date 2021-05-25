using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Windows.Resources;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace LL.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Sv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void Create_Acc(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Registration reg = new Registration();
                reg.Show();
                this.Close();
            }
        }

        public bool IsExists(object sender, object sender2)
        {
            
            return true;
        }

        private void Authoris_Click(object sender, RoutedEventArgs e)
        {


        }


        private void myButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Logged in!", "Success");
            Window_Of_Project window1 = new Window_Of_Project();
            window1.Show();
            this.Close();
        }
    }
}

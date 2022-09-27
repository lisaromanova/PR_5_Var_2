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

namespace PR_5_Var_2
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

        private void rbIn_Checked(object sender, RoutedEventArgs e)
        {
            stRus.Visibility = Visibility.Collapsed;
            stInGet.Visibility = Visibility.Visible;
        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            stInGet.Visibility = Visibility.Collapsed;
            stRus.Visibility = Visibility.Visible;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        bool IsRightIn(string s)
        {
            Regex r = new Regex("^[0-9]+[.,]?[0-9]*$");
            if (r.IsMatch(s))
            {
                if (Convert.ToDouble(s) > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Сумма должна быть больше нуля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введено некорректное значение!","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        bool IsRightRus(string s)
        {
            Regex r = new Regex("^[1-9][0-9]*$");
            if (r.IsMatch(s))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Введено некорректное значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rbIn_Checked(object sender, RoutedEventArgs e)
        {
            stRus.Visibility = Visibility.Collapsed;
            stButton.Visibility = Visibility.Collapsed;
            stOtv.Visibility = Visibility.Collapsed;
            stInGet.Visibility = Visibility.Visible;

        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            stInGet.Visibility = Visibility.Collapsed;
            stIn.Visibility = Visibility.Collapsed;
            stButton.Visibility = Visibility.Collapsed;
            stOtv.Visibility = Visibility.Collapsed;
            cbIn.SelectedIndex = -1;
            stRus.Visibility = Visibility.Visible;
        }

        private void cbIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbIn.SelectedIndex)
            {
                case 0:
                    stIn.Visibility = Visibility.Visible;
                    txtIn.Text = "Введите доллары: ";
                    stButton.Visibility = Visibility.Visible;
                    tbIn.Text = "";
                    stOtv.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    stIn.Visibility = Visibility.Visible;
                    txtIn.Text = "Введите евро: ";
                    stButton.Visibility = Visibility.Visible;
                    tbIn.Text = "";
                    stOtv.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    stIn.Visibility = Visibility.Visible;
                    txtIn.Text = "Введите рупи: ";
                    stButton.Visibility = Visibility.Visible;
                    tbIn.Text = "";
                    stOtv.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    stIn.Visibility = Visibility.Visible;
                    txtIn.Text = "Введите франки: ";
                    stButton.Visibility = Visibility.Visible;
                    tbIn.Text = "";
                    stOtv.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    stIn.Visibility = Visibility.Visible;
                    txtIn.Text = "Введите иены: ";
                    stButton.Visibility = Visibility.Visible;
                    tbIn.Text = "";
                    stOtv.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(stIn.Visibility == Visibility.Visible)
            {
                if (IsRightIn(tbIn.Text))
                {
                    double rub = Convert.ToDouble(tbIn.Text);
                    double kop = 0;
                    stOtv.Visibility=Visibility.Visible;
                    switch (cbIn.SelectedIndex)
                    {
                        case 0:
                            rub *= 58.08;
                            kop = Math.Round(rub * 100,0)%100;
                            txtOtv.Text += Math.Truncate(rub).ToString()+" рублей "+kop.ToString()+" копеек";
                            break;
                        case 1:
                            rub *= 56.32;
                            kop = (rub * 100) % 100;
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 2:
                            rub *= 0.71;
                            kop = (rub * 100) % 100;
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 3:
                            rub *= 59;
                            kop = (rub * 100) % 100;
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 4:
                            rub *= 0.4;
                            kop = (rub * 100) % 100;
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                    }
                }
            }
            else
            {
                if (IsRightRus(tbRub.Text))
                {
                    if (IsRightRus(tbKop.Text))
                    {

                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
    struct MoneyString 
    { 
        public string rubl;
        public string kop;
        public string dollar;
        public string euro;
        public string rupi;
        public string frank;
        public string ien;
        public string concat()
        {
            return rubl + ";" + kop + ";" + dollar + ';' + euro + ';' + rupi + ';' + frank + ';' + ien;
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void getData(string path, List<MoneyString> L)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    AddItem(L, array[0], array[1], array[2], array[3], array[4], array[5], array[6]);
                }
            }
        }
        static void PrintToFile(string path, List<MoneyString> L)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (MoneyString u in L)
                {
                    sw.WriteLine(u.concat());
                }
            }
        }
        void AddItem(List<MoneyString> L, string rubl, string kop, string dollar, string euro, string rupi, string frank, string ien)
        {
            L.Add(new MoneyString()
            {
                rubl = rubl,
                kop = kop,
                dollar = dollar,
                euro = euro,
                rupi = rupi,
                frank = frank,
                ien = ien,
            });
        }
        void WorkWithData(List<MoneyString> L, List<MoneyString> L1)
        {
            foreach(MoneyString m in L)
            {
                if ((m.rubl != "") || (m.kop != ""))
                {
                    if (IsRightRusFile(m.rubl))
                    {
                        string rubl;
                        if (m.rubl == "")
                        {
                            rubl = "0";
                        }
                        else
                        {
                            rubl = m.rubl;
                        }
                        if (IsRightRusFile(m.kop))
                        {
                            string kop;
                            if (m.kop == "")
                            {
                                kop = "0";
                            }
                            else
                            {
                                kop = m.kop;
                            }
                            if (IsRightKop(kop))
                            {
                                string str = rubl + "," + kop;
                                double rus = Convert.ToDouble(str);
                                double dollar = rus / 58.8;
                                double euro = rus / 56.32;
                                double rupi = rus / 0.71;
                                double frank = rus / 59;
                                double ien = rus / 0.4;
                                AddItem(L1, "", "", dollar.ToString(), euro.ToString(), rupi.ToString(), frank.ToString(), ien.ToString());
                            }


                        }
                    }
                }
                else
                {
                    if (m.dollar != "")
                    {
                        if (IsRightIn(m.dollar))
                        {
                            double dollar = Convert.ToDouble(m.dollar);
                            dollar *= 58.08;
                            double kop = Math.Round(dollar * 100, 0) % 100;
                            dollar = Math.Truncate(dollar);
                            AddItem(L1, dollar.ToString(), kop.ToString(), "", "", "", "", "");
                        }
                    }
                    else
                    {
                        if (m.euro != "")
                        {
                            if (IsRightIn(m.euro))
                            {
                                double euro = Convert.ToDouble(m.euro);
                                euro *= 56.32;
                                double kop = Math.Round(euro * 100, 0) % 100;
                                euro = Math.Truncate(euro);
                                AddItem(L1, euro.ToString(), kop.ToString(), "", "", "", "", "");
                            }
                        }
                        else
                        {
                            if (m.rupi != "")
                            {
                                if (IsRightIn(m.rupi))
                                {
                                    double rupi = Convert.ToDouble(m.rupi);
                                    rupi *= 0.71;
                                    double kop = Math.Round(rupi * 100, 0) % 100;
                                    rupi = Math.Truncate(rupi);
                                    AddItem(L1, rupi.ToString(), kop.ToString(), "", "", "", "", "");
                                }
                            }
                            else
                            {
                                if (m.frank != "")
                                {
                                    if (IsRightIn(m.frank))
                                    {
                                        double frank = Convert.ToDouble(m.frank);
                                        frank *= 59;
                                        double kop = Math.Round(frank * 100, 0) % 100;
                                        frank = Math.Truncate(frank);
                                        AddItem(L1, frank.ToString(), kop.ToString(), "", "", "", "", "");
                                    }
                                }
                                else
                                {
                                    if (m.ien != "")
                                    {
                                        if (IsRightIn(m.ien))
                                        {
                                            double ien = Convert.ToDouble(m.ien);
                                            ien *= 0.4;
                                            double kop = Math.Round(ien * 100, 0) % 100;
                                            ien = Math.Truncate(ien);
                                            AddItem(L1, ien.ToString(), kop.ToString(), "", "", "", "", "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
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
            Regex r = new Regex("^[0-9]+$");
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
        bool IsRightRusFile(string s)
        {
            Regex r = new Regex("^[0-9]*$");
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
        bool IsRightKop(string s)
        {
            if (Convert.ToInt32(s) <= 100)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Копеек не может быть больше 100", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            cbIn.SelectedIndex = -1;
            stInGet.Visibility = Visibility.Visible;
        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            stInGet.Visibility = Visibility.Collapsed;
            stIn.Visibility = Visibility.Collapsed;
            stButton.Visibility = Visibility.Collapsed;
            stOtv.Visibility = Visibility.Collapsed;
            cbIn.SelectedIndex = -1;
            tbRub.Text = "";
            tbKop.Text = "";
            stRus.Visibility = Visibility.Visible;
        }

        private void cbIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(stRus.Visibility == Visibility.Collapsed)
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
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(stIn.Visibility == Visibility.Visible)
            {
                if (IsRightIn(tbIn.Text))
                {
                    double rub = Convert.ToDouble(tbIn.Text);
                    double kop;
                    stOtv.Visibility=Visibility.Visible;
                    switch (cbIn.SelectedIndex)
                    {
                        case 0:
                            rub *= 58.08;
                            kop = Math.Round(rub * 100,0)%100;
                            txtOtv.Text = "Итог: ";
                            txtOtv.Text += Math.Truncate(rub).ToString()+" рублей "+kop.ToString()+" копеек";
                            break;
                        case 1:
                            rub *= 56.32;
                            kop = (rub * 100) % 100;
                            txtOtv.Text = "Итог: ";
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 2:
                            rub *= 0.71;
                            kop = (rub * 100) % 100;
                            txtOtv.Text = "Итог: ";
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 3:
                            rub *= 59;
                            kop = (rub * 100) % 100;
                            txtOtv.Text = "Итог: ";
                            txtOtv.Text += Math.Truncate(rub).ToString() + " рублей " + kop.ToString() + " копеек";
                            break;
                        case 4:
                            rub *= 0.4;
                            kop = (rub * 100) % 100;
                            txtOtv.Text = "Итог: ";
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
                            if(IsRightKop(tbKop.Text))
                            {
                                if (cbIn.SelectedIndex != -1)
                                {
                                    double n;
                                    if (Convert.ToInt32(tbKop.Text) == 100)
                                    {
                                        n = Convert.ToDouble(tbRub.Text);
                                        n++;
                                    }
                                    else
                                    {
                                        string str = tbRub.Text + "," + tbKop.Text;
                                        n = Convert.ToDouble(str);
                                    }
                                    stOtv.Visibility = Visibility.Visible;
                                    switch (cbIn.SelectedIndex)
                                    {
                                        case 0:
                                            n /= 58.08;
                                            n = Math.Round(n, 2);
                                            txtOtv.Text = "Итог: ";
                                            txtOtv.Text += n.ToString() + " долларов";
                                            break;
                                        case 1:
                                            n /= 56.32;
                                            n = Math.Round(n, 2);
                                            txtOtv.Text = "Итог: ";
                                            txtOtv.Text += n.ToString() + " евро";
                                            break;
                                        case 2:
                                            n /= 0.71;
                                            n = Math.Round(n, 2);
                                            txtOtv.Text = "Итог: ";
                                            txtOtv.Text += n.ToString() + " рупи";
                                            break;
                                        case 3:
                                            n /= 59;
                                            n = Math.Round(n, 2);
                                            txtOtv.Text = "Итог: ";
                                            txtOtv.Text += n.ToString() + " франков";
                                            break;
                                        case 4:
                                            n /= 0.4;
                                            n = Math.Round(n, 2);
                                            txtOtv.Text = "Итог: ";
                                            txtOtv.Text += n.ToString() + " иенов";
                                            break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Выберите значение из выпадающего списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    
                }
            }
        }

        private void tbRub_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if ((tbRub.Text != "") && (tbKop.Text != ""))
            {
                stInGet.Visibility = Visibility.Visible;
                stButton.Visibility = Visibility.Visible;
            }
            else
            {
                stInGet.Visibility = Visibility.Collapsed;
                cbIn.SelectedIndex = -1;
                stButton.Visibility = Visibility.Collapsed;
                stOtv.Visibility = Visibility.Collapsed;
            }
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            List<MoneyString> money = new List<MoneyString>();
            getData("dataMoney.csv", money);
            List<MoneyString> m1 = new List<MoneyString>();
            WorkWithData(money, m1);
            PrintToFile("dataMoneyNew.csv", m1);
        }
    }
}

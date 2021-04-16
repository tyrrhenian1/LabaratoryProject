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

namespace LogWindow
{
    /// <summary>
    /// Логика взаимодействия для LogHistory.xaml
    /// </summary>
    public partial class LogHistory : Window
    {
        public LogHistory()
        {
            InitializeComponent();
            allLogins.Visibility = Visibility.Hidden;
            dateFilter.Visibility = Visibility.Hidden;
            using (Model1 db = new Model1())
            {
                var a = from b in db.Users
                        select new
                        {
                            Login = b.login,
                            LastEnter = b.lastenter,
                            Ip = b.ip
                        };
                logHistory.ItemsSource = a.ToList();
                foreach(var i in a)
                {
                    allLogins.Items.Add(i.Login);
                }
            }
            
        }

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filter.SelectedIndex == 0)
            {
                allLogins.Visibility = Visibility.Visible;
                dateFilter.Visibility = Visibility.Hidden;
            }
            else
            {
                dateFilter.Visibility = Visibility.Visible;
                allLogins.Visibility = Visibility.Hidden;
            }
        }

        private void allLogins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                logHistory.ItemsSource = null;
                string f = allLogins.SelectedValue.ToString();
                var query = from b in db.Users
                            where b.login.Equals(f)
                            select new
                            {
                                Login = b.login,
                                LastEnter = b.lastenter,
                                Ip = b.ip
                            };
                logHistory.ItemsSource = query.ToList();
            }
        }

        private void dateFilter_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                logHistory.ItemsSource = null;
                DateTime dates = dateFilter.SelectedDate.Value;
                int day = dates.Date.Day;
                int month = dates.Date.Month;
                int year = dates.Date.Year;
                string data = $"{day}/{month}/{year}";
                var query = from b in db.Users
                            where b.lastenter.Equals(data)
                            select new
                            {
                                Login = b.login,
                                LastEnter = b.lastenter,
                                Ip = b.ip
                            };
                logHistory.ItemsSource = query.ToList();            
            }
        }
    }
}

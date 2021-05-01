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
using System.Windows.Threading;

namespace LogWindow
{
    /// <summary>
    /// Логика взаимодействия для LaborantWindow.xaml
    /// </summary>
    public partial class LaborantWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        TimeSpan timeInterval = new TimeSpan();
        public LaborantWindow(int id)
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            using (Model2 db = new Model2())
            {
                var a = from b in db.users
                        where b.id.Equals(id)
                        select b;
                if (a.Count() != 0)
                {
                    foreach(var i in a)
                    {
                        nameUser.Content = i.name;
                    }
                }
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeInterval += dispatcherTimer.Interval;
            timerBox.Content = timeInterval.ToString();
            if (timeInterval.Seconds == 10)
            {
                MessageBox.Show("Осталось 10 сек");
            }
            else if (timeInterval.Seconds == 20)
            {
                dispatcherTimer.Stop();
                Close();
                MainWindow mainWindow = new MainWindow("laborant");
                mainWindow.Show();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            dispatcherTimer.Stop();
        }
    }
}

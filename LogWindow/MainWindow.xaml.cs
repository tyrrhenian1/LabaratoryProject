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
using System.Windows.Threading;

namespace LogWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        TimeSpan timeInterval = new TimeSpan();
        public MainWindow()
        {
            InitializeComponent();
            passShow.Visibility = Visibility.Hidden;
        }
        public MainWindow(string x)
        {
            InitializeComponent();
            okay.IsEnabled = false;
            dispatcherTimer = new DispatcherTimer();
            if (x.Equals("captcha"))
            {
                dispatcherTimer.Tick += DispatcherTimer_Tick1;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
            else if(x.Equals("laborant"))
            {
                dispatcherTimer.Tick += DispatcherTimer_Tick2;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }

        private void DispatcherTimer_Tick1(object sender, EventArgs e)
        {
            timeInterval += dispatcherTimer.Interval;
            if(timeInterval.Seconds == 10)
            {
                dispatcherTimer.Stop();
                okay.IsEnabled = true;
                MessageBox.Show("Вы снова можете начать работу");
            }
        }
        private void DispatcherTimer_Tick2(object sender, EventArgs e)
        {
            timeInterval += dispatcherTimer.Interval;
            if (timeInterval.Seconds == 30)
            {
                dispatcherTimer.Stop();
                okay.IsEnabled = true;
                MessageBox.Show("Вы снова можете начать работу");
            }
        }

        private void okay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginUser.Text.Length == 0 && passUser.Password.Length == 0)
                {
                    MessageBox.Show("Нужно ввести данные");
                }
                else if (loginUser.Text.Length != 0 && passUser.Password.Length == 0)
                {
                    MessageBox.Show("Нужно ввести данные");
                }
                else if (loginUser.Text.Length == 0 && passUser.Password.Length != 0)
                {
                    MessageBox.Show("Нужно ввести данные");
                }
                else if (loginUser.Text.Length != 0 && passUser.Password.Length != 0)
                {
                    using (Model2 db = new Model2())
                    {
                        var a = from b in db.users
                                where b.login.Equals(loginUser.Text) && b.password.Equals(passUser.Password)
                                select b;
                        if (a.Count() != 0)
                        {
                            foreach (var ister in a)
                            {
                                if (ister.type == 1)
                                {
                                    LaborantWindow laborant = new LaborantWindow(ister.id);
                                    laborant.Show();
                                    Close();
                                }
                                else if (ister.type == 2)
                                {
                                    BookherWindow bookher = new BookherWindow(ister.id);
                                    bookher.Show();
                                    Close();
                                }
                                else if (ister.type == 3)
                                {
                                    ResearcherWindow researcher = new ResearcherWindow(ister.id);
                                    researcher.Show();
                                    Close();
                                }
                                else if (ister.type == 4)
                                {
                                    AdminWindow admin = new AdminWindow(ister.id);
                                    admin.Show();
                                    Close();
                                }
                            }
                        }
                        else
                        {
                            Captcha captcha = new Captcha();
                            Close();
                            captcha.ShowDialog();
                        }
                    }
                }
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void showPass_Click(object sender, RoutedEventArgs e)
        {
            if (showPass.IsChecked == true)
            {
                passShow.Text = passUser.Password;
                passUser.Visibility = Visibility.Hidden;
                passShow.Visibility = Visibility.Visible;
            }
            else
            {
                passUser.Password = passShow.Text;
                passShow.Visibility = Visibility.Hidden;
                passUser.Visibility = Visibility.Visible;
            }
        }
    }
}

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

namespace LogWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            passShow.Visibility = Visibility.Hidden;
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
                        var a = from b in db.users_
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
                                    autorizedWindow.Close();
                                }
                                else if (ister.type == 2)
                                {
                                    BookherWindow bookher = new BookherWindow(ister.id);
                                    bookher.Show();
                                    autorizedWindow.Close();
                                }
                                else if (ister.type == 3)
                                {
                                    ResearcherWindow researcher = new ResearcherWindow(ister.id);
                                    researcher.Show();
                                    autorizedWindow.Close();
                                }
                                else if (ister.type == 4)
                                {
                                    AdminWindow admin = new AdminWindow(ister.id);
                                    admin.Show();
                                    autorizedWindow.Close();
                                }
                            }
                        }
                        else MessageBox.Show("Неверный логин или пароль");
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

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
    /// Логика взаимодействия для ResearcherWindow.xaml
    /// </summary>
    public partial class ResearcherWindow : Window
    {
        public ResearcherWindow(int id)
        {
            InitializeComponent();
            using (Model2 db = new Model2())
            {
                var a = from b in db.users_
                        where b.id.Equals(id)
                        select b;
                if (a.Count() != 0)
                {
                    foreach (var i in a)
                    {
                        nameUser.Content = i.name;
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

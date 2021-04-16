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
    /// Логика взаимодействия для Bookher.xaml
    /// </summary>
    public partial class Bookher : Window
    {
        public Bookher(int id)
        {
            InitializeComponent();
            //using (Model1 db = new Model1())
            //{
            //    var f = from g in db.Users
            //            where g.id == id
            //            select g;
            //    foreach(var i in f)
            //    {
            //        nameUser1.Content = i.name;
            //        workPos1.Content = "Бухгалтер";
            //    }
            //}
            
        }
        private void bookhWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

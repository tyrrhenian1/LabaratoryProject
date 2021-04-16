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
    /// Логика взаимодействия для Laborant.xaml
    /// </summary>
    public partial class Laborant : Window
    {
        public Laborant(int id)
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var m = from n in db.Users
                        where n.id == id
                        select n;
                foreach(var i in m)
                {
                    nameUserr.Content = i.name;
                    workPost.Content = "Лаборант";
                }
            }
        }
    }
}

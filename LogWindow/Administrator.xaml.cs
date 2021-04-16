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
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator(int id)
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var c = from d in db.Users
                        where d.id == id
                        select d;
                foreach(var i in c)
                {
                    nameUsers.Content = i.name;
                    workPoss.Content = "Администратор";
                }
            }
        }
    }
}

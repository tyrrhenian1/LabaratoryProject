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
    /// Логика взаимодействия для Researcher.xaml
    /// </summary>
    public partial class Researcher : Window
    {
        public Researcher(int id)
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var j = from k in db.Users
                        where k.id == id
                        select k;
                foreach(var i in j)
                {
                    nameUseres.Content = i.name;
                    workPosUser.Content = "Лаборант-Исследователь";
                }
            }
        }
    }
}

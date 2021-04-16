﻿using System;
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
    /// Логика взаимодействия для BookherWindow.xaml
    /// </summary>
    public partial class BookherWindow : Window
    {
        public BookherWindow(int id)
        {
            InitializeComponent();
            using (Model1 db = new Model1())
            {
                var a = from b in db.Users
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
    }
}
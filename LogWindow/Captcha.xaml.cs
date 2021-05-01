using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace LogWindow
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {

        string text = "";
        public Captcha()
        {
            InitializeComponent();
            RefreshCaptcha();
        }
        private BitmapSource BitmapToImage(Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),IntPtr.Zero,Int32Rect.Empty,BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            System.Drawing.Brush[] colors = { System.Drawing.Brushes.Black,
                     System.Drawing.Brushes.Red,
                     System.Drawing.Brushes.RoyalBlue,
                     System.Drawing.Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);

            //Пусть фон картинки будет серым
            g.Clear(System.Drawing.Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new System.Drawing.Point(0, 0),
                       new System.Drawing.Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new System.Drawing.Point(0, Height - 1),
                       new System.Drawing.Point(Width - 1, 0));
            ////Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, System.Drawing.Color.White);

            return result;
        }

        private void refreshCapt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RefreshCaptcha();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (captchaBox.Text.Equals(text))
            {
                MainWindow mainWindow = new MainWindow("captcha");
                mainWindow.Show();
                Close();

            }
            else
            {
                RefreshCaptcha();
            }
        }
        private void RefreshCaptcha()
        {
            int width = int.Parse(captchaImage.Width.ToString());
            int height = int.Parse(captchaImage.Height.ToString());
            captchaImage.Source = BitmapToImage(CreateImage(width, height));
        }
    }
}

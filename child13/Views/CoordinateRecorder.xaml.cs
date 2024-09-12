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

using _crd = child13.Models;

namespace child13.Views
{
    /// <summary>
    /// Interaction logic for CoordinateRecorder.xaml
    /// </summary>
    public partial class CoordinateRecorder : Window
    {
        /*
         Реализовать запрос координат следующим образом:
        1. Пользователь нажимает на кнопку "Записать координаты"
        2. Начинается отчет времени после нажатия на кнопку и выводится на экран
        3. Необходимо перенести курсор в нужное место для записи первых двух координат
        4. После чего повторить действие для записи следующих двух координат
         */

        public int x1, x2, y1, y2;
        private DispatcherTimer _timer;
        private TimeSpan _timeLeft;

        public _crd.Coordinate coordinate = new _crd.Coordinate();

        public CoordinateRecorder(_crd.Coordinate coord)
        {
            InitializeComponent();
            coordinate = coord;
            _timeLeft = TimeSpan.FromSeconds(2);
            TimerTextBlock.Text = _timeLeft.ToString("c");
        }

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); // Интервал таймера в 1 секунду
            _timer.Tick += Timer_Tick;
            _timer.Start();
            MessageBox.Show("Установите курсор на первую координату");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_timeLeft.TotalSeconds > 0)
            {
                _timeLeft = _timeLeft.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = _timeLeft.ToString("c");
            }
            else
            {
                if (x1 == 0 && x2 == 0 && x2 == 0 && y2 == 0 ||
                x1 != 0 && y1 != 0 && x2 == 0 && y2 == 0)
                {
                    if (x1 == 0 && x2 == 0)
                    {
                        x1 = Convert.ToInt32(Mouse.GetPosition(this).X);
                        y1 = Convert.ToInt32(Mouse.GetPosition(this).Y);
                    }
                    else
                    {
                        x2 = Convert.ToInt32(Mouse.GetPosition(this).X);
                        y2 = Convert.ToInt32(Mouse.GetPosition(this).Y);
                    }
                }
                _timer.Stop();
                MessageBox.Show("unlink!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // при закрытие окна устанавливать координаты в модель
            coordinate.GetCoordinates(x1, x2, y1, y2);
        }
    }
}

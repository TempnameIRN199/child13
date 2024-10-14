using child13_AI.AdditionalStructures.Service;
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

namespace child13_AI.Views
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

        public int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
        private readonly Coordinate coordinate = new Coordinate();
        private DispatcherTimer _countdownTimer;
        private int _remainingSeconds;

        public CoordinateRecorder()
        {
            InitializeComponent();
            _countdownTimer = new DispatcherTimer();
            _countdownTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds > 0)
            {
                _remainingSeconds--;
                TimerTextBlock.Text = $"Залишилось: {_remainingSeconds} секунд";
            }
            else
            {
                _countdownTimer.Stop();
                TimerTextBlock.Text = "Час вийшов!";
                if (x1 == 0 && y1 == 0)
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
        }

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_countdownTimer.IsEnabled)
            {
                // Встановлюємо значення для зворотного відліку (наприклад, 10 секунд)
                _remainingSeconds = 10;
                TimerTextBlock.Text = $"Залишилось: {_remainingSeconds} секунд";
                _countdownTimer.Tick += Timer_Tick;
                _countdownTimer.Start();
            }

            MessageBox.Show("unlink!");
        }
        private void StartTimerButton1_Click(object sender, RoutedEventArgs e)
        {
            if (!_countdownTimer.IsEnabled)
            {
                // Встановлюємо значення для зворотного відліку (наприклад, 10 секунд)
                _remainingSeconds = 10;
                TimerTextBlock.Text = $"Залишилось: {_remainingSeconds} секунд";
                _countdownTimer.Start();
                x2 = Convert.ToInt32(Mouse.GetPosition(this).X);
                y2 = Convert.ToInt32(Mouse.GetPosition(this).Y);
            }
            MessageBox.Show("unlink!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            coordinate._SetCoordinate(x1, x2, y1, y2);
            MessageBox.Show("x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);
        }
    }
}

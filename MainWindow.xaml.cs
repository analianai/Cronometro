using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer cronometro = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            cronometro.Tick += new EventHandler(dt_Tick);
            cronometro.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan time = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                    time.Hours, time.Minutes, time.Seconds);
                Clocklabel.Content = currentTime;
                timeStop(time.Hours,time.Minutes,time.Seconds);
            }
        }

        private void timeStop(int timeHour,int timeMinutes ,int timeSecond)
        {
            if (timeHour == int.Parse(StopHourTextBox.Text) && timeMinutes == int.Parse(StopMinutosTextBox.Text) && timeSecond == int.Parse(StopSegundoTextBox.Text))
            {
                stopWatch.Stop();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            cronometro.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();
        }

       
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Reset();
            Clocklabel.Content = "00:00:00";
            StopSegundoTextBox.Text = "00";
            StopMinutosTextBox.Text = "00";
            StopHourTextBox.Text = "00";
        }
    }
}

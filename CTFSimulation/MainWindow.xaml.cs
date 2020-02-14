using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CTFSimulation.Tools;

namespace CTFSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isRunning;
        private static Timer _timer;

        private int _x;
        private int _y;

        public MainWindow()
        {
            InitializeComponent();
            DrawingTool.SetupDrawingTool(ref Field);

            _isRunning = false;
            SetTimer();
        }

        private void SetTimer()
        {
            _timer = new Timer(500);
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _x += 10;
            Dispatcher.Invoke(() =>
            {
                DrawingTool.ClearCanvas();
                DrawingTool.DrawCircle(10, Brushes.Red, new Vector(_x, _y));
            }, System.Windows.Threading.DispatcherPriority.Normal);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _isRunning = false;
                _timer.Enabled = false;
                RunButton.Content = "Run";
            }
            else
            {
                _x = 0;
                _y = 200;

                _isRunning = true;
                _timer.Enabled = true;
                RunButton.Content = "Pause";
            }
        }
    }
}

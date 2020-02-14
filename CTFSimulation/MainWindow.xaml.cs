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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            SetTimer();
            _isRunning = false;
            InitializeComponent();
            _x = 0;
            _y = 0;
        }

        private void SetTimer()
        {
            _timer = new Timer(500);
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _x++;
            _y++;
            Dispatcher.Invoke(() =>
            {
                ClearCanvas();
                DrawCircle();
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
                _isRunning = true;
                _timer.Enabled = true;
                RunButton.Content = "Pause";
            }
        }

        private void DrawCircle()
        {
            var circle = new Ellipse();
            circle.Width = 10;
            circle.Height = 10;
            Canvas.SetLeft(circle, _x);
            Canvas.SetBottom(circle, _y);
            Field.Children.Add(circle);
        }

        private void ClearCanvas()
        {
            Field.Children.Clear();
        }
    }
}

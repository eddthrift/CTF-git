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
using System.Windows.Threading;
using CTFSimulation.Objects;
using CTFSimulation.Tools;

namespace CTFSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += SetupSimulation;
        }

        void SetupSimulation(object sender, RoutedEventArgs e)
        {
            DrawingTool.SetupDrawingTool(ref Field);
            Simulation.SetupSimulation(1, ref Field);

            SetTimer();
        }

        private void SetTimer()
        {
            _timer = new Timer(10);
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                DrawingTool.ClearCanvas();
                Simulation.Simulate();
                Simulation.Draw();
            }, DispatcherPriority.Normal);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Enabled = false;
                RunButton.Content = "Start";
            }
            else
            {
                _timer.Enabled = true;
                RunButton.Content = "Pause";
            }
        }
    }
}

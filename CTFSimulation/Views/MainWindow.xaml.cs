using System.Windows;
using CTFSimulation.Tools;
using CTFSimulation.ViewModels;

namespace CTFSimulation.Views
{
    public partial class MainWindow : Window
    {
        private SimulationViewModel _simulation;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += SetupSimulation;
        }

        void SetupSimulation(object sender, RoutedEventArgs e)
        {
            DrawingTool.SetupDrawingTool(ref Field);
            _simulation = new SimulationViewModel(ref Field);
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (_simulation.IsTimerEnabled())
            {
                _simulation.StopTimer();
                RunButton.Content = "Run";
            }
            else
            {
                _simulation.StartTimer();
                RunButton.Content = "Pause";
            }
        }
    }
}

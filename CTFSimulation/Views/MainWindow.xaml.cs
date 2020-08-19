using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using CTFSimulation.Tools;
using CTFSimulation.ViewModels;

namespace CTFSimulation.Views
{
    public partial class MainWindow : Window
    {
        private SimulationViewModel _simulation;

        public MainWindow(int height = 450, int width = 800)
        {
            InitializeComponent();
            this.Height = height;
            this.Width = width;

            this.Loaded += SetupSimulation;
        }

        void SetupSimulation(object sender, RoutedEventArgs e)
        {
            DrawingTool.SetupDrawingTool(ref fieldCanvas);
            _simulation = new SimulationViewModel(ref fieldCanvas, 10);
        }

        private void RunButton_OnClick(object sender, RoutedEventArgs e)
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

        private void InitialiseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var playersPerTeam = ValidatePlayerTextBox();

            if (playersPerTeam != null)
            {
                _simulation.Initialise(playersPerTeam.Value);
            }

            RunButton.IsEnabled = true;
        }

        private int? ValidatePlayerTextBox()
        {
            if (int.TryParse(PlayersTextBox.Text, out int numberOfPlayers) && numberOfPlayers != 0)
            {
                PlayersValidationLabel.Visibility = Visibility.Hidden;
                return numberOfPlayers;
            }

            PlayersValidationLabel.Visibility = Visibility.Visible;

            return null;
        }
    }
}

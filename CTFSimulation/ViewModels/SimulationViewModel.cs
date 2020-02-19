using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using CTFSimulation.Interfaces;
using CTFSimulation.Models;
using CTFSimulation.Tools;

namespace CTFSimulation.ViewModels
{
    public class SimulationViewModel
    {
        private readonly Timer _timer;
        private Game _game;

        public SimulationViewModel(ref Canvas field)
        {
            _game = new Game(1, ref field);

            _timer = new Timer(10);
            _timer.Enabled = false;
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimedEvent;
        }
        
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                DrawingTool.ClearCanvas();
                _game.Tick();
                DrawPlayers();
            }, DispatcherPriority.Normal);
        }

        public void StartTimer()
        {
            _timer.Enabled = true;
        }

        public void StopTimer()
        {
            _timer.Enabled = false;
        }

        public bool IsTimerEnabled()
        {
            return _timer.Enabled;
        }
        public void DrawPlayers()
        {
            foreach (IPlayer player in _game.Players)
            {
                DrawingTool.DrawCircle(10, DrawingTool.ChooseBrushColour(player.Team), player.Position);
            }
        }
    }
}

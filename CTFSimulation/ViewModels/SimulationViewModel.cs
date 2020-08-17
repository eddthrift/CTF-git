using System;
using System.Collections.Generic;
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
        private readonly DispatcherTimer _uiTimer;
        private readonly Timer _simTimer;
        private Game _game;
        private IList<ObjectInfo> _playerInfo;

        public SimulationViewModel(ref Canvas field, int refreshPeriodMs)
        {
            _game = new Game(ref field);

            _playerInfo = new List<ObjectInfo>();

            _simTimer = new Timer(refreshPeriodMs);
            _simTimer.AutoReset = false;
            _simTimer.Elapsed += Simulate;

            _uiTimer = new DispatcherTimer(DispatcherPriority.Render, Application.Current.Dispatcher);
            _uiTimer.Interval = TimeSpan.FromMilliseconds(33); // ~30fps
            _uiTimer.IsEnabled = false;
            _uiTimer.Tick += UpdateUI;
        }

        public void Initialise(int playersPerTeam)
        {
            _game.Initialise(playersPerTeam);
        }

        public void StartTimer()
        {
            _simTimer.Start();
            _uiTimer.Start();
        }

        public void StopTimer()
        {
            _simTimer.Stop();
            _uiTimer.Stop();
        }

        public bool IsTimerEnabled()
        {
            return _simTimer.Enabled;
        }

        private void Simulate(object source, ElapsedEventArgs e)
        {
            _game.Tick();

            UpdatePlayerInfo();
            _simTimer.Start();
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            DrawingTool.ClearCanvas();
            DrawPlayers();
        }

        private void DrawPlayers()
        {
            foreach (ObjectInfo player in _playerInfo)
            {
                DrawingTool.DrawCircle(10, DrawingTool.ChooseBrushColour(player.Team), player.Position);
            }
        }

        private void UpdatePlayerInfo()
        {
            _playerInfo = new List<ObjectInfo>();

            foreach(IPlayer player in _game.Players)
            {
                _playerInfo.Add(new ObjectInfo(player.PlayerId, player.Team, player.Position, player.State, ObjectType.Player));
            }
        }
    }
}

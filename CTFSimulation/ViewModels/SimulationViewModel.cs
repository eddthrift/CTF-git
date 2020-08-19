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
        private IList<IObject> _objectInfo;

        public SimulationViewModel(ref Canvas field, int refreshPeriodMs)
        {
            _game = new Game(ref field);

            _objectInfo = new List<IObject>();

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

            UpdateObjectInfo();
            _simTimer.Start();
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            DrawingTool.ClearCanvas();
            DrawPlayers();
        }

        private void DrawPlayers()
        {
            foreach (IObject sprite in _objectInfo)
            {
                switch (sprite.Type)
                {
                    case ObjectType.Player:
                        DrawingTool.DrawCircle(10, sprite.Team, sprite.Position);
                        break;

                    case ObjectType.Flag: 
                        DrawingTool.DrawFlag(10, sprite.Team, sprite.Position);
                        break;
                }
            }
        }

        private void UpdateObjectInfo()
        {
            _objectInfo = new List<IObject>();

            _objectInfo.Add(_game.RedFlag);
            _objectInfo.Add(_game.BlueFlag);

            foreach (IPlayer player in _game.Players)
            {
                _objectInfo.Add(player);
            }
        }
    }
}

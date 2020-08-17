﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Models
{
    public class Game
    {
        public List<IPlayer> Players;
        public Canvas Field;
        public Flag BlueFlag;
        public Flag RedFlag;

        public Game(ref Canvas field)
        {
            Players = new List<IPlayer>();
            Field = field;
        }

        public void Initialise(int playersPerTeam)
        {
            CreatePlayers(playersPerTeam);
            SetupFlags();
        }

        public void Tick()
        {
            foreach (IPlayer player in Players.OrderBy(p => p.PlayerId))
            {
                player.MovePlayer();
            }
        }

        private void SetupFlags()
        {
            var width = Field.ActualWidth;
            var height = Field.ActualHeight;

            var redFlagPosition = new Vector(5, height / 2);
            var blueFlagPosition = new Vector(width - 5, height/2);

            RedFlag = new Flag(redFlagPosition, ObjectTeam.Red, ObjectState.FlagInBase);
            BlueFlag = new Flag(blueFlagPosition, ObjectTeam.Blue, ObjectState.FlagInBase);
        }

        private void CreatePlayers(int playersPerTeam)
        {
            for (int i = 0; i < playersPerTeam; i++)
            {
                var bluePosition = new Vector(i * Field.ActualWidth / (playersPerTeam + 1), Field.ActualHeight / 2);
                Players.Add(new Player(2 * i + 1, ObjectTeam.Blue, bluePosition));

                var redPosition = new Vector(0,0);
                Players.Add(new Player(2 * (i + 1), ObjectTeam.Red, redPosition));
            }
        }
    }
}

using System.Collections.Generic;
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

        public Game(int playersPerTeam, ref Canvas field)
        {
            Players = new List<IPlayer>();

            Field = field;
            CreatePlayers(playersPerTeam);
        }

        public void Tick()
        {
            foreach (IPlayer player in Players.OrderBy(p => p.PlayerId))
            {
                player.MovePlayer();
            }
        }

        private void CreatePlayers(int playersPerTeam)
        {
            for (int i = 0; i < playersPerTeam; i++)
            {
                Players.Add(new Player(2 * i + 1, PlayerTeam.Blue, new Vector(i*Field.ActualWidth/(playersPerTeam+1), Field.ActualHeight/2)));
                Players.Add(new Player(2*(i + 1), PlayerTeam.Red));
            }
        }
    }
}

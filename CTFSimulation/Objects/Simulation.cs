using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Objects
{
    static class Simulation
    {
        public static List<IPlayer> Players;
        public static Canvas Field;

        static Simulation()
        {
            Players = new List<IPlayer>();
        }

        public static void SetupSimulation(int playersPerTeam, ref Canvas field)
        {
            Field = field;
            CreatePlayers(playersPerTeam);
        }

        public static void Simulate()
        {
            foreach (IPlayer player in Players.OrderBy(p => p.PlayerId))
            {
                player.MovePlayer();
            }
        }

        public static void Draw()
        {
            foreach (IPlayer player in Players)
            {
                var colour = Brushes.Red;
                if (player.Team == PlayerTeam.Blue)
                    colour = Brushes.Blue;

                DrawingTool.DrawCircle(10, colour, player.Position);
            }
        }

        private static void CreatePlayers(int playersPerTeam)
        {
            for (int i = 0; i < playersPerTeam; i++)
            {
                Players.Add(new Player(2 * i + 1, PlayerTeam.Blue, new Vector(i*Field.ActualWidth/(playersPerTeam+1), Field.ActualHeight/2)));
                Players.Add(new Player(2*(i + 1), PlayerTeam.Red));
            }
        }
    }
}

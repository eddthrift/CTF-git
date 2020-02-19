using CTFSimulation.Tools;
using System.Windows;

namespace CTFSimulation.Models
{
    public class PlayerInfo
    {
        public int Id;
        public PlayerTeam Team;
        public Vector Position;

        public PlayerInfo(int id, PlayerTeam team, Vector position)
        {
            Id = id;
            Team = team;
            Position = position;
        }
    }
}

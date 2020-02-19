using System.Windows;
using CTFSimulation.Tools;

namespace CTFSimulation.Interfaces
{
    public interface IPlayer
    {
       Vector Position { get; set; }
       Vector Velocity { get; set; }
       PlayerState State { get; set; }
       PlayerTeam Team { get; }
       int PlayerId { get; }

       void MovePlayer();
    }
}

using System.Windows;
using CTFSimulation.Tools;

namespace CTFSimulation.Interfaces
{
    public interface IPlayer: IObject
    {
        Vector Velocity { get; set; }
        int PlayerId { get; }

       void MovePlayer();
    }
}

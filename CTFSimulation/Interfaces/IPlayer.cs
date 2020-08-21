using System.Collections.Generic;
using System.Windows;
using CTFSimulation.Tools;

namespace CTFSimulation.Interfaces
{
    public interface IPlayer: IObject
    {
        Vector Velocity { get; set; }
        int Id { get; }
        void Move();
    }
}

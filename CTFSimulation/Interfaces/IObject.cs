using System.Windows;
using CTFSimulation.Tools;

namespace CTFSimulation.Interfaces
{
    public interface IObject
    {
        Vector Position { get; set; }
        ObjectState State { get; set; }
        ObjectTeam Team { get; }

        ObjectType Type { get; }
    }
}

using System.Windows;
using CTFSimulation.Tools;

namespace CTFSimulation.Interfaces
{
    public interface IObject
    {
        int Id { get; }
        Vector Position { get; set; }
        ObjectState State { get; set; }
        ObjectTeam Team { get; }
        ObjectType Type { get; }
    }
}

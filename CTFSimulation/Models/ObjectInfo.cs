using CTFSimulation.Tools;
using System.Windows;

namespace CTFSimulation.Models
{
    public class ObjectInfo
    {
        public int Id;
        public ObjectTeam Team;
        public Vector Position;
        public ObjectState State;
        public ObjectType Type;

        public ObjectInfo(int id, ObjectTeam team, Vector position, ObjectState objectState, ObjectType objectType)
        {
            Id = id;
            Team = team;
            Position = position;
            State = objectState;
            Type = objectType;
        }
    }
}

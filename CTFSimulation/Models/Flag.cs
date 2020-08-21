using System;
using System.Windows;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Models
{
    public class Flag : IObject
    {
        public Flag(int id, Vector position, ObjectTeam team, ObjectState state)
        {
            Id = Id;
            Position = position;
            InitialPosition = position;
            Team = team;
            State = state;
        }

        public int Id { get; }
        public Vector Position { get; set; }
        public Vector InitialPosition { get; }
        public ObjectState State { get; set; }
        public ObjectTeam Team { get; }
        public ObjectType Type => ObjectType.Flag;
    }
}

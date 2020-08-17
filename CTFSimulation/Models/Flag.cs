﻿using System;
using System.Windows;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Models
{
    public class Flag : IObject
    {
        public Flag(Vector position, ObjectTeam team, ObjectState state)
        {
            Position = position;
            Team = team;
            State = state;
        }

        public Vector Position { get; set; }
        public ObjectState State { get; set; }
        public ObjectTeam Team { get; }
        public ObjectType Type => ObjectType.Flag;
    }
}

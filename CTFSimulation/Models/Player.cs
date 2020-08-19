using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Models
{
    public class Player : IPlayer
    {
        private Vector _velocity;
        private double _maxSpeed;

        public Player(int id, ObjectTeam team)
        {
            _maxSpeed = 10;
            State = ObjectState.Idle;
            Team = team;
            Id = id;
            Position = new Vector(0, 0);
            Velocity = new Vector(0, 0);
        }

        public Player(int id, ObjectTeam team, Vector position)
        {
            _maxSpeed = 10;
            State = ObjectState.Idle;
            Team = team;
            Id = id;
            Position = position;
            Velocity = new Vector(0, 0);
        }

        public Vector Position { get; set; }
        public Vector Velocity
        {
            get => _velocity;
            set
            {
                value.Normalize();
                _velocity = Vector.Multiply(value, Math.Sqrt(_maxSpeed));
            }
        }
        public ObjectState State { get; set; }
        public ObjectTeam Team { get; }
        public ObjectType Type => ObjectType.Player;
        public int Id { get; }

        public void MovePlayer()
        {
            Velocity = new Vector(5,0);
            Position += Velocity;
        }

        public void MovePlayer(IList<IObject> playerInfo)
        {
            switch (State)
            {
                case ObjectState.ReturningToBase:
                    //return to base
                    break;

                case ObjectState.CarryingFlag:
                    //carry flag
                    break;

                default:
                    AssessState(playerInfo);
                    //Decide what to do
                    //Move
                    break;
            }

        }

        private void AssessState(IList<IObject> playerInfo)
        {
            var numAttacking = playerInfo.Count(player => player.State == ObjectState.Attacking && player.Team == Team);
            var numDefending = playerInfo.Count(player => player.State == ObjectState.Defending && player.Team == Team);

            switch (State)
            {
                case ObjectState.Idle:
                    if (numAttacking > numDefending)
                    {
                        State = ObjectState.Defending;
                    }
                    else
                    {
                        State = ObjectState.Attacking;
                    }

                    break;

                case ObjectState.Attacking:
                    if (numAttacking - numDefending > 1)
                    {
                        State = ObjectState.Defending;
                    }

                    break;

                case ObjectState.Defending:
                    if (numDefending - numAttacking > 1)
                    {
                        State = ObjectState.Defending;
                    }
                    break;
            }
        }

        private void MoveToPosition(Vector targetPosition)
        {
            Vector direction = targetPosition - Position;
            direction.Normalize();

            Velocity = direction * _maxSpeed;
        }
    }
}

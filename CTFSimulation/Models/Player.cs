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
        private Vector _targetPosition;
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

        public void Move()
        {
            Velocity = new Vector(5,0);
            Position += Velocity;
        }

        public void Move(IList<IObject> players, IList<Flag> flags)
        {
            AssessState(players);
            PickTarget(players, flags);
        }

        private void PickTarget(IList<IObject> players, IList<Flag> flags)
        {
            switch (State)
            {
                case ObjectState.ReturningToBase:
                case ObjectState.CarryingFlag:
                    TargetBase(flags);
                    break;

                case ObjectState.Attacking:
                    TargetFlag(flags);
                    break;

                case ObjectState.Defending:
                    TargetAttacker(players, flags);
                    break;
            }

        }

        private void TargetBase(IList<Flag> flags)
        {
            _targetPosition = flags.Single(flag => flag.Team == Team).InitialPosition;
        }

        private void TargetFlag(IList<Flag> flags)
        {
            _targetPosition = flags.Single(flag => flag.Team != Team).InitialPosition;
        }

        private void TargetAttacker(IList<IObject> players, IList<Flag> flags)
        {
            //Look for enemy players in the attacking state
            var attackers = players.Where(player => player.Team != Team && player.State == ObjectState.Attacking);

            //Weigh up: closest player / attacker nearest flag / attacker furthest away from another defender
            foreach (var attacker in attackers)
            {
                var distanceToPlayer = (attacker.Position - Position).Length;

                var ownFlag = flags.Single(flag => flag.Team == Team);

                var distanceToFlag = (ownFlag.Position = attacker.Position).Length;
            }
        }

        private void AttackerMove()
        {
            //Check if defender in way ~ distance normal to line between target and attacker
        }

        private void AssessState(IList<IObject> players)
        {
            var numAttacking = players.Count(player => player.State == ObjectState.Attacking && player.Team == Team);
            var numDefending = players.Count(player => player.State == ObjectState.Defending && player.Team == Team);

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

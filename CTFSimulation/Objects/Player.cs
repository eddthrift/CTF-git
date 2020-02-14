using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CTFSimulation.Interfaces;
using CTFSimulation.Tools;

namespace CTFSimulation.Objects
{
    public class Player : IPlayer
    {
        private Vector _velocity;
        private double _maxSpeed;

        public Player(int playerId, PlayerTeam team)
        {
            _maxSpeed = 10;
            State = PlayerState.Idle;
            Team = team;
            PlayerId = playerId;
            Position = new Vector(0, 0);
            Velocity = new Vector(0, 0);
        }

        public Player(int playerId, PlayerTeam team, Vector position)
        {
            _maxSpeed = 10;
            State = PlayerState.Idle;
            Team = team;
            PlayerId = playerId;
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
        public PlayerState State { get; set; }
        public PlayerTeam Team { get; private set; }
        public int PlayerId { get; private set; }

        public void MovePlayer()
        {
            Velocity = new Vector(5,0);
            Position = Position + Velocity;
        }
       
    }
}

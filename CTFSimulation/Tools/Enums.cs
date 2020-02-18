using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTFSimulation.Tools
{
    public enum PlayerState
    {
        Idle,
        Attacking,
        Defending,
        ReturningToBase,
        CarryingFlag
    }

    public enum PlayerTeam
    {
        Red,
        Blue
    }

    public enum SimulationState
    {
        Running,
        BlueWin,
        RedWin
    }
}

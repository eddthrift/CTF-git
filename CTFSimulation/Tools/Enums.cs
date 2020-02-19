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

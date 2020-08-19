namespace CTFSimulation.Tools
{
    public enum ObjectState
    {
        Idle,
        Attacking,
        Defending,
        ReturningToBase,
        CarryingFlag,
        FlagInBase,
        FlagCarried
    }

    public enum ObjectTeam
    {
        Red,
        Blue,
        Neutral
    }

    public enum ObjectType
    {
        Player,
        Flag
    }

    public enum SimulationState
    {
        Running,
        BlueWin,
        RedWin
    }
}

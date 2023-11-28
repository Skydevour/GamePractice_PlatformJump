public class GameVictoryEvent
{
    public readonly bool IsVictory;
    public GameVictoryEvent(bool isVictory)
    {
        IsVictory = isVictory;
    }
}

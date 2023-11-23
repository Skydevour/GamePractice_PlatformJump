public class GateOpenOrCloseEvent
{
    public readonly bool IsOpenGate;
    public GateOpenOrCloseEvent(bool isOpenGate)
    {
        IsOpenGate = isOpenGate;
    }
}

public interface IState
{
    public void Enter();
    public void Exit();
    public void LogicalUpdate();
    public void PhysicalUpdate();
}

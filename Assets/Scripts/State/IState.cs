using System.Collections.Generic;

public interface IState
{
    public void Init(Dictionary<StateEnum, IState> stateDict);
    public void Enter();
    public void Exit();
}

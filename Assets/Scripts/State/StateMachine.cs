using UnityEngine;

public class StateMachine: MonoBehaviour
{
    private IState _currentState;
    [SerializeField] private StateInitializer _stateInitializer;
    private void Start()
    {
        var stateDict =  _stateInitializer.StateInitialization();
        stateDict[StateEnum.DrawState].Init(stateDict);
        stateDict[StateEnum.PlayState].Init(stateDict);
        
        _currentState = stateDict[StateEnum.DrawState];
        _currentState.Enter();
    }

}
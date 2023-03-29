using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;
    private Dictionary<StateEnum, IState> _stateDict = new();

    public void Initialize(Dictionary<StateEnum, IState> stateDict)
    {
        _stateDict = stateDict;
        _currentState = _stateDict[StateEnum.DrawState];
        _currentState.Enter();
    }

    public void ChangeState()
    {
        _currentState.Exit();
        switch (_currentState)
        {
            case DrawState:
                _currentState = _stateDict[StateEnum.PlayState];
                break;
            case PlayState:
                _currentState = _stateDict[StateEnum.DrawState];
                break;
            default:
                break;
        }
        _currentState.Enter();
    }
}
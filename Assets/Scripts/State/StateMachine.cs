using System;
using UnityEngine;

public class StateMachine: MonoBehaviour
{
    private IState _currentState;
    
    private void Start()
    {
        _currentState = new StartState();
        _currentState.Enter();
        
    }

    public IState GetState()
    {
        return _currentState;
    }
    
    public void ChangeState()
    {
        _currentState.Exit();
        switch (_currentState)
        {
            case StartState:
                // Debug.Log("Signal Dispatched - to End State");
                _currentState = new EndState();
                break;
            case EndState:
                //Debug.Log("Signal Dispatched - to Start State");
                _currentState = new StartState();
                break;
            default:
                break;
        }
        _currentState.Enter();
    }
    
}
using System;
using UnityEngine;

public class StateMachine: MonoBehaviour
{
    private IState _currentState;
    [SerializeField] private UIController _uiController;
    
    private void Start()
    {
        _currentState = new StartState();
        _uiController.UIEvent += ChangeState;
    }

    private void ChangeState()
    {
        
        switch (_currentState)
        {
            case StartState:
                Debug.Log("Signal Dispatched - to End State");
                _currentState = new EndState();
                break;
            case EndState:
                Debug.Log("Signal Dispatched - to Start State");
                _currentState = new StartState();
                break;
            default:
                break;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateEnumForDict
{
    StartState = 0,
    EndState = 1
}
public class StateMachine: MonoBehaviour
{
    private IState _currentState;
    [SerializeField] private UIController _uiController;
    [SerializeField] private ScoreController _scoreController;
    private Dictionary<StateEnumForDict,IState> _stateDict = new();
    private void Start()
    {
        _stateDict.Add(StateEnumForDict.StartState, new StartState(_uiController, _scoreController));
        _stateDict.Add(StateEnumForDict.EndState, new EndState(_uiController, _scoreController));
        _currentState = _stateDict[StateEnumForDict.EndState];
        _currentState.Enter();
        

    }

    private void OnEnable()
    {
        _uiController.buttonClickEvent += ChangeState;
    }
    private void OnDisable()
    {
        _uiController.buttonClickEvent -= ChangeState;
    }

    private void ChangeState()
    {
        _currentState.Exit();
        switch (_currentState)
        {
            case StartState:
                Debug.Log("Signal Dispatched - to End State");
                _currentState = _stateDict[StateEnumForDict.EndState];
                break;
            case EndState:
                Debug.Log("Signal Dispatched - to Start State");
                _currentState = _stateDict[StateEnumForDict.StartState];
                break;
            default:
                break;
        }
        _currentState.Enter();
    }
    
}
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
    [SerializeField] private ButtonController buttonController;
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private CameraController _cameraController;
    private Dictionary<StateEnumForDict,IState> _stateDict = new();
    private void Start()
    {
        _stateDict.Add(StateEnumForDict.StartState, new StartState(buttonController, _scoreController, _cameraController));
        _stateDict.Add(StateEnumForDict.EndState, new EndState(buttonController, _scoreController, _cameraController));
        _currentState = _stateDict[StateEnumForDict.EndState];
        _currentState.Enter();
    }

    private void OnEnable()
    {
        buttonController.buttonClickEvent += ChangeState;
    }
    private void OnDisable()
    {
        buttonController.buttonClickEvent -= ChangeState;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UIController : MonoBehaviour
{

    [SerializeField] private UIModel _uiModel;
    [SerializeField] private StateMachine _stateMachine;

    //TODO: Start Game or Reload Game based on UIState
    public void ToggleButton()
    {
        _stateMachine.ChangeState();
    }

    public Color GetColor(int index)
    {
        return _uiModel.GetPallete()[index];
    }
    public IState GetState()
    {
        return _stateMachine.GetState();
    }
}

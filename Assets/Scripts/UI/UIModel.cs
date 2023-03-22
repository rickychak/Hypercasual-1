using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public enum UIState
{
    GameStarted,
    GameEnded
}
public class UIModel : MonoBehaviour
{
    

    [SerializeField]private UIState _currentState;

    public void SetUIState(UIState state)
    {
        _currentState = state;
    }


    public UIState GetUIState()
    {
        return _currentState;
    }

    
}

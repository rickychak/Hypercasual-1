using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UIController : MonoBehaviour
{

    private UIModel _uiModel;
    void Start()
    {
        _uiModel = transform.GetComponent<UIModel>();
        _uiModel.SetUIState(UIState.GameEnded);
    }

    //TODO: Start Game or Reload Game based on UIState
    public UIState ToggleButton()
    {
        var _currentUIState = _uiModel.GetUIState();
        switch (_currentUIState)
        {
            case UIState.GameEnded:
                _uiModel.SetUIState(UIState.GameStarted);
                //StartGame
                break;
            case UIState.GameStarted:
                _uiModel.SetUIState(UIState.GameEnded);
                //StopGame
                break;
            default:
                break;
            //Start Game
        }

        return _uiModel.GetUIState();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
public class DrawState: IState
{
    private UIManager _uiManager;
    private CameraController _cameraController;
    private IState _nextState;
    public DrawState(UIManager uiManager, CameraController cameraController)
    {
        _uiManager = uiManager;
        _cameraController = cameraController;
    }


    public void Init(Dictionary<StateEnum, IState> stateDict)
    {
        _nextState = stateDict[StateEnum.PlayState];
        //Enter();
    }
    public void Enter()
    {
        _uiManager.GUIButtonClickSignal += Exit;
        _uiManager.ResetGUIScore();
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.GUIButtonChangeColorOnClick(0);
        
    }

    
    public void Exit()
    {
        _uiManager.GUIButtonClickSignal -= Exit;
        _nextState.Enter();
    }
}
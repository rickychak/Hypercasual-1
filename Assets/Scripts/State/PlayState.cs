using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayState: IState
{
    private UIManager _uiManager;
    private CameraController _cameraController;
    private IState _nextState;
    public PlayState(UIManager uiManager, CameraController cameraController)
    {
        _uiManager = uiManager;
        _cameraController = cameraController;
    }

    public void Init(Dictionary<StateEnum, IState> stateDict)
    {
        _nextState = stateDict[StateEnum.DrawState];
        //Enter();
    }

    public void Enter()
    {
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.GUIButtonChangeColorOnClick(1);
        _uiManager.GUIButtonClickSignal += Exit;

    }

    public void Exit()
    {
        _uiManager.GUIButtonClickSignal -= Exit;
        _nextState.Enter();
    }
} 
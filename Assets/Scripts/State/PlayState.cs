using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayState : IState
{
    private UIManager _uiManager;
    private CameraController _cameraController;
    private IState _nextState;

    public PlayState(UIManager uiManager, CameraController cameraController)
    {
        _uiManager = uiManager;
        _cameraController = cameraController;
    }

    public void Enter()
    {
        _uiManager.GUIButtonChangeColorOnClick(1);
        _uiManager.ToggleGUIScoreCounting();
    }

    public void Exit()
    {
    }
}
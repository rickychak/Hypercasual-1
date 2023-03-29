using System;
using System.Collections.Generic;
using UnityEngine;
public class DrawState : IState
{
    private UIManager _uiManager;
    private CameraController _cameraController;
    private IState _nextState;

    public DrawState(UIManager uiManager, CameraController cameraController)
    {
        _uiManager = uiManager;
        _cameraController = cameraController;
    }

    public void Enter()
    {
        _uiManager.GUIButtonChangeColorOnClick(0);
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.ResetGUIScore();
        
    }

    public void Exit()
    {
    }
}
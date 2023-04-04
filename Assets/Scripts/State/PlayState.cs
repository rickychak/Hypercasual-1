using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayState : IState
{
    private UIManager _uiManager;
    private GameplayController _gameplayController;
    private IState _nextState;
    

    public PlayState(UIManager uiManager, GameplayController gameplayController)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
    }

    public void Enter()
    {
        _uiManager.GUIButtonChangeColorOnClick(1);
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.ToggleBackgroundScrolling();
        _gameplayController.ToggleMapMovement();
        _gameplayController.CreateWheel();
    }

    public void Exit()
    {
    }
}
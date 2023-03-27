using UnityEngine;
using System;
public class StartState: IState
{
    private UIController _uiController;
    private ScoreController _scoreController;
    public StartState(UIController uiController, ScoreController scoreController)
    {
        _uiController = uiController;
        _scoreController = scoreController;
    }
    public void Enter()
    {
        _uiController.ButtonChangeColor(1);
        _scoreController.TriggerScoreUpdate();
    }

    public void Exit()
    {
        
    }
}
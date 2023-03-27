using UnityEngine;
using System;
public class StartState: IState
{
    private ButtonController _buttonController;
    private ScoreController _scoreController;
    private CameraController _cameraController;
    public StartState(ButtonController buttonController, ScoreController scoreController, CameraController cameraController)
    {
        _buttonController = buttonController;
        _scoreController = scoreController;
        _cameraController = cameraController;
    }
    public void Enter()
    {
        _buttonController.ButtonChangeColor(1);
        _scoreController.TriggerScoreUpdate();
        _cameraController.SetCameraVelocity();
    }

    public void Exit()
    {
        _scoreController.ResetScore();
    }
}
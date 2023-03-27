using UnityEditor;

public class EndState: IState
{
    private ButtonController _buttonController;
    private ScoreController _scoreController;
    private CameraController _cameraController;
    public EndState(ButtonController buttonController, ScoreController scoreController, CameraController cameraController)
    {
        _buttonController = buttonController;
        _scoreController = scoreController;
        _cameraController = cameraController;
    }
    public void Enter()
    {
        _buttonController.ButtonChangeColor(0);
        _scoreController.TriggerScoreUpdate();
        _cameraController.ResetCameraVelocity();
    }

    public void Exit()
    {
        
    }
}
using UnityEditor;

public class EndState: IState
{
    private UIController _uiController;
    private ScoreController _scoreController;
    public EndState(UIController uiController, ScoreController scoreController)
    {
        _uiController = uiController;
        _scoreController = scoreController;
    }
    public void Enter()
    {
        _uiController.ButtonChangeColor(0);
        _scoreController.TriggerScoreUpdate();
    }

    public void Exit()
    {
        
    }
}
public class GameOverState: IState
{

    private UIManager _uiManager;
    private GameplayController _gameplayController;
    public GameOverState(UIManager uiManager, GameplayController gameplayController)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
    }
    public void Enter()
    {
        
        _uiManager.FadeInGameOver();
        _uiManager.GridTurnWhite();
        _gameplayController.ResetVehicle();  
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.ToggleBackgroundScrolling();
        _gameplayController.ToggleMapMovement();
        _uiManager.SetHighestScoreText();
        
        
    }

    public void Exit()
    {
        _uiManager.FadeOutGameOver();
        _uiManager.ToggleGameOverCollider();
        _uiManager.ToggleButton();
        _gameplayController.EnableDrawing();

    }
}
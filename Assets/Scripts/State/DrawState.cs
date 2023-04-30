
public class DrawState : IState
{
    private UIManager _uiManager;
    private GameplayController _gameplayController;
    private IState _nextState;

    public DrawState(UIManager uiManager, GameplayController gameplayController)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
    }

    public void Enter()
    {
        _gameplayController.EnableDrawing();
        _uiManager.GUIButtonChangeColorOnClick(0);
        _uiManager.ResetGUIScore();
        _gameplayController.ResetMap();
        _gameplayController.SetTerrain();
        
    }

    public void Exit()
    {
    }
}
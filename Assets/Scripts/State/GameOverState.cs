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
        
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
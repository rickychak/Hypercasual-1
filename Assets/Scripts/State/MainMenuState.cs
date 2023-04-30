public class MainMenuState: IState
{

    private UIManager _uiManager;
    private GameplayController _gameplayController;
    public MainMenuState(UIManager uiManager, GameplayController gameplayController)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
    }
    public void Enter()
    {
        _uiManager.SetupMainMenuButtonsListeners();
        _uiManager.ToggleGameScoreVisibility();
        _uiManager.SetMainMenuHighestScoreText();
        _gameplayController.DisableDrawing();

    }

    public void Exit()
    {
        _uiManager.RemoveMainMenuButtonsListeners();
        _uiManager.ToggleGameScoreVisibility();
        _uiManager.ToggleHighestScoreVisibility();
        _uiManager.FadeOutMainMenu();
    }
}
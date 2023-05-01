public class AdState : IState
{
    private UIManager _uiManager;
    private GameplayController _gameplayController;
    private AdsInterstitial _adsInterstitial;
    private IState _nextState;
    

    public AdState(UIManager uiManager, GameplayController gameplayController)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
    }

    public void Enter()
    {
        _uiManager.ToggleGUIScoreCounting();
        _gameplayController.ToggleMapMovement();
    }

    public void Exit()
    {
    }
}
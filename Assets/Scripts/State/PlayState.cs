
public class PlayState : IState
{
    private UIManager _uiManager;
    private GameplayController _gameplayController;
    private AdsInterstitial _adsInterstitial;
    private IState _nextState;
    

    public PlayState(UIManager uiManager, GameplayController gameplayController, AdsInterstitial adsInterstitial)
    {
        _uiManager = uiManager;
        _gameplayController = gameplayController;
        _adsInterstitial = adsInterstitial;
    }

    public void Enter()
    {
        
        _uiManager.GUIButtonChangeColorOnClick(1);
        _uiManager.ToggleGUIScoreCounting();
        _uiManager.ToggleBackgroundScrolling();
        _gameplayController.ToggleMapMovement();
        _gameplayController.CreateVehicle();
        _gameplayController.DisableDrawing();
    }

    public void Exit()
    {
        _uiManager.ToggleGameOverCollider();
        _uiManager.ToggleButton();
        _uiManager.SetGameOverScoreText();
        _adsInterstitial.LoadAd();
        
    }
}
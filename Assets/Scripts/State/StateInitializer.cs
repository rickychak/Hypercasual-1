using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    MainMenuState,
    DrawState,
    PlayState,
    GameOverState,
    AdState
}


public class StateInitializer : MonoBehaviour
{
    private StateMachine _stateMachine;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameplayController _gameplayController;
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private AdsInterstitial _adsInterstitial;

    private Dictionary<StateEnum, IState> _stateDict = new();

    private void Start()
    {
        _stateMachine = new StateMachine();
        _eventManager.GUIButtonClickSignal += OnGUIButtonClick;
        _eventManager.GameOverSignal += OnGUIButtonClick;
        _stateDict.Add(StateEnum.MainMenuState, new MainMenuState(_uiManager, _gameplayController));
        _stateDict.Add(StateEnum.DrawState, new DrawState(_uiManager, _gameplayController));
        _stateDict.Add(StateEnum.PlayState, new PlayState(_uiManager, _gameplayController, _adsInterstitial));
        _stateDict.Add(StateEnum.AdState, new AdState(_uiManager, _gameplayController));
        _stateDict.Add(StateEnum.GameOverState, new GameOverState(_uiManager, _gameplayController));
        _stateMachine.Initialize(_stateDict);
    }

    private void OnGUIButtonClick()
    {
        _stateMachine.ChangeState();
    }
}


public interface IStateInitializer
{
    public Dictionary<StateEnum, IState> StateInitialization();
}
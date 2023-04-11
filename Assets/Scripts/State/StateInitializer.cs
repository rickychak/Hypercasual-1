using System.Collections.Generic;
using UnityEngine;

public enum StateEnum
{
    MenuState,
    DrawState,
    PlayState,
    GameOverState,
    RestartState
}


public class StateInitializer : MonoBehaviour
{
    private StateMachine _stateMachine;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameplayController _gameplayController;
    [SerializeField] private EventManager _eventManager;

    private Dictionary<StateEnum, IState> _stateDict = new();

    private void Start()
    {
        _stateMachine = new StateMachine();
        _eventManager.GUIButtonClickSignal += OnGUIButtonClick;
        _eventManager.GameOverSignal += OnGUIButtonClick;
        _stateDict.Add(StateEnum.DrawState, new DrawState(_uiManager, _gameplayController));
        _stateDict.Add(StateEnum.PlayState, new PlayState(_uiManager, _gameplayController));
        _stateMachine.Initialize(_stateDict);
    }

    private void OnGUIButtonClick()
    {
        Debug.Log("Here we go");
        _stateMachine.ChangeState();
    }
}


public interface IStateInitializer
{
    public Dictionary<StateEnum, IState> StateInitialization();
}
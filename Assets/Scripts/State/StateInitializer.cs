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
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private CameraController _uiCameraController;
    [SerializeField] private EventManager _eventManager;

    private Dictionary<StateEnum, IState> _stateDict = new();

    private void Start()
    {
        _eventManager.GUIButtonClickSignal += OnGUIButtonClick;
        _stateDict.Add(StateEnum.DrawState, new DrawState(_uiManager, _uiCameraController));
        _stateDict.Add(StateEnum.PlayState, new PlayState(_uiManager, _uiCameraController));
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
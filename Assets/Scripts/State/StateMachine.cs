using System.Collections.Generic;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<StateEnum, IState> _stateDict = new();

    public void Initialize(Dictionary<StateEnum, IState> stateDict)
    {
        _stateDict = stateDict;
        _currentState = _stateDict[StateEnum.MainMenuState];
        _currentState.Enter();
    }

    public void ChangeState()
    {
        _currentState.Exit();
        switch (_currentState)
        {
            case MainMenuState:
                _currentState = _stateDict[StateEnum.DrawState];
                break;
            case DrawState:
                _currentState = _stateDict[StateEnum.PlayState];
                break;
            case PlayState:
                _currentState = _stateDict[StateEnum.AdState];
                break;
            case AdState:
                _currentState = _stateDict[StateEnum.GameOverState];
                break;
            case GameOverState:
                _currentState = _stateDict[StateEnum.DrawState];
                break;
            default:
                break;
        }
        _currentState.Enter();
    }
}
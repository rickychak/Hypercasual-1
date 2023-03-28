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


public class StateInitializer: MonoBehaviour, IStateInitializer
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private CameraController _uiCameraController;
    private Dictionary<StateEnum, IState> _stateDict = new();

    public Dictionary<StateEnum, IState> StateInitialization()
    {
        _stateDict.Add(StateEnum.DrawState, new DrawState(_uiManager, _uiCameraController));
        _stateDict.Add(StateEnum.PlayState, new PlayState(_uiManager, _uiCameraController));
        return _stateDict;
    }
    
    

}

public interface IStateInitializer
{
    public Dictionary<StateEnum, IState> StateInitialization();
}
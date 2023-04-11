using System;
using UnityEngine;

public class EventManager : MonoBehaviour, IEventManager
{
    public event Action GUIButtonClickSignal;
    public event Action GameOverSignal;
    public void DispatchGUIButtonSignal()
    {
        GUIButtonClickSignal?.Invoke();
    }

    public void DispatchGameOverSignal()
    {
        GameOverSignal?.Invoke();
    }
}

public interface IEventManager
{
    event Action GUIButtonClickSignal;
    void DispatchGUIButtonSignal();
    void DispatchGameOverSignal();
}

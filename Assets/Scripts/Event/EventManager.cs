using System;
using UnityEngine;

public class EventManager : MonoBehaviour, IEventManager
{
    public event Action GUIButtonClickSignal;
    public void DispatchGUIButtonSignal()
    {
        GUIButtonClickSignal?.Invoke();
    }
}

public interface IEventManager
{
    event Action GUIButtonClickSignal;
    void DispatchGUIButtonSignal();
}

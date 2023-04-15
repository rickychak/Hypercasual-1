using System;
using UnityEngine;

public class EventManager : MonoBehaviour, IEventManager
{
    public event Action GUIButtonClickSignal;
    public event Action GameOverSignal;
    public event Action<Vector3> UserInputOnGridSignal;
    public event Action<bool> EnableDrawingGridSignal;
    public void DispatchGUIButtonSignal()
    {
        GUIButtonClickSignal?.Invoke();
    }

    public void DispatchGameOverSignal()
    {
        GameOverSignal?.Invoke();
    }
    
    public void DispatchInputCoordinateSignal(Vector3 touchPoint)
    {
        UserInputOnGridSignal?.Invoke(touchPoint);
    }

    public void DispatchInputEnableSignal(bool boo)
    {
        EnableDrawingGridSignal?.Invoke(boo);
    }
}

public interface IEventManager
{
    event Action GUIButtonClickSignal;
    void DispatchGUIButtonSignal();
    void DispatchGameOverSignal();
}

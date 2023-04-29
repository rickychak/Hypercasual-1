using TMPro;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private EventManager _eventManager;
    private void OnEnable()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Boundary")) return;
        _eventManager.DispatchGameOverSignal();
    }
    
}

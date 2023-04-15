using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private EventManager _eventManager;
    private bool _isCollided = false;
    private void OnEnable()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Boundary") && col.gameObject.layer != 6) return;
        if (_isCollided) return;
        _isCollided = true;
        _eventManager.DispatchGameOverSignal();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(col.gameObject.layer);
        if (!col.transform.CompareTag("Boundary") && col.gameObject.layer != 6) return;
        _eventManager.DispatchGameOverSignal();
        

    }
}

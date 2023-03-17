using System;
using UnityEngine;


public class Vehicle: MonoBehaviour
{
    public static Vehicle Instance;
    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Boundary")) return;
        Debug.Log("GameOver");
    }
    
    public void StopVehicle()
    {
        _rb2D.simulated = false;
        transform.position = Controllables.Instance.vehicleOriginalPosition;
        _rb2D.velocity = Vector2.zero;
    }
    public void StartVehicle()
    {
        _rb2D.simulated = true;
    }
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}

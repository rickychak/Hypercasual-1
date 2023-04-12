using System.Collections;
using System;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GridController _gridController;
    [SerializeField] private TerrainController _terrainController;
    [SerializeField] private VehicleFactory _vehicleFactory;
    [SerializeField] private EventManager _eventManager;
    
    private Vector3 _touchPosition;
    private RaycastHit2D _raycastHit2D;
    private Vector3Int _cellPosition;


    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }
    

    public void ToggleMapMovement()
    {
        _terrainController.ToggleMapSimulation();
    }

    public void ToggleDrawing()
    {
        _gridController.ToggleGridDrawing();
    }

    
    public void ResetVehicle()
    {
        _vehicleFactory.ResetVehicle();
        _gridController.SetWholeGrid(false);
    }
    public void CreateVehicle()
    {
        _vehicleFactory.CreateVehicle();
    }
}

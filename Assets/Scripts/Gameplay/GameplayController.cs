using System.Collections;
using System;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GridModel _gridModel;
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
    
    
    private int CellPositionToGridIndex(Vector3Int cellPosition)
    {
        var gridResolution = _gridModel.GetCellResolution();
        var cleansedCellPosition = new Vector2(cellPosition.x + gridResolution.x/2,
            cellPosition.y + gridResolution.y-1);

        var gridIndex = (cleansedCellPosition.x - (cleansedCellPosition.y - gridResolution.y) * gridResolution.x);
        return (int)gridIndex;
    }
    public void ToggleCell(Vector3Int cellPosition)
    {
        var cellIndex = CellPositionToGridIndex(cellPosition);
        if (_gridModel.GetCellByIndex(cellIndex)) return;
        _gridModel.ToggleCell(cellIndex, true);
    }

    public void ResetVehicle()
    {
        _vehicleFactory.ResetVehicle();
    }
    public void CreateVehicle()
    {
        _vehicleFactory.CreateVehicle();
    }
}

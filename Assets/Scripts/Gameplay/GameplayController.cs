using System.Collections;
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

    public void ResetMap()
    {
        _terrainController.ResetMapCoordinate();
    }

    public void DisableDrawing()
    {
        _eventManager.DispatchInputEnableSignal(false);
    }
    
    public void EnableDrawing()
    {
        StartCoroutine(_coToggleGridDrawing(true));
    }

    private IEnumerator _coToggleGridDrawing(bool boo)
    {
        yield return new WaitForSeconds(0.35f);
        _eventManager.DispatchInputEnableSignal(boo);
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

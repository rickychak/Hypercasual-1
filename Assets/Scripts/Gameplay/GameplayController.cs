using System.Collections;
using System;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField]private GridModel _gridModel;
    private GridView _gridView;
    [SerializeField] private CameraModel _cameraModel;
    private Camera _mainCamera;
    private Vector3 _touchPosition;
    private RaycastHit2D _raycastHit2D;
    
    private Vector3Int _cellPosition;
    public event Action<Vector3> InputEvent;
    
    [SerializeField] private LayerMask _layerMask;


    private void Start()
    {
        _gridModel.GridInitialisation();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        SetInputModelCellPosition();
    }

    public void SetCameraVelocity() 
    {
        _mainCamera.transform.GetComponent<Rigidbody2D>().AddForce(_cameraModel.GetCameraMovementVelocity());
    }
    public void ResetCameraVelocity()
    {
        _mainCamera.transform.GetComponent<Rigidbody2D>().AddForce(0*_cameraModel.GetCameraMovementVelocity());
    }

    private void SetInputModelCellPosition()
    {
        if (Input.touchCount <= 0) return;
        _touchPosition = Input.GetTouch(0).position;
        _raycastHit2D = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touchPosition), Vector3.back, 5, _layerMask);
        //if (_raycastHit2D.collider == null) return;
        if (ReferenceEquals(_raycastHit2D.collider, null)) return;
        InputEvent?.Invoke(_mainCamera.ScreenToWorldPoint(_touchPosition));
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
}

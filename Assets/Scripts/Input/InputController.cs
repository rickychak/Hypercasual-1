using System;
using UnityEngine;

public class InputController : MonoBehaviour, IInputController
{
    private Camera _mainCamera;
    private Vector3 _touchPosition;
    private RaycastHit2D _raycastHit2D;
    
    private Vector3Int _cellPosition;
    private EventManager _eventManager;
    
    [SerializeField] private LayerMask _layerMaskForGrid;
    [SerializeField] private LayerMask _layerMaskForScreen;

    private bool _enableDrawing = true;

    void Awake()
    {
        _mainCamera = Camera.main;
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnEnable()
    {
        _eventManager.EnableDrawingGridSignal += ToggleDrawing;
    }
    private void OnDisable()
    {
        _eventManager.EnableDrawingGridSignal -= ToggleDrawing;
    }

    private void ToggleDrawing(bool boo)
    {
        _enableDrawing = boo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0 ) return;
        DetectStateTransitionOnClick();
        if (!_enableDrawing) return;
        SetInputModelCellPosition();
        
    }

    public void DetectStateTransitionOnClick()
    {
        
        _raycastHit2D = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touchPosition), Vector3.back, 5, _layerMaskForScreen);
        if (ReferenceEquals(_raycastHit2D.collider, null)) return;
        _eventManager.DispatchGUIButtonSignal();
    }
    
    public void SetInputModelCellPosition()
    {
        _touchPosition = Input.GetTouch(0).position;
        _raycastHit2D = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touchPosition), Vector3.back, 5, _layerMaskForGrid);
        //if (_raycastHit2D.collider == null) return;
        if (ReferenceEquals(_raycastHit2D.collider, null)) return;
        _eventManager.DispatchInputCoordinateSignal(_mainCamera.ScreenToWorldPoint(_touchPosition));
    }
}


public interface IInputController
{
    public void SetInputModelCellPosition();
}

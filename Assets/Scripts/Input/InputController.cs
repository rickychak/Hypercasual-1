using System;
using UnityEngine;

public class InputController : MonoBehaviour, IInputController
{
    private Camera _mainCamera;
    private Vector3 _touchPosition;
    private RaycastHit2D _raycastHit2D;
    
    private Vector3Int _cellPosition;
    private EventManager _eventManager;
    
    [SerializeField] private LayerMask _layerMask;


    void Awake()
    {
        _mainCamera = Camera.main;
        _eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetInputModelCellPosition();
    }

    public void SetInputModelCellPosition()
    {
        if (Input.touchCount <= 0) return;
        _touchPosition = Input.GetTouch(0).position;
        _raycastHit2D = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touchPosition), Vector3.back, 5, _layerMask);
        //if (_raycastHit2D.collider == null) return;
        if (ReferenceEquals(_raycastHit2D.collider, null)) return;
        _eventManager.DispatchInputSignal(_mainCamera.ScreenToWorldPoint(_touchPosition));
    }
}


public interface IInputController
{
    public void SetInputModelCellPosition();
}

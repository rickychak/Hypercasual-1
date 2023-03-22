using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputController : MonoBehaviour, IInputController
{
    private Camera _mainCamera;
    private Vector3 _touchPosition;
    private RaycastHit2D _raycastHit2D;
    
    private Vector3Int _cellPosition;
    public event Action<Vector3> InputEvent;
    
    [SerializeField] private LayerMask _layerMask;


    void Start()
    {
        _mainCamera = Camera.main;
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
        InputEvent?.Invoke(_mainCamera.ScreenToWorldPoint(_touchPosition));
    }
    
    
}


public interface IInputController
{
    public void SetInputModelCellPosition();
}

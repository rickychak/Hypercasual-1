using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _tileMap;
    private Vector3 _touchPoint;
    private RaycastHit2D _raycastHit2D;
    private Camera _mainCamera;
    
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0) return;
        _touchPoint = Input.GetTouch(0).position;
        _raycastHit2D = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(_touchPoint), Vector3.back, 100);
    }
    
    
}

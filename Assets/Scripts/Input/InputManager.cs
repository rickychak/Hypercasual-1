using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _tileMap;
    private Vector3 _touchPoint;
    private Vector3Int _tileCellPosition;
    private RaycastHit2D _raycastHit2D;
    private Camera _mainCamera;
    private Tilemap _tilemap;
    
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
        _tilemap = _raycastHit2D.collider.GetComponent<Tilemap>();
        _tileCellPosition = _tilemap.WorldToCell(_mainCamera.ScreenToWorldPoint(_touchPoint));
        _tilemap.SetTileFlags(_tileCellPosition, TileFlags.None);
        _tilemap.SetColor(_tileCellPosition, Color.black);

    }
    
    
}

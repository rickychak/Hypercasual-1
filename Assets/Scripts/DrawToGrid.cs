using UnityEngine;

public class DrawToGrid : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] bool[] _mapGrid = new bool[140];
    [SerializeField] private LayerMask _mask;
    
    void Awake()
    {
        _cam = Camera.main;
        for (int i = 0; i<_mapGrid.Length; i++)
        {
            _mapGrid[i] = false;
        }
    }

    public bool[] MapGridGetter() {return _mapGrid;}
    void Update()
    {
        if (Input.touchCount <= 0) return;
        
        Vector3 touchPoint = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)touchPoint, _cam.transform.forward, 100.0f, _mask);
        if (!hit) return;
        if (hit.collider.gameObject.TryGetComponent<SpriteRenderer>(out var sr))
        {
            if (_mapGrid[hit.collider.gameObject.transform.GetSiblingIndex()] == true) return;
            sr.color = Color.black;
            _mapGrid[hit.collider.gameObject.transform.GetSiblingIndex()] = true;
        }
    }
    
    
}



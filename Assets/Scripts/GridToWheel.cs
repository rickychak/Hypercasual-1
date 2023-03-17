using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Wheel
{
    public GameObject WheelGameObject { get; set; }
    public Transform WheelTransform { get; set; }
    public Rigidbody2D WheelRigidBody { get; set; }
        
}
public class GridToWheel : MonoBehaviour
{
    public static GridToWheel Instance;
    
    [SerializeField] private DrawToGrid _mapGrid;
    [SerializeField] private GameObject _vehicle;
    
    private bool[] _wheelGrid;
    public bool isStarted { get; set; }
    private GameObject[] _btns = new GameObject[2];
    private List<SpriteRenderer>[] _spriteRendererList = new List<SpriteRenderer>[2];
    private List<BoxCollider2D>[] _boxCollider2DList = new List<BoxCollider2D>[2];
    private Wheel[] _wheels = new Wheel[2];
    

    private Color _fullAlpha = Color.black;
    private Color _transparent = new Color(255, 255, 255, 0);

    
    // Start is called before the first frame update
    
    void Awake(){
        for (int i = 0; i < _vehicle.transform.childCount; i++)
        {
            _wheels[i].WheelGameObject = _vehicle.transform.GetChild(i).gameObject;
            _wheels[i].WheelTransform = _wheels[i].WheelGameObject.transform;
            _wheels[i].WheelRigidBody = _wheels[i].WheelGameObject.GetComponent<Rigidbody2D>();

        }
        _wheelGrid = _mapGrid.MapGridGetter();
        
    }

    public void GridToWheelStartSetup()
    {
        for (int i = 0; i < 2; i++)
        {
            var children = _wheels[i].WheelGameObject.transform;
            _spriteRendererList[i] = new List<SpriteRenderer>();
            _boxCollider2DList[i] = new List<BoxCollider2D>();

            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (!children.GetChild(j).transform.TryGetComponent(out SpriteRenderer sr) ||
                    !children.GetChild(j).transform.TryGetComponent(out BoxCollider2D bc2)) return;
                _spriteRendererList[i].Add(sr);
                _boxCollider2DList[i].Add(bc2);
            }
        }
        isStarted = false;
    }
    public void ResetWheelAndGrid()
    {
        
        for (int i = 0; i < _wheels.Length; i++)
        {
            
            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (!_wheelGrid[j]) continue;
                _spriteRendererList[i][j].color = _transparent;
                _boxCollider2DList[i][j].enabled = false;
                
            }
        }
    }
    public void SetGridToWheel()
    {
        
        for (int i = 0; i < _wheels.Length; i++)
        {
            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (!_wheelGrid[j]) continue;
                _spriteRendererList[i][j].color = _fullAlpha;
                _boxCollider2DList[i][j].enabled = true;
            }
        }
    }

    public void StartSignalToggle()
    {
        isStarted = !isStarted;
    }

    public bool StartSignalGetter()
    {
        return isStarted;
    }
    
    
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}

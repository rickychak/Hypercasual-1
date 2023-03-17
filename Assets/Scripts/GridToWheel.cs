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
    
    [SerializeField] private DrawToGrid _mapGrid;
    [SerializeField] private GameObject _vehicle;
    [SerializeField] private GameObject _buttonParent;
    
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
        for (int i = 0; i < _buttonParent.transform.childCount; i++)
        {
            _btns[i] = _buttonParent.transform.GetChild(i).gameObject;
            
        }
        _wheelGrid = _mapGrid.MapGridGetter();
        
    }
    
    void Start()
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
        OnStartSetup();
    }
    private void WheelReset()
    {
        Wheels.Instance.ResetWheel();
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
    private void WheelSet()
    {
        Wheels.Instance.SetWheel();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (!_wheelGrid[j]) continue;
                _spriteRendererList[i][j].color = _fullAlpha;
                _boxCollider2DList[i][j].enabled = true;
            }
        }
    }
    private void OnStartSetup()
    {
        isStarted = false;
        Vehicle.Instance.StopVehicle();
        //_vehicle.GetComponent<Rigidbody2D>().simulated = false;
        
    }
    public void RestartGame()
    {
        if (!isStarted) return;
        isStarted = false;
        WheelReset();
        Vehicle.Instance.StopVehicle();
        Score.Instance.UploadScore();
        _mapGrid.MapGridReset();
        Buttons.Instance.ToggleButton();
        
    }

    private void Update()
    {
        if (!isStarted) return;
        Score.Instance.UpdateScore();
    }

    public void StartGame()
    {
        if (isStarted) return;
        isStarted = true;
        Vehicle.Instance.StartVehicle();
        Wheels.Instance.SetVelocity();
        Buttons.Instance.ToggleButton();
        WheelSet();

    }
}

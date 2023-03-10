using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridToWheel : MonoBehaviour
{
    [SerializeField] private DrawToGrid _mapGrid;
    private bool[] _wheelGrid;
    [SerializeField] private GameObject[] _wheels;
    private Color _fullAlpha = Color.black;
    private Color _transparent;
    public bool isStarted { get; set; }
    private List<SpriteRenderer> _srs = new();
    private List<BoxCollider2D> _bcs = new();

    private Vector2 _startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        _startingPoint = _wheels[0].transform.position;
        _wheels = GameObject.FindGameObjectsWithTag("Wheel");
        _wheelGrid = _mapGrid.MapGridGetter();
        _transparent = new Color(_fullAlpha.r, _fullAlpha.g, _fullAlpha.b, 0);
        for (int i = 0; i < _wheelGrid.Length; i++)
        {
            var children = _wheels[0].transform.GetChild(i).gameObject;
            _srs.Add(children.GetComponent<SpriteRenderer>());
            _bcs.Add(children.GetComponent<BoxCollider2D>());
        }

        _wheels[0].GetComponent<Rigidbody2D>().simulated = false;

    }

    public void StartGame()
    {
        isStarted = true;
        //_wheels[0].transform.position = _startingPoint;
        //_wheels[0].transform.rotation = Quaternion.identity;
        _wheels[0].GetComponent<Rigidbody2D>().simulated = true;
        for (int i = 0; i < _wheelGrid.Length; i++)
        {
            if (_wheelGrid[i])
            {
                _srs[i].color = _fullAlpha;
                _bcs[i].enabled = true;
            }
            else
            {
                _srs[i].color = _transparent;
                _bcs[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

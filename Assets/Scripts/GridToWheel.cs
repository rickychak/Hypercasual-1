using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridToWheel : MonoBehaviour
{
    [SerializeField] private DrawToGrid _mapGrid;
    [SerializeField] private GameObject _vehicle;
    
    private bool[] _wheelGrid;
    public bool isStarted { get; set; }
    
    private GameObject[] _wheels = new GameObject[2];
    private List<SpriteRenderer>[] _spriteRendererList = new List<SpriteRenderer>[2];
    private List<BoxCollider2D>[] _boxCollider2DList = new List<BoxCollider2D>[2];
    
    private Color _fullAlpha = Color.black;
    private Color _transparent = new Color(255, 255, 255, 0);
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _vehicle.transform.childCount; i++)
        {
            _wheels[i] = _vehicle.transform.GetChild(i).gameObject;
        }

        _wheelGrid = _mapGrid.MapGridGetter();

        for (int i = 0; i < 2; i++)
        {
            var children = _wheels[i].transform;
            _spriteRendererList[i] = new List<SpriteRenderer>();
            _boxCollider2DList[i] = new List<BoxCollider2D>();
            
            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (!children.GetChild(j).transform.TryGetComponent(out SpriteRenderer sr) || !children.GetChild(j).transform.TryGetComponent(out BoxCollider2D bc2)) return;
                _spriteRendererList[i].Add(sr);
                _boxCollider2DList[i].Add(bc2);
            }
        }
        
        OnStartSetup();

    }

    private void OnStartSetup()
    {
        isStarted = false;
        _vehicle.GetComponent<Rigidbody2D>().simulated = false;
        foreach (var wheel in _wheels)
        {
            wheel.GetComponent<Rigidbody2D>().simulated = false;
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void StartGame()
    {
        isStarted = true;
        _vehicle.GetComponent<Rigidbody2D>().simulated = true;
        for (int i = 0; i < 2; i++)
        {
            _wheels[i].GetComponent<Rigidbody2D>().simulated = true;
            for (int j = 0; j < _wheelGrid.Length; j++)
            {
                if (_wheelGrid[j])
                {
                    _spriteRendererList[i][j].color = _fullAlpha;
                    _boxCollider2DList[i][j].enabled = true;
                }
                else
                {
                    _spriteRendererList[i][j].color = _transparent;
                    _boxCollider2DList[i][j].enabled = false;
                }
            }
        }
    }
}

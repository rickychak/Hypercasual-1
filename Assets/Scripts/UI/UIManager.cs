using System;
using DG.Tweening;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class UIManager : MonoBehaviour
{
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private GameObject _buttonGameObject;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _gameOverHighestScore;
    [SerializeField] private GameObject _gameOverCurrentScore;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject backgroundParent;
    [SerializeField] private GameObject leftBound;
    [SerializeField] private Tilemap _tilemap;
    
    private Vector2 _backgroundScrollingSpeed = Vector2.left;
    private GameObject _lastQueueObject;
    private List<GameObject> _backgroundsList;
    private Queue<GameObject> _backgroundsQueue = new();
    private Rigidbody2D[] _backgroundRigidbody2DsArray; 
    
    private readonly Color[] _colourpalette = { new Color(0.43f, 1f, 0.38f), new Color(1f, 0.5f, 0.46f) };
    private Button _button;
    private Image _image;

    private float _score;
    private bool _isScoreCounting = false;

    private Vector3 _gameoverScreenOriginalScale = new Vector3(900,2000,1);
    private GridController _gridController;


    private void OnEnable()
    {
        _eventManager.UserInputOnGridSignal += CellTurnBlackOnClick;
    }
    
    private void OnDisable()
    {
        _eventManager.UserInputOnGridSignal -= CellTurnBlackOnClick;
    }

 
    void Awake()
    {
        BackGroundGameObjectsSetup();
        _button = _buttonGameObject.transform.GetComponent<Button>();
        _image = _buttonGameObject.transform.GetComponent<Image>();
        _button.onClick.AddListener(DispatchGUIButtonSignal);
        _gridController = FindObjectOfType<GridController>();
    }
    
    #region Button
    private void DispatchGUIButtonSignal()
    {
        _eventManager.DispatchGUIButtonSignal();
    }

    public void GUIButtonChangeColorOnClick(int index)
    {
        _image.color = _colourpalette[index];
    }

    public void ToggleButton()
    {
        _button.enabled = !_button.enabled;
    }
    
    #endregion

    #region Score 
    public void ToggleGUIScoreCounting()
    {
        _isScoreCounting = !_isScoreCounting;
    }

    public void ResetGUIScore()
    {
        _score = 0;
        SetGUIScoreText();
    }

    private void SetGUIScoreText()
    {
        _text.text = _score.ToString("0.00");
    }

    public void SetGameOverScoreText()
    {
        _gameOverCurrentScore.GetComponent<TextMeshPro>().text = _score.ToString("0.00");
        if (_score <= (float)Convert.ToDouble(_gameOverHighestScore.GetComponent<TextMeshPro>().text)) return;
        _gameOverHighestScore.GetComponent<TextMeshPro>().text = _score.ToString("0.00");
    }

    #endregion

    #region Background
    private void BackGroundGameObjectsSetup()
    {
        _backgroundsList = GetBackgroundGameObjects();
        _backgroundRigidbody2DsArray = backgroundParent.GetComponentsInChildren<Rigidbody2D>();
        foreach (var mapGo in _backgroundsList)
        {
            _backgroundsQueue.Enqueue(mapGo);
            _lastQueueObject = mapGo;
        }

        foreach (var bgrb2 in _backgroundRigidbody2DsArray)
        {
            bgrb2.velocity = _backgroundScrollingSpeed;
        }
    }

    private List<GameObject> GetBackgroundGameObjects()
    {
        var backgroundArray = new List<GameObject>();
        for (int i = 0; i < backgroundParent.transform.childCount; i++)
        {
            backgroundArray.Add(backgroundParent.transform.GetChild(i).gameObject);
        }

        return backgroundArray;
    }
    public void ToggleBackgroundScrolling()
    {
        foreach (var bgrb2 in _backgroundRigidbody2DsArray)
        {
            bgrb2.simulated = !bgrb2.simulated;
        }
    }

    private void BackgroundReposition()
    {
        var outBoundBackground = _backgroundsQueue.Dequeue();
        outBoundBackground.transform.position = _lastQueueObject.transform.position + Vector3.right * 8.0f;
        _lastQueueObject = outBoundBackground;
        _backgroundsQueue.Enqueue(_lastQueueObject);
    }
    
    #endregion
    
    #region Grid
    private void CellTurnBlackOnClick(Vector3 touchPosition)
    { 
        
        var cellPosition = _tilemap.WorldToCell(touchPosition); 
        _tilemap.SetTileFlags(cellPosition, TileFlags.None); 
        _tilemap.SetColor(cellPosition, Color.black); 
        _gridController.ToggleCell(cellPosition);
    }

    public void GridTurnWhite()
    {
        BoundsInt bounds = _tilemap.cellBounds;
        foreach (var position in bounds.allPositionsWithin)
        {
            _tilemap.SetColor(position, Color.white);
        }
    }
   
   
    #endregion

    #region GameOverScreem
    public void FadeInGameOver()
    {
        Tween myTween = _gameOverScreen.transform.DOScale(_gameoverScreenOriginalScale, 0.5f);
    }
    
    public void FadeOutGameOver()
    {
        Tween myTween = _gameOverScreen.transform.DOScale(Vector3.zero, 0.5f);
        
    }

    public void ToggleGameOverCollider()
    {
        _gameOverScreen.transform.GetComponent<BoxCollider2D>().enabled = !_gameOverScreen.transform.GetComponent<BoxCollider2D>().enabled;
    }
    #endregion
    
    
    
    private void Update()
    {
        if(_backgroundsQueue.Peek().transform.position.x+0.5f < leftBound.transform.position.x) BackgroundReposition();
        if (!_isScoreCounting) return;
        _score += Time.deltaTime;
        SetGUIScoreText();
    }
}

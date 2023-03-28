using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _buttonGameObject;
    [SerializeField] private TextMeshProUGUI _text;
    
    public event Action GUIButtonClickSignal;
    private Color[] _colorPallete = { new Color(0.43f, 1f, 0.38f), new Color(1f, 0.5f, 0.46f) };

    private Button _button;
    private Image _image;
    private float _score;
    private bool _isScoreCounting = true;
    void Start()
    {
        _button = _buttonGameObject.transform.GetComponent<Button>();
        _image = _buttonGameObject.transform.GetComponent<Image>();
        _button.onClick.AddListener(DispatchGUIButtonSignal);    
    }

    void DispatchGUIButtonSignal()
    {
        GUIButtonClickSignal?.Invoke();
    }

    public void GUIButtonChangeColorOnClick(int index)
    {
        _image.color = _colorPallete[index];
    }

    public void ToggleGUIScoreCounting()
    {
        _isScoreCounting = !_isScoreCounting;
    }

    public void ResetGUIScore()
    {
        _score = 0;
    }

    private void SetGUIScoreText()
    {
        _text.text = _score.ToString("0.00");
    }

    private void Update()
    {
        if (!_isScoreCounting) return;
        _score += Time.deltaTime;
        SetGUIScoreText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    private Button _button;
    private Image _image;
    [SerializeField] private UIController _uiController;
    // Start is called before the first frame update
    void Start()
    {
        _button = transform.GetComponent<Button>();
        _image = transform.GetComponent<Image>();
        _button.onClick.AddListener(ButtonChangeColorOnClick);
    }


    private void ButtonChangeColorOnClick()
    {
        _uiController.ToggleButton();
        switch (_uiController.GetState())
        {
            case StartState:
                _image.color = _uiController.GetColor(0);
                Debug.Log(_uiController.GetColor(0));
                break;
            case EndState:
                _image.color = _uiController.GetColor(1);
                Debug.Log(_uiController.GetColor(1));
                break;
            default:
                break;
        }
    }

    
}

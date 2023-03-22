using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Button _button;
    private UIController _uiController;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(ButtonChangeColorOnClick);
    }


    private void ButtonChangeColorOnClick()
    {
        var currentState = _uiController.ToggleButton();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

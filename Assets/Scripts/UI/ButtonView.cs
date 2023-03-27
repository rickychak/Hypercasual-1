using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    private Button _button;
    [SerializeField] private ButtonController buttonController;

    
    // Start is called before the first frame update
    void Start()
    {
        _button = transform.GetComponent<Button>();
        _button.onClick.AddListener(ButtonChangeColorOnClick);
    }
    
    private void ButtonChangeColorOnClick()
    {
        buttonController.ToggleButton();
    }

    
}

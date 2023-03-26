using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    private Button _button;
    [SerializeField] private UIController _uiController;
    // Start is called before the first frame update
    void Start()
    {
        _button = transform.GetComponent<Button>();
        _button.onClick.AddListener(ButtonChangeColorOnClick);
    }


    private void ButtonChangeColorOnClick()
    {
        _uiController.ToggleButton();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

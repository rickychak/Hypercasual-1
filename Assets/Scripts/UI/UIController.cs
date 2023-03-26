using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UIController : MonoBehaviour
{

    private UIModel _uiModel;
    public event Action UIEvent; 
    void Start()
    {
        // _uiModel = transform.GetComponent<UIModel>();
        // _uiModel.SetUIState(UIState.GameEnded);
    }

    //TODO: Start Game or Reload Game based on UIState
    public void ToggleButton()
    {
        UIEvent?.Invoke();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

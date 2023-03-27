using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UIController : MonoBehaviour
{

    [SerializeField] private UIModel _uiModel;
    public event Action buttonClickEvent;
    //TODO: Start Game or Reload Game based on UIState
    public void ToggleButton()
    {
        buttonClickEvent?.Invoke();
    }

    public void ButtonChangeColor(int stateIndex)
    {
        _uiModel.GetImage().color = GetColor(stateIndex);
    }
    public Color GetColor(int index)
    {
        return _uiModel.GetPallete()[index];
    }
}

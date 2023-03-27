using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private ButtonModel buttonModel;
    public event Action buttonClickEvent;
    //TODO: Start Game or Reload Game based on UIState
    public void ToggleButton()
    {
        buttonClickEvent?.Invoke();
    }

    public void ButtonChangeColor(int stateIndex)
    {
        buttonModel.GetImage().color = GetColor(stateIndex);
    }
    public Color GetColor(int index)
    {
        return buttonModel.GetPallete()[index];
    }
}

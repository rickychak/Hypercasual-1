using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIModel : MonoBehaviour
{
    public enum State
    {
        GameStart,
        GameEnd
    }

    private bool currentStat;

    [SerializeField] private Button _button;

    
    // Start is called before the first frame update
    State GetStateEnumType()
    {
        return typeof(State);
    }

    /*void DispatchButtonClickedSignal()
    {
        buttonEvent?.Invoke();
    }*/

    public void SetState(string state)
    {
        
    }
}

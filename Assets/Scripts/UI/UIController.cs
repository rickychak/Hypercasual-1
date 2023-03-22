using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{

    private UIModel _uiModel;
    
    //public event Action<_uiModel.State> buttonEvent;
    // Start is called before the first frame update
    void Start()
    {
        _uiModel = transform.GetComponent<UIModel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

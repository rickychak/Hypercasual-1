using System.Collections.Generic;
using UnityEngine;

public class Buttons: MonoBehaviour
{
    public static Buttons Instance;
    private List<GameObject> _buttonList = new();

    public void ButtonStartSetup()
    {
        Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            _buttonList.Add(transform.GetChild(i).gameObject);
        }
        
    }
    public void ToggleButton()
    {
        foreach (var button in _buttonList)
        {
            button.SetActive(!button.activeSelf);
        }
    }
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "so_wheel", menuName = "Asset/SO")]
public class WheelScriptableObject : ScriptableObject
{
    public bool[] _mapGrid = new bool[140];

    void Start()
    {
        for (int i = 0; i<_mapGrid.Length; i++)
        {
            _mapGrid[i] = false;
        }
    }
}



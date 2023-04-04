using System.Collections.Generic;
using UnityEngine;

public class GridModel : MonoBehaviour
{
    private Vector2 _gridResolution;
    [SerializeField] private List<bool> _grid = new();


    public void InitialiseGrid(int gridRowCount, int gridColumnCount)
    {
        _gridResolution = new Vector2(gridRowCount, gridColumnCount);
        for (int i = 0; i < (gridRowCount * gridColumnCount); i++)
        {
            _grid.Add(false);
        }
    }

    public Vector2 GetCellResolution()
    {
        return _gridResolution;
    }

    public float GetGridSize()
    {
        return _grid.Count;
    }
    public bool GetCellByIndex(int index)
    {
        var tmp = _grid[index];
        return tmp;
    }

    public void ToggleCell(int index, bool boo)
    {
        _grid[index] = boo;
    }

    public void GridUpdate(bool boo)
    {
        for (int i = 0; i < _grid.Count; i++)
        {
            _grid[i] = boo;
        }
    }
    
    
}

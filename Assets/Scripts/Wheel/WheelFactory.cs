using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFactory : MonoBehaviour
{
    [SerializeField] private GridModel _gridModel;
    private Vector2 minGridResolution;
    private List<bool> minGrid = new();

    public void FindGridMinResolution()
    {
        var minRow = _gridModel.GetCellResolution().x;
        var maxRow = 0.0f;
        var minCol = _gridModel.GetCellResolution().y;
        var maxCol = 0.0f;
        for (int i = 0; i < _gridModel.GetGridSize(); i++)
        {
            if (_gridModel.GetCellByIndex(i))
            {
                var row = i / _gridModel.GetCellResolution().x;
                var col = i % _gridModel.GetCellResolution().y;
                minRow = Math.Min(minRow, row);
                maxRow = Math.Min(maxRow, row);
                minCol = Math.Min(minCol, col);
                maxCol = Math.Min(maxCol, col);
            }
        }

        minGridResolution = new Vector2(maxRow - minRow + 1, maxCol - minCol + 1);
        for (int i = 0; i < (int)minGridResolution.x * (int)minGridResolution.y; i++)
        {
            minGrid.Add(false);
        }
        for (int i = (int)minRow; i < maxRow + 1; i++)
        {
            for (int j = (int)minCol; j < maxCol + 1; j++)
            {
                if (_gridModel.GetCellByIndex(i * j))
                {
                    minGrid[((int)maxRow - i) * ((int)maxCol - i)] = true;
                    Debug.Log(((int)maxRow - i) * ((int)maxCol - i));
                }
            }
        }
    }
}

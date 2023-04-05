using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle;

public class WheelFactory : MonoBehaviour
{
    [SerializeField] private GridModel _gridModel;
    [SerializeField] private WheelModel _wheelModel;
    private Vector2 minGridResolution;
    private List<bool> minGrid = new();
    private int _gridSizeX;
    private int _gridSizeY;
    private int _leftTopCoordinate;
    private int _rightBottomCoordinate;
    private int _leftBottomCoordinate;
    private int _rightTopCoordinate;

    private void InitializeWheelParameters()
    {
        _gridSizeX = (int)_gridModel.GetCellResolution().x;
        _gridSizeY = (int)_gridModel.GetCellResolution().y;
    }
    private void CreateWheelGrid()
    {
        var minRow = _gridSizeX;
        var maxRow = 0;
        var minCol = _gridSizeY;
        var maxCol = 0;
        for (int i = 0; i < _gridModel.GetGridSize(); i++)
        {
            if (!_gridModel.GetCellByIndex(i)) continue;
            var row = i / _gridSizeX;
            var col = i % _gridSizeX;
            minRow = Math.Min(minRow, row);
            maxRow = Math.Max(maxRow, row);
            minCol = (int)Math.Min(minCol, col);
            maxCol = (int)Math.Max(maxCol, col);
        }
        minGridResolution = new Vector2(maxRow - minRow + 1, maxCol - minCol + 1);
        
        for (int i = 0; i < (int)minGridResolution.x * (int)minGridResolution.y; i++)
        {
            minGrid.Add(false);
        }

        _leftTopCoordinate = minRow * _gridSizeX + minCol;
        _rightBottomCoordinate = maxRow * _gridSizeX + minCol;
        _leftBottomCoordinate = minRow * _gridSizeX + maxCol;
        _rightTopCoordinate = maxRow * _gridSizeX + maxCol;

        for (int i = 0; i < minGridResolution.x; i++)
        {
            for (int j = 0; j < minGridResolution.y; j++)
            {
                var index = (int) (i*minGridResolution.y + j);
                var subIndex = (int) ((_leftTopCoordinate + j) + _gridSizeX * i);
                minGrid[index] = _gridModel.GetCellByIndex(subIndex);
            }
        }
    }

    public void CreateWheel()
    {
        InitializeWheelParameters();
        CreateWheelGrid();
    }

    
}

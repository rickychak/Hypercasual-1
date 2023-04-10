using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct Wheel
{
    public List<bool> wheelGrid;
    public GameObject wheelPrefab;
    public GameObject wheelCellPrefab;
}
public class WheelFactory : MonoBehaviour
{
    [SerializeField] private WheelModel wheelModel;
    [SerializeField] private GridModel _gridModel;
    [SerializeField] private GameObject _wheelPrefab;
    [SerializeField] private GameObject _wheelCellPrefab;
    private Vector2 _minGridResolution;
    private Wheel _wheel;
    private int _gridSizeX;
    private int _gridSizeY;

    private void InitializeWheelParameters()
    {
        _wheel = new Wheel();
        _gridSizeX = (int)_gridModel.GetCellResolution().x;
        _gridSizeY = (int)_gridModel.GetCellResolution().y;
        _wheel.wheelGrid = new List<bool>();
        _wheel.wheelPrefab = _wheelPrefab; 
        _wheel.wheelCellPrefab = _wheelCellPrefab; 
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
        _minGridResolution = new Vector2(maxRow - minRow + 1, maxCol - minCol + 1);
        
        for (int i = 0; i < (int)_minGridResolution.x * (int)_minGridResolution.y; i++)
        {
            _wheel.wheelGrid.Add(false);
        }

        var _leftTopCoordinate = minRow * _gridSizeX + minCol;
        var _rightBottomCoordinate = maxRow * _gridSizeX + minCol;
        var _leftBottomCoordinate = minRow * _gridSizeX + maxCol;
        var _rightTopCoordinate = maxRow * _gridSizeX + maxCol;

        for (int i = 0; i < _minGridResolution.x; i++)
        {
            for (int j = 0; j < _minGridResolution.y; j++)
            {
                var index = (int) (i*_minGridResolution.y + j);
                var subIndex = (int) ((_leftTopCoordinate + j) + _gridSizeX * i);
                _wheel.wheelGrid[index] = _gridModel.GetCellByIndex(subIndex);
            }
        }
    }

    
    public Wheel CreateWheel()
    {
        
        InitializeWheelParameters();
        CreateWheelGrid();
        _wheel.wheelPrefab.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _wheel.wheelPrefab.GetComponent<GridLayoutGroup>().constraintCount = (int)_minGridResolution.y;
        _wheel.wheelPrefab.GetComponent<WheelJoint2D>().useMotor = false;
        return _wheel;
    }
}

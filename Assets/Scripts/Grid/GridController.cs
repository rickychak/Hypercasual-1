using System;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private GridModel _gridModel;

    private void Start()
    {
        _gridModel = transform.GetComponent<GridModel>();
    }

    public int CellPositionToGridIndex(Vector3Int cellPosition)
    {
        var cleansedCellPosition = new Vector2(cellPosition.x + 23,
            cellPosition.y + 51);

        var gridIndex = (cleansedCellPosition.x - (cleansedCellPosition.y - 52) * 46);
        return (int)gridIndex;
    }
    public void ToggleCell(Vector3Int cellPosition)
    {
        var cellIndex = CellPositionToGridIndex(cellPosition);
        if (_gridModel.GetCellByIndex(cellIndex)) return;
        _gridModel.ToggleCell(cellIndex);
    }
}

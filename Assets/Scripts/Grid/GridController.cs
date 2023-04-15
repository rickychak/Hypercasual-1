using UnityEngine;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField]private GridModel _gridModel;
    [SerializeField] private Tilemap tilemap;


    private void Awake()
    {
        BoundsInt bounds = tilemap.cellBounds;
        _gridModel.InitialiseGrid(bounds.size.x - 1 ,bounds.size.y);
    }
    
    private int CellPositionToGridIndex(Vector3Int cellPosition)
    {
        var gridResolution = _gridModel.GetCellResolution();
        var cleansedCellPosition = new Vector2(cellPosition.x + gridResolution.x/2,
            cellPosition.y + gridResolution.y-1);

        var gridIndex = (cleansedCellPosition.x - (cleansedCellPosition.y - gridResolution.y) * gridResolution.x);
        return (int)gridIndex;
    }
    public void ToggleCell(Vector3Int cellPosition)
    {
        var cellIndex = CellPositionToGridIndex(cellPosition);
        if (_gridModel.GetCellByIndex(cellIndex)) return;
        _gridModel.ToggleCell(cellIndex, true);
    }

    public void SetWholeGrid(bool boo)
    {
        _gridModel.WholeGridReset(boo);
    }

}

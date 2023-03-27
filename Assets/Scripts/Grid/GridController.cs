using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]private GridModel _gridModel;
    private GridView _gridView;


    private void Start()
    {
        _gridModel.GridInitialisation();
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
}

using UnityEngine;

public class GridModel : MonoBehaviour
{
    private Vector2 _gridResolution = new Vector2(46, 52);
    [SerializeField]private bool[] _grid = new bool[2392];


    private void Start()
    {
        GridUpdate(false);
    }

    public Vector2 GetCellResolution()
    {
        return _gridResolution;
    }
    public bool GetCellByIndex(int index)
    {
        var tmp = _grid[index];
        return tmp;
    }

    public void ToggleCell(int index)
    {
        _grid[index] = true;
    }

    public void GridUpdate(bool boo)
    {
        for (int i = 0; i < _grid.Length; i++)
        {
            _grid[i] = boo;
        }
    }
    
    
}

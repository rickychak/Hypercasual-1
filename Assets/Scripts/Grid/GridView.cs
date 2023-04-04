using UnityEngine;
using UnityEngine.Tilemaps;

public class GridView: MonoBehaviour
{
    //private GridController _gridController;
    [SerializeField]private GameplayController _gameplayController;
    [SerializeField]private Tilemap _tilemap;
    private GridController _gridController;

    private void Start()
    {
        _gridController = transform.GetComponent<GridController>();
    }

    private void OnEnable()
    {
        _gameplayController.InputEvent += CellTurnBlackOnClick;
    }
    
    private void OnDisable()
    {
        _gameplayController.InputEvent -= CellTurnBlackOnClick;
    }

    
    public void CellTurnBlackOnClick(Vector3 touchPosition)
    {
        var cellPosition = _tilemap.WorldToCell(touchPosition);
        _tilemap.SetTileFlags(cellPosition, TileFlags.None);
        _tilemap.SetColor(cellPosition, Color.black);
        _gridController.ToggleCell(cellPosition);
    }


    
}

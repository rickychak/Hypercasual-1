using UnityEngine;
using RickyUIUtils;
public class ResponsiveUI : MonoBehaviour
{
    private UIUtils _uiUtils;
    [SerializeField] private Vector2 _iPhone12Resolution = new Vector2(1170, 2532);
    private Camera _cam;
    private GameObject _uiMom;


    [SerializeField] private GameObject _grid;
    private Vector2 _gridScale = Vector2.zero;
    
    private void Awake()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _uiMom = GameObject.FindGameObjectWithTag("UI");
        _uiUtils = new UIUtils(_cam, _uiMom, _iPhone12Resolution);
    }

    void Start()
    {
        _uiUtils.SetResolutionOnStart();
        _grid.transform.localScale = Vector2.one * _uiMom.transform.localScale.y;
    }

}

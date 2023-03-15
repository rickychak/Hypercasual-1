using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Map
{
    public Transform mapTransform { get; set; }
    
}
public class GenerativeMap : MonoBehaviour
{

    [SerializeField] private GameObject _mapParent;
    [SerializeField] private GameObject _leftBound;
    // Start is called before the first frame update
    private List<Map> _mapList = new();
    private Vector3 _mapMoveVel = Vector3.one;
    private Vector3 _rightVec = Vector3.right;
    void Awake()
    {
        for (int i = 0; i < _mapParent.transform.childCount; i++)
        {
            Map _map = new Map();
            _map.mapTransform = _mapParent.transform.GetChild(i).transform;
            _mapList.Add(_map);
        }
    }
    
    void Start()
    {
        
    }

    public void MapSetStartVelocity()
    {
        foreach (var map in _mapList)
        {
            map.mapTransform.GetComponent<Rigidbody2D>().velocity = _mapMoveVel*Controllables.Instance.mapVelocity;
        }
    }

    public void MapSetStopVelocity()
    {
        foreach (var map in _mapList)
        {
            map.mapTransform.GetComponent<Rigidbody2D>().velocity = _mapMoveVel*0.0f;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var map in _mapList)
        {
            if (map.mapTransform.position.x < _leftBound.transform.position.x)
            {
                map.mapTransform.position += Controllables.Instance.mapOffset;
            }
        }
    }
}

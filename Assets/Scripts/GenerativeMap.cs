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

    private Queue<GameObject> _mapQueue = new Queue<GameObject>();

    private GameObject _mapQueueLastObject;
    private GameObject _mapQueueFirstObject;

    // Start is called before the first frame update
    private List<Map> _mapList = new();
    private Vector3 _mapMoveVel = Vector3.one;
    void Awake()
    {
        for (int i = 0; i < _mapParent.transform.childCount; i++)
        {
            Map _map = new Map();
            _map.mapTransform = _mapParent.transform.GetChild(i);
            _mapQueueLastObject = _mapParent.transform.GetChild(i).gameObject;
            _mapQueue.Enqueue(_mapQueueLastObject);
            _mapList.Add(_map);
        }

        _mapQueueFirstObject = _mapQueue.Peek();
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
        if (_mapQueueFirstObject.transform.position.x >= _leftBound.transform.position.x) return;
        var mapQueueTailPosition = _mapQueueLastObject.transform.position;
        _mapQueue.Enqueue(_mapQueue.Dequeue());
        _mapQueueFirstObject.transform.position +=  (Controllables.Instance.mapOffset + Vector3.up*Random.Range(-mapQueueTailPosition.y-0.3f, mapQueueTailPosition.y+0.3f));
        _mapQueueLastObject = _mapQueueFirstObject;
        _mapQueueFirstObject = _mapQueue.Peek();
        var position = _mapQueueLastObject.transform.position;
        if (position.y >= 0.0f) return;
        position = new Vector3(position.x, 0, position.z);
        _mapQueueLastObject.transform.position = position;
        
        
        
        
        
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainController:MonoBehaviour
{
    [SerializeField] private TerrainModel _terrainModel;
    [SerializeField] private GameObject _leftBound;
    [SerializeField] private GameObject mapParent;

    private Queue<GameObject> _mapsQueue = new();
    private GameObject _lastQueueObject;
    private Rigidbody2D[] _mapsRigidbody2DsList;
    private List<GameObject> _backgroundsList;
    private List<GameObject> _mapsList;
    private List<Vector3> _mapOriginalPosition = new();

    private void Awake()
    {
        _terrainModel.mapParent = mapParent;
        _mapsList = _terrainModel.GetMapGameObjects();
        foreach (var mapGO in _mapsList)
        {
            _mapsQueue.Enqueue(mapGO);
            _lastQueueObject = mapGO;
            _mapOriginalPosition.Add(mapGO.transform.position);
        }
        _mapsRigidbody2DsList = mapParent.GetComponentsInChildren<Rigidbody2D>();
        
        SetMapVelocity();
    }

    private void Update()
    {
        if (_mapsQueue.Peek().transform.position.x+_terrainModel.GetRepositionThreshold() > _leftBound.transform.position.x) return;
        var outBoundMap = _mapsQueue.Dequeue();
        outBoundMap.transform.position = _lastQueueObject.transform.position + Vector3.right*_terrainModel.GetTerrainSize();
        var outBoundMapYCoord = Math.Min(Math.Max(0,outBoundMap.transform.position.y + Random.Range(-0.3f, 0.3f)), 1.5f);
        outBoundMap.transform.position += Vector3.up*(-outBoundMap.transform.position.y + outBoundMapYCoord);
        _lastQueueObject = outBoundMap;
        _mapsQueue.Enqueue(_lastQueueObject);
    }


    public void ResetMapCoordinate()
    {
        int _count = 0;
        foreach (var mapGO in _mapsList)
        {
            mapGO.transform.position = _mapOriginalPosition[_count];
            _count++;
        }
    }
    private void SetMapVelocity()
    {
        foreach (var mapRigidBody in _mapsRigidbody2DsList)
        {
            mapRigidBody.velocity = _terrainModel.GetTerrainVelocity();
        }
    }

    public void ToggleMapSimulation()
    {
        foreach (var mapRigidBody in _mapsRigidbody2DsList)
        {
            mapRigidBody.simulated = !mapRigidBody.simulated;
        }
    }
    
    
}
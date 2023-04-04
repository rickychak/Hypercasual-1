using System;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        _terrainModel.mapParent = mapParent;
        _mapsList = _terrainModel.GetMapGameObjects();
        foreach (var mapGO in _mapsList)
        {
            _mapsQueue.Enqueue(mapGO);
            _lastQueueObject = mapGO;
        }
        _mapsRigidbody2DsList = mapParent.GetComponentsInChildren<Rigidbody2D>();
        
        SetMapVelocity();
    }

    private void Update()
    {
        if (_mapsQueue.Peek().transform.position.x+_terrainModel.GetRepositionThreshold() > _leftBound.transform.position.x) return;
        var outBoundMap = _mapsQueue.Dequeue();
        outBoundMap.transform.position = _lastQueueObject.transform.position + Vector3.right*_terrainModel.GetTerrainSize();
        _lastQueueObject = outBoundMap;
        _mapsQueue.Enqueue(_lastQueueObject);
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
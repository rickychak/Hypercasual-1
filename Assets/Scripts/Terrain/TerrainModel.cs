using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainModel: MonoBehaviour
{
    public GameObject mapParent { get; set; }

    private Vector2 terrainVelocity = Vector2.left;
    private float terrainVelocityMultiplier = 1.0f;
    private float terrainRepositionThreshold = 0.5f;
    private float terrainSize = 8.0f;

    public Vector2 GetTerrainVelocity()
    {
        return terrainVelocity * terrainVelocityMultiplier;
    }

    public float GetRepositionThreshold()
    {
        return terrainRepositionThreshold;
    }
    
    public float GetTerrainSize()
    {
        return terrainSize;
    }

    
    public List<GameObject> GetMapGameObjects()
    {
        var mapArray = new List<GameObject>();
        for (int i = 0; i < mapParent.transform.childCount; i++)
        {
            mapArray.Add(mapParent.transform.GetChild(i).gameObject);
        }

        return mapArray;
    }



}
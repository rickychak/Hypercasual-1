using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainModel: MonoBehaviour
{
    public GameObject backgroundParent { get; set; }
    public GameObject mapParent { get; set; }

    private Vector2 terrainVelocity = Vector2.left;
    private float terrainVelocityMultiplier = 1.0f;

    public Vector2 GetTerrainVelocity()
    {
        return terrainVelocity * terrainVelocityMultiplier;
    }

    public List<GameObject> GetBackgroundGameObjects()
    {
        var backgroundArray = new List<GameObject>();
        for (int i = 0; i < backgroundParent.transform.childCount; i++)
        {
            backgroundArray.Add(backgroundParent.transform.GetChild(i).gameObject);
        }

        return backgroundArray;
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
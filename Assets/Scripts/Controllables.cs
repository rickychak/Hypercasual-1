using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "so_controllable", menuName = "Assets/Parameters")]
public class Controllables : ScriptableObject
{
    public static Controllables Instance;

    public float mapVelocity = 0;
    public Vector3 mapOffset = Vector3.right;
    
    public float vehicleVelocity = 0;
    public Vector3 vehicleOriginalPosition;

    public Vector3[] wheelOriginalPositions = new Vector3[2];
    
    public float highestScore = 0;
    [InitializeOnEnterPlayMode]
    private void Init()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        } 
    }
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}

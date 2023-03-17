using System;
using UnityEngine;

public class Gameflow: MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        GenerativeMap.Instance.MapStartSetup();
        Buttons.Instance.ButtonStartSetup();
        Wheels.Instance.WheelsStartSetup();
        Score.Instance.ScoreStartSetup();
    }

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        GenerativeMap.Instance.GenerateMapOnFixedUpdate();
    }
}
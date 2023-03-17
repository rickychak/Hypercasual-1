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
        GridToWheel.Instance.GridToWheelStartSetup();
        Vehicle.Instance.StopVehicle();
    }

    
    public void StartGame()
    {
        if (GridToWheel.Instance.StartSignalGetter()) return;
        GridToWheel.Instance.StartSignalToggle();
        Vehicle.Instance.StartVehicle();
        Wheels.Instance.SetVelocity();
        Buttons.Instance.ToggleButton();
        Wheels.Instance.SetWheel();
        GridToWheel.Instance.SetGridToWheel();
    }
    
    public void RestartGame()
    {
        if (!GridToWheel.Instance.StartSignalGetter()) return;
        GridToWheel.Instance.StartSignalToggle();
        Wheels.Instance.ResetWheel();
        GridToWheel.Instance.ResetWheelAndGrid();
        Vehicle.Instance.StopVehicle();
        Score.Instance.UploadScore();
        DrawToGrid.Instance.MapGridReset();
        Buttons.Instance.ToggleButton();
        
    }

    private void Update()
    {
        if (!GridToWheel.Instance.StartSignalGetter()) return;
        Score.Instance.UpdateScore();
    }

    private void FixedUpdate()
    {
        GenerativeMap.Instance.GenerateMapOnFixedUpdate();
    }
}
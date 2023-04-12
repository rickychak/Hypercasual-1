using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleFactory : MonoBehaviour
{
    [FormerlySerializedAs("_wheelFactory")] [SerializeField] private WheelFactory wheelFactory;
    [FormerlySerializedAs("_vehiclePrefab")] [SerializeField] private GameObject vehiclePrefab;
    Vector2 _anchorOnVehicle = new Vector2(0.5f, -0.5f);
    private GameObject _vehicle;
    int _count = 0;

    private GameObject ConstructWheel()
    {
        var wheelInfo = wheelFactory.CreateWheel();
        var wheel = Instantiate(wheelInfo.wheelPrefab);
        for (int i = 0; i < wheelInfo.wheelGrid.Count; i++)
        {
            var wheelCell = Instantiate(wheelInfo.wheelCellPrefab, wheel.transform, false);
            if (!wheelInfo.wheelGrid[i]) continue;
            wheelCell.AddComponent<BoxCollider2D>();
            wheelCell.AddComponent<BoxCollider2D>().usedByComposite = true;
            wheelCell.GetComponent<SpriteRenderer>().color = Color.black;
        }

        if (wheelInfo.wheelGrid.Count > 100)
        {
            wheel.transform.localScale *= 0.25f;
        }
        return wheel;
    }

    private void AssembleVehicle(GameObject wheel)
    {
        
        wheel.transform.GetComponent<RectTransform>().SetParent(_vehicle.transform);
        wheel.transform.GetComponent<WheelJoint2D>().useMotor = false;
        wheel.transform.GetComponent<WheelJoint2D>().connectedBody = _vehicle.GetComponent<Rigidbody2D>();
        wheel.transform.GetComponent<WheelJoint2D>().connectedAnchor = _anchorOnVehicle+ Vector2.left * _count;
        wheel.transform.GetComponent<RectTransform>().localPosition = Vector3.down*0.5f;
        _count++;

    }

    public void ResetVehicle()
    {
        _count = 0;
        Destroy(_vehicle);
    }
    
    

    private void BootEngine(GameObject wheel)
    {
        wheel.GetComponent<WheelJoint2D>().useMotor = true;
    }

    public void CreateVehicle()
    {
        _vehicle = Instantiate(vehiclePrefab,  new Vector3(0,2,1), Quaternion.identity );
        var leftWheel = ConstructWheel();
        var rightWheel = ConstructWheel();
        AssembleVehicle(leftWheel);
        AssembleVehicle(rightWheel);
        BootEngine(leftWheel);
        BootEngine(rightWheel);
    }




}
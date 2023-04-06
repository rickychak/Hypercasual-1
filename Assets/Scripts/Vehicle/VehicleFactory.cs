using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFactory : MonoBehaviour
{
    [SerializeField] private WheelFactory _wheelFactory;
    [SerializeField] private GameObject _vehiclePrefab;
    Vector2 anchorOnVehicle = new Vector2(0.5f, 1.0f);
    private GameObject _vehicle;

    private GameObject ConstructWheel()
    {
        var wheelInfo = _wheelFactory.CreateWheel();
        var wheel = Instantiate(wheelInfo.wheelPrefab);
        for (int i = 0; i < wheelInfo.wheelGrid.Count; i++)
        {
            var wheelCell = Instantiate(wheelInfo.wheelCellPrefab, wheel.transform, false);
            if (!wheelInfo.wheelGrid[i]) continue;
            wheelCell.GetComponent<BoxCollider2D>().enabled = true;
            wheelCell.GetComponent<SpriteRenderer>().color = Color.black;
        }
    
        return wheel;
    }

    private void AssembleVehicle(GameObject wheel)
    {
        wheel.transform.GetComponent<RectTransform>().localPosition = Vector3.down;
        wheel.transform.GetComponent<RectTransform>().SetParent(_vehicle.transform);
        
        wheel.transform.GetComponent<WheelJoint2D>().connectedBody = wheel.transform.parent.GetComponent<Rigidbody2D>();
        wheel.transform.GetComponent<WheelJoint2D>().anchor = anchorOnVehicle;
        wheel.transform.position = anchorOnVehicle;
        anchorOnVehicle -= Vector2.left;

    }

    public void CreateVehicle()
    {
        _vehicle = Instantiate(_vehiclePrefab,  new Vector3(0,3,0), Quaternion.identity );
        var leftWheel = ConstructWheel();
        var rightWheel = ConstructWheel();
        AssembleVehicle(leftWheel);
        AssembleVehicle(rightWheel); 
    }




}
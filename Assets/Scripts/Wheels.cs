using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public static Wheels Instance;
    private WheelJoint2D[] _wheelJoint2Ds;
    private Rigidbody2D[] _wheelRigidbody2Ds;
    private List<RectTransform> _wheelTransforms = new();
    private JointMotor2D _jointMoter;
    private Quaternion _zeroRotation = Quaternion.identity;
    
    // Start is called before the first frame update
    void Start()
    {
        _wheelJoint2Ds = transform.GetComponentsInChildren<WheelJoint2D>();
        _wheelRigidbody2Ds = transform.GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _wheelTransforms.Add(transform.GetChild(i).transform.GetComponent<RectTransform>());
        }
        _jointMoter = _wheelJoint2Ds[0].motor;
    }

    public void SetVelocity()
    {
        _jointMoter.motorSpeed = Controllables.Instance.vehicleVelocity;
        foreach (var wheelJoint in _wheelJoint2Ds)
        {
            wheelJoint.motor = _jointMoter;
        }
    }

    public void ResetWheel()
    {
        foreach (var wheelRigidBody2D in _wheelRigidbody2Ds)
        {
            wheelRigidBody2D.simulated = false;
            wheelRigidBody2D.angularVelocity = 0;
        }

        for (int i = 0; i < _wheelTransforms.Count; i++)
        {
            _wheelTransforms[i].localPosition = Controllables.Instance.wheelOriginalPositions[i];
            _wheelTransforms[i].rotation = _zeroRotation;
        }
    }

    public void SetWheel()
    {
        foreach (var wheelRigidBody2D in _wheelRigidbody2Ds)
        {
            wheelRigidBody2D.simulated = true;
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

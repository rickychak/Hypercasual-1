using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CameraModel _cameraModel;
    [SerializeField] private GameObject _camera;

    public void SetCameraVelocity() 
    {
        _camera.transform.GetComponent<Rigidbody2D>().AddForce(_cameraModel.GetCameraMovementVelocity());
    }
    public void ResetCameraVelocity()
    {
        _camera.transform.GetComponent<Rigidbody2D>().AddForce(0*_cameraModel.GetCameraMovementVelocity());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _camera.gameObject.transform.position += Vector3.right*0.001f;
    }
}

using UnityEngine;

public class CameraModel : MonoBehaviour
{
    private float _cameraMoveVel = 5.0f;
    private Vector2 _cameraMoveForce = Vector2.right;
    private bool _cameraTrigger = false;

    public Vector2 GetCameraMovementVelocity()
    {
        return _cameraMoveVel*_cameraMoveForce;
    }

    public void SetCameraMovementVelocity(float cameraVelocity)
    {
        _cameraMoveVel = cameraVelocity;
    }

    public void SetCameraTrigger()
    {
        _cameraTrigger = !_cameraTrigger;
    }

    public bool GetCameraTrigger()
    {
        return _cameraTrigger;
    }
}

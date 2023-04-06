using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelModel : MonoBehaviour
{
    private Vector2 _motorParams = new Vector2(300f, 600f);

    public Vector2 GetMotorParams()
    {
        return _motorParams;
    }
}

using UnityEngine;
using System.Collections.Generic;
public class CarMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _wheels;
    private List<Rigidbody2D> rb2 = new();
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private GridToWheel _gtw;
    private void Awake()
    {
        foreach (var wheel in _wheels)
        {
            rb2.Add(wheel.GetComponent<Rigidbody2D>());
        }
    }
    private void FixedUpdate()
    {
        if (!_gtw.isStarted) return;
        rb2[0].AddTorque(-speed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    private Camera _cam;
    
    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount <= 0) return;
        
        Vector3 touchPoint = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)touchPoint, _cam.transform.forward, 100.0f);
        if (!hit) return;
        
        if (hit.collider.gameObject.TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = Color.black;
        }
    }
    
    
}



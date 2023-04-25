using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingBall : MonoBehaviour
{
    private float MaxX, MinX;
    private float MaxY, MinY;

    private Vector2 _direction;

    public TrailRenderer trail;
    
    void Start()
    {
        Camera main = Camera.main;
        var botLeft = main.ViewportToWorldPoint(new Vector3(0, 0, main.nearClipPlane));
        var topRight = main.ViewportToWorldPoint(new Vector3(1, 1, main.nearClipPlane));

        MinX = botLeft.x;
        MinY = botLeft.y;
        MaxX = topRight.x;
        MaxY = topRight.y;
        
        _direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        var v = (Vector2)transform.position;
        if (v.magnitude > 4.5)
        {
            _direction = Vector2.Reflect(_direction, -(v.normalized));
        }
        
        transform.Translate(_direction * (BallManager.ballSpeed * Time.deltaTime));
    }
}

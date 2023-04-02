using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (transform.position.x > MaxX || transform.position.x < MinX)
        {
            _direction.x *= -1;
        }
        
        if (transform.position.y > MaxY || transform.position.y < MinY)
        {
            _direction.y *= -1;
        }

        var speed = BallManager.ballSpeed;
        
        transform.Translate(_direction * (Time.deltaTime * speed));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public const int MAX_X = 5, MIN_X = -5;
    public const int MAX_Y = 5, MIN_Y = -5;
    
    private Vector2 direction;

    void Start()
    {
        direction = new Vector2
        {
            x = Random.Range(-1.0f, 1.0f),
            y = Random.Range(-1.0f, 1.0f)
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > MAX_X || transform.position.x < MIN_X)
        {
            direction.x *= -1;
        }
        
        if (transform.position.y > MAX_Y || transform.position.y < MIN_Y)
        {
            direction.y *= -1;
        }

        float speed = FindObjectOfType<BallManager>().ballSpeed;
        
        transform.Translate(direction * Time.deltaTime * speed);
    }
}

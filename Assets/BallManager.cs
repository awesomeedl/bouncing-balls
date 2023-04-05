using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class BallManager : MonoBehaviour
{
    public const float canvasRadius = 4;
    
    
    private const int maxBallCount = 50;
    private const float maxBallSpeed = 20f;
    private const float maxBallSize = 2f;
    private const float maxBallTrail = 2f;
    private List<MovingBall> balls = new List<MovingBall>();

    public MovingBall ballTemplate;

    public static int ballCount = 10;
    
    public static float ballSpeed = 1.0f;

    public SliderController ballCountController;
    public SliderController ballSpeedController;
    public SliderController ballSizeController;
    public SliderController ballTrailController;

    public void BallTrailChanged(float value)
    {
        foreach (var ball in balls)
        {
            ball.trail.time = value;
        }
    }
    
    public void BallSizeChanged(float value)
    {
        foreach (var ball in balls)
        {
            ball.transform.localScale = new Vector3(value, value, 1);

            ball.trail.startWidth = value * 0.9f;
            ball.trail.endWidth = value * 0.9f;
        }
    }

    public void BallSpeedChanged(float value)
    {
        ballSpeed = value;
    }
    
    public void BallCountChanged(float value)
    {
        var count = (int)value;
        
        ballCount = count;
        for (int i = 0; i < count; i++)
        {
            balls[i].gameObject.SetActive(true);
        }

        for (int i = count; i < maxBallCount; i++)
        {
            balls[i].gameObject.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < maxBallCount; i++)
        {
            var ball = Instantiate<MovingBall>(ballTemplate, Random.insideUnitCircle * 4, Quaternion.identity);
            balls.Add(ball);
        }

        ballCountController.Init(1, maxBallCount);
        ballSpeedController.Init(0.1f, maxBallSpeed);
        ballSizeController.Init(0.1f, maxBallSize);
        ballTrailController.Init(0f, maxBallTrail);
        
        
    }
}

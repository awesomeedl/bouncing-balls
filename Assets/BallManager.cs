using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private List<GameObject> balls;

    public GameObject ballTemplate;

    [Range(1, 500)] public int ballCount = 10;
    
    [Range(1.0f, 10.0f)]
    public float ballSpeed = 1.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ballCount; i++)
        {
            Instantiate(ballTemplate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

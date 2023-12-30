using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddleScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private float lowerBoundRand;
    private float upperBoundRand;
    [SerializeField] private float moveSpeed = 4f;

    [SerializeField] private BallScript ballScript;

    private string xDir;
    public static string difficulty = "normal";
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (difficulty.Equals("easy"))
        {
            lowerBoundRand = 0.5f;
            upperBoundRand = 0.8f;
        }
        if (difficulty.Equals("normal"))
        {
            lowerBoundRand = 0.2f;
            upperBoundRand = 0.5f;
        }
        if (difficulty.Equals("hard"))
        {
            lowerBoundRand = 0.1f;
            upperBoundRand = 0.2f;
        }
    }

    private void Update()
    {
        if (!ballScript.destroyed)
        {
            if (ballScript.transform.position.x < transform.position.x)
            {
                xDir = "left";
                float random = UnityEngine.Random.Range(lowerBoundRand, upperBoundRand);
                Debug.Log(random.ToString());
                Invoke(nameof(Left), random);
            }
            if (ballScript.transform.position.x > transform.position.x)
            {
                xDir = "right";
                float random = UnityEngine.Random.Range(lowerBoundRand, upperBoundRand);
                Debug.Log(random.ToString());
                Invoke(nameof(Right), random);
            }
        }
        if (ballScript.destroyed)
        {
            Stop();
        }
    }

    private void Left()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        if (transform.position.x < -3.9f)
        {
            Stop();
        }
    }

    private void Right()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (transform.position.x > 3.9f)
        {
            Stop();
        }
    }

    private void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}

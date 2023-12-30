using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BallScript : MonoBehaviour
{
    private string xDir = "none";
    private string yDir = "none";

    public bool destroyed = false;

    [SerializeField] private float ballSpeed = 3f;

    private Rigidbody2D rb;
    [SerializeField] private AudioSource hitSoundEffect;

    [SerializeField] ScoreScript score;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!ScoreScript.winner.Equals("none"))
        {
            destroyed = true;
            Destroy(gameObject);
        }

        transform.position = new Vector3(0, 0, transform.position.z);

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            Invoke(nameof(Up), 1f);
            yDir = "up";
        }
        else
        {
            Invoke(nameof(Down), 1f);
            yDir = "down";
        }
    }

    private void Up()
    {
        rb.velocity = new Vector2(rb.velocity.x, ballSpeed);
    }

    private void Down()
    {
        rb.velocity = new Vector2(rb.velocity.x, -ballSpeed);
    }

    private void Left()
    {
        float random = Random.Range(0.5f, 3);
        rb.velocity = new Vector2(-random, rb.velocity.y);
    }

    private void Right()
    {
        float random = Random.Range(0.5f, 2.5f);
        rb.velocity = new Vector2(random, rb.velocity.y);
    }

    private void Stop()
    {
        rb.velocity = new Vector2(0, 0);
        xDir = "none";
        yDir = "none";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //On collision with the paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            hitSoundEffect.Play();
            if (yDir.Equals("down"))
            {
                Up();
                yDir = "up";
            }
            else if (yDir.Equals("up"))
            {
                Down();
                yDir = "down";
            }
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Left();
                xDir = "left";
            }
            else
            {
                Right();
                xDir = "right";
            }
        }
        //On collision with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (xDir.Equals("left"))
            {
                Right();
                xDir = "right";
            }
            else if (xDir.Equals("right"))
            {
                Left();
                xDir = "left";
            }
        }
        //In the score area
        if (collision.gameObject.CompareTag("ScoreArea"))
        {
            if (transform.position.y < 0)
            {
                score.redScore++;
            }
            if (transform.position.y > 0)
            {
                score.blueScore++;
            }
            Stop();
            Invoke("Start", 1f);
        }
    }
}

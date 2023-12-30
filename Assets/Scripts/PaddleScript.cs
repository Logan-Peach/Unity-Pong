using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 4f;
    private float dirX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (transform.position.x < -3.9f && dirX < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (transform.position.x > 3.9f && dirX > 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}

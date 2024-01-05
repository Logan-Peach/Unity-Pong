using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItemScript : MonoBehaviour
{
    private int upperBound;
    private int lowerBound;
    private int leftBound;
    private int rightBound;

    void Start()
    {
        upperBound = 3;
        lowerBound = -3;
        leftBound = -4;
        rightBound = 4;
        Move();
    }

    public void Move()
    {
        float x = Random.Range(leftBound, rightBound);
        float y = Random.Range(lowerBound, upperBound);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}

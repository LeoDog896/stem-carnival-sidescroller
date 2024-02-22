using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float lowerBound;
    public float upperBound;

    [SerializeField] private float speed = 100f;

    private bool movingRight = true;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (movingRight && transform.position.x >= upperBound + originalPosition.x)
        {
            movingRight = false;
        } else if (!movingRight && transform.position.x <= originalPosition.x - lowerBound)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        } else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}

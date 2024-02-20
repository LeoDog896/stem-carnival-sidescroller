using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float lowerBound;
    public float upperBound;

    [SerializeField] private float speed = 100f;

    private bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        var lowerBoundPosition = transform.position + Vector3.left * lowerBound;
        var upperBoundPosition = transform.position + Vector3.right * upperBound;

        if (movingRight)
        {

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    /** List of player input handlers from [PlayerManager] */
    public PlayerInput[] players;

    /** The desired X position of the camera */
    private float desiredX;

    static Boolean isNear(float a, float b, float epsilon)
    {
        return Math.Abs(a - b) < epsilon;
    }

    // Update is called once per frame
    void Update()
    {
        // set the current transform X to the midpoint of the players
        var midpoint = (players[0].transform.position.x + players[1].transform.position.x) / 2;
        desiredX = midpoint;

        var change = Time.deltaTime * 5;

        // if the camera is not near the desired X, move it closer
        if (!isNear(transform.position.x, desiredX, change))
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, desiredX, change),
                transform.position.y,
                transform.position.z
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    /** List of player input handlers from [PlayerManager] */
    public PlayerInput[] players;

    // Update is called once per frame
    void Update()
    {
        // set the current transform X to the midpoint of the players
        var midpoint = (players[0].transform.position.x + players[1].transform.position.x) / 2;
        transform.position = new Vector3(midpoint, transform.position.y, transform.position.z);
    }
}

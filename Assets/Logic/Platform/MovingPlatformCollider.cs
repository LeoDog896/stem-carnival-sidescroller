using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = this.transform.parent;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToCarrier : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        Carry component = collider.GetComponent<Carry>();
        component.carriedObject = gameObject;
    }
}

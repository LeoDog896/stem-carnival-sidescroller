using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerProjection : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        var hit = Physics2D.Raycast(transform.position, -transform.up);

        if (hit.collider != null)
        {
            // If the raycast hits something, draw a line from this object's position to the hit point
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            GameObject gameObject = hit.collider.gameObject;
            Carry carry = gameObject.GetComponent<Carry>();
            // TODO: switch syntax to use guard statements l&r
            if (carry != null)
            {
                GameObject carriedObject = carry.carriedObject;
                if (carriedObject != null)
                {
                    carry.carriedObject = null;

                    SendToCarrier sendToCarrier = carriedObject.GetComponent<SendToCarrier>();
                    if (sendToCarrier != null)
                    {
                        carriedObject.transform.position = sendToCarrier.originalPosition;
                    }
                }
            }
        }
        else
        {
            // If the raycast doesn't hit anything, draw a line from this object's position to 100 units in front of it
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
    }
}

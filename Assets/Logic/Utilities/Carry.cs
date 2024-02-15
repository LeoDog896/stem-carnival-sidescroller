using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    public GameObject carriedObject;

    // Update is called once per frame
    void Update()
    {
        if (carriedObject)
        {
            carriedObject.transform.position = transform.position;
        }
    }
}
